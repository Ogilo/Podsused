using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Podsused
{

    public class DatabaseHelper
    {
        private static string constring = "Data Source=localhost\\;Initial Catalog=Podused;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";   

        public static void SpremiIgrac(string igracIme, string igracPrezime, Image igracSlika)
        {
            byte[] slika;
            using(MemoryStream ms = new MemoryStream())
            {
                igracSlika.Save(ms, igracSlika.RawFormat);
                slika = ms.ToArray();
            }

            SqlConnection con = new SqlConnection
            ("Data Source=localhost\\;Initial Catalog=Podused;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Igrac (Ime, Prezime, Slika) VALUES(@ime, @prezime, @slika)";
            cmd.Parameters.AddWithValue("@ime", igracIme);
            cmd.Parameters.AddWithValue("@prezime", igracPrezime);
            cmd.Parameters.AddWithValue("@slika", slika);
            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void PrikaziSve(DataGridView gridView)
        {         
            string query = @"SELECT i.IgracId, i.Ime, i.Prezime, SUM(iu.ZabijeniGolovi) AS BrojGolova, BrojIgracKola, BrojPotezKola, Slika
                            FROM Utakmica u
                            INNER JOIN IgracUtakmica iu ON u.UtakmicaId = iu.UtakmicaId
                            INNER JOIN Igrac i ON iu.IgracId = i.IgracId
                            INNER JOIN Tim t ON iu.TimId = t.TimId
                            GROUP BY i.IgracId, i.Ime, i.prezime, i.SLika, i.BrojIgracKola, i.BrojPotezKola";

            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds, "Igrac");             

                gridView.DataSource = ds.Tables["Igrac"];

                gridView.Columns["IgracId"].Visible = false;
                gridView.Columns["Slika"].Visible = false;
            }
        }

        public static void SpremiUtakmica(DateTime Date, int resultTeamA, int resultTeamB, List<string> igraciTimA, List<string> igraciTimB, List<int> ZabijeniGoloviTimA, List<int> ZabijeniGoloviTimB)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                int utakmicaId = 0;
                try
                {
                    string query = "INSERT INTO Utakmica (RezultatTimA, RezultatTimB, Datum) VALUES(@rezTimA, @rezTimB, @datum); SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, con, transaction);
                    cmd.Parameters.AddWithValue("@rezTimA", resultTeamA);
                    cmd.Parameters.AddWithValue("@rezTimB", resultTeamB);
                    cmd.Parameters.AddWithValue("@datum", Date);
                    utakmicaId = Convert.ToInt32(cmd.ExecuteScalar());

                    for (int i = 0; i < igraciTimA.Count; i++)
                    {
                        var igrac = igraciTimA[i];
                        var golovi = ZabijeniGoloviTimA[i];

                        int spaceIndex = igrac.IndexOf(' ');
                        int idIgrac = 0;

                        if (spaceIndex != -1)
                        {
                            string substring = igrac.Substring(0, spaceIndex);
                            idIgrac = int.Parse(substring);
                        }

                        string igracUtakmicaQuery = "INSERT INTO IgracUtakmica (IgracId, UtakmicaId, TimId, ZabijeniGolovi) VALUES(@IgracId, @UtakmicaId, 1, @ZabijeniGolovi);";
                        SqlCommand igracUtakmicaCmd = new SqlCommand(igracUtakmicaQuery, con, transaction);
                        igracUtakmicaCmd.Parameters.AddWithValue("@IgracId", idIgrac);
                        igracUtakmicaCmd.Parameters.AddWithValue("@UtakmicaId", utakmicaId);
                        igracUtakmicaCmd.Parameters.AddWithValue("@ZabijeniGolovi", golovi);
                        igracUtakmicaCmd.ExecuteNonQuery();
                    }

                    for(int i = 0; i < igraciTimB.Count; i++)
                    {
                        var igrac = igraciTimB[i];
                        var golovi = ZabijeniGoloviTimB[i];

                        int spaceIndex = igrac.IndexOf(' ');
                        int idIgrac = 0;

                        if (spaceIndex != -1)
                        {
                            string substring = igrac.Substring(0, spaceIndex);
                            idIgrac = int.Parse(substring);
                        }

                        string igracUtakmicaQuery = "INSERT INTO IgracUtakmica (IgracId, UtakmicaId, TimId, ZabijeniGolovi) VALUES(@IgracId, @UtakmicaId, 2, @ZabijeniGolovi);";
                        SqlCommand igracUtakmicaCmd = new SqlCommand(igracUtakmicaQuery, con, transaction);
                        igracUtakmicaCmd.Parameters.AddWithValue("@IgracId", idIgrac);
                        igracUtakmicaCmd.Parameters.AddWithValue("@UtakmicaId", utakmicaId);
                        igracUtakmicaCmd.Parameters.AddWithValue("@ZabijeniGolovi", golovi);
                        igracUtakmicaCmd.ExecuteNonQuery();
                    }
                    
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                finally
                {
                    con.Close();
                }
            }
        }        
    }
}
