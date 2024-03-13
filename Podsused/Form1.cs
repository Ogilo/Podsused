using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podsused
{
    public partial class Form1 : Form
    {
        private static string constring = "Data Source=localhost\\;Initial Catalog=Podused;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        private Bitmap transparentImage;

        public Form1()
        {
            InitializeComponent();
            fillPocetna();
            MakeTransparent();
        }
     
        private void MakeTransparent()
        {
            Image image = pictureBox1.Image;

            // Create a new Bitmap with the same size as the PictureBox image
            Bitmap transparentImage = new Bitmap(image.Width, image.Height);

            // Create a Graphics object from the transparent image
            using (Graphics g = Graphics.FromImage(transparentImage))
            {
                // Create an ImageAttributes object with a ColorMatrix to control transparency
                ColorMatrix colorMatrix = new ColorMatrix();
                colorMatrix.Matrix33 = 0.5f; // Set the transparency level (0.0 - fully transparent, 1.0 - fully opaque)
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // Draw the original image onto the transparent image with transparency applied
                g.DrawImage(image, new Rectangle(0, 0, transparentImage.Width, transparentImage.Height),
                             0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            pictureBox1.Image = transparentImage;
        }

        private void fillPocetna()
        {
            string Datum = "";
            string Rezultat = "";

            

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();

                string getZadnjaOdigranaId = "SELECT MAX(UtakmicaId) FROM Utakmica";
                SqlCommand cmd = new SqlCommand(getZadnjaOdigranaId, con);
                int ZadnjaOdigranaId = Convert.ToInt32(cmd.ExecuteScalar());


                string query = @"
                        SELECT u.Datum, u.RezultatTimA, u.RezultatTimB, i.Ime AS ImeIgraca, i.Prezime AS PrezimeIgraca, t.Ime AS Tim
                        FROM Utakmica u
                        INNER JOIN IgracUtakmica iu ON u.UtakmicaId =  iu.UtakmicaId
                        INNER JOIN Igrac i ON iu.IgracId = i.IgracId
                        INNER JOIN Tim t ON iu.TimId = t.TimId
                        WHERE u.UtakmicaId = @ZadnjaOdigranaId";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ZadnjaOdigranaId", ZadnjaOdigranaId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (Datum == "")
                    {
                        Datum = reader.GetDateTime(reader.GetOrdinal("Datum")).ToString("dd/MM/yyyy");
                        Rezultat = $"{reader.GetInt32(reader.GetOrdinal("RezultatTimA"))} : {reader.GetInt32(reader.GetOrdinal("RezultatTimB"))}";
                    }

                    string playerName = $"{reader.GetString(reader.GetOrdinal("ImeIgraca"))} {reader.GetString(reader.GetOrdinal("PrezimeIgraca"))}";
                    string teamName = reader.GetString(reader.GetOrdinal("Tim")).Trim();

                    if (teamName == "TeamA")
                    {
                        listBox1.Items.Add(playerName);
                    }
                    else if (teamName == "TeamB")
                    {
                        listBox2.Items.Add(playerName);
                    }
                }
            }

            rezultatLabel.Text = Rezultat;
            datumLabel.Text = Datum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NoviIgrac noviIgrac = new NoviIgrac();
            noviIgrac.ShowDialog();
        }

        private void noviIgračToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoviIgrac noviIgrac = new NoviIgrac();
            noviIgrac.ShowDialog();
        }

        private void igračaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PregledIgraca pregledIgraca = new PregledIgraca();
            pregledIgraca.ShowDialog();
        }

        private void utakmicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PregledUtakmica pregledUtakmica = new PregledUtakmica();
            pregledUtakmica.ShowDialog();
        }

        private void novaUtakmicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovaUtakmica novaUtakmica = new NovaUtakmica();
            novaUtakmica.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;

            rezultatLabel.Parent = pictureBox1;
            rezultatLabel.BackColor = Color.Transparent;

            datumLabel.Parent = pictureBox1;
            datumLabel.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
