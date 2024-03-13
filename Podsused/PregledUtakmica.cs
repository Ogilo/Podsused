using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Podsused
{
    public partial class PregledUtakmica : Form
    {
        string constring =
            ("Data Source=localhost\\;Initial Catalog=Podused;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");

        public PregledUtakmica()
        {
            InitializeComponent();
            FillDGV();
            FillComboBox();
        }

        private void FillComboBox()
        {
            combBoxIgrac.Items.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    string query = "SELECT IgracId, Ime, Prezime FROM Igrac";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string igrac = reader.GetInt32(0).ToString() + " " + reader.GetString(1) + " " + reader.GetString(2);
                                combBoxIgrac.Items.Add(igrac);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FillDGV()
        {           
           DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                string query = "SELECT UtakmicaId, Datum, RezultatTimA, RezultatTimB FROM Utakmica";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["UtakmicaId"].HeaderText = "Kolo";
                if (dataGridView1.Columns.Contains("Datum"))
                {
                    dataGridView1.Columns["Datum"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> listTimA = new List<string>();
            List<string> listTimB = new List<string>();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int utakmicaId = Convert.ToInt32(row.Cells["UtakmicaId"].Value);

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string query = @"SELECT i.Ime, i.Prezime, t.Ime AS TimName
                                    FROM Utakmica u
                                    INNER JOIN IgracUtakmica iu ON u.UtakmicaId = iu.UtakmicaId
                                    INNER JOIN Igrac i ON iu.IgracId = i.IgracId
                                    INNER JOIN Tim t ON iu.TimId = t.TimId
                                    WHERE u.utakmicaId = @UtakmicaId";

                    SqlCommand cmd = new SqlCommand(@query, con);
                    cmd.Parameters.AddWithValue("@UtakmicaId", utakmicaId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        string playerName = $"{reader.GetString(reader.GetOrdinal("Ime"))} {reader.GetString(reader.GetOrdinal("Prezime"))}";
                        string teamName = reader.GetString(reader.GetOrdinal("TimName")).Trim();

                        if (teamName == "TeamA")
                        {
                            listTimA.Add(playerName);
                        }
                        else if (teamName == "TeamB")
                        {
                            listTimB.Add(playerName);
                        }
                    }
                }
                Thread t1 = new Thread(() =>
                {
                    MessageBox.Show(string.Join(Environment.NewLine, listTimA), "TeamA");
                });
                t1.Start();

                Thread t2 = new Thread(() =>
                {
                    MessageBox.Show(string.Join(Environment.NewLine, listTimB), "TeamB");
                });
                t2.Start();             
            }
        }

        private void combBoxIgrac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string igrac = combBoxIgrac.SelectedItem.ToString();
            int spaceIndex = igrac.IndexOf(' ');
            int igracId = 0;

            if (spaceIndex != -1)
            {
                igracId = Convert.ToInt32(igrac.Substring(0, spaceIndex));
            }
            
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                string query = @"SELECT u.*, t.Ime AS TimIme, iu.ZabijeniGolovi
                                FROM Igrac i
                                INNER JOIN IgracUtakmica iu ON i.IgracId = iu.IgracId
                                INNER JOIN Utakmica u ON iu.UtakmicaId = u.UtakmicaId
                                INNER JOIN Tim t on iu.TimId = t.TimId
                                WHERE i.IgracId = @OdabraniIgrac";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OdabraniIgrac", igracId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["UtakmicaId"].HeaderText = "Kolo";
                if (dataGridView1.Columns.Contains("Datum"))
                {
                    dataGridView1.Columns["Datum"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillDGV();
        }
    }
}
