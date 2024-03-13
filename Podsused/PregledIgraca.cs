using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podsused
{
    public partial class PregledIgraca : Form
    {
        public PregledIgraca()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PregledIgraca_Load(object sender, EventArgs e)
        {
            DatabaseHelper.PrikaziSve(dataGridView1);
        }

        private void PrikaziSliku(byte[] imageData)
        {
            try
            {
                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);

                        slikaIgrac.Image = image;
                    }
                }
                else
                {
                    slikaIgrac.Image = null;
                    MessageBox.Show("Slika ne postoji.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                byte[] slika = (byte[])row.Cells["Slika"].Value;

                PrikaziSliku(slika);
            }       
        }

        private void buttonAzuriraj_Click(object sender, EventArgs e)
        {
            string constring = "Data Source=localhost\\;Initial Catalog=Podused;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";   

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();

                foreach(DataGridViewRow redak in dataGridView1.Rows)
                {
                    int id = Convert.ToInt32(redak.Cells["IgracId"].Value);
                    int brPK = Convert.ToInt32(redak.Cells["BrojPotezKola"].Value);
                    int brIK = Convert.ToInt32(redak.Cells["BrojIgracKola"].Value);

                    string query = "UPDATE Igrac SET BrojPotezKola =  @brPK, BrojIgracKola = @brIK WHERE IgracId = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@brPK", brPK);
                    cmd.Parameters.AddWithValue("@brIK", brIK);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }
    }
}
