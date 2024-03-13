using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podsused
{
    public partial class NovaUtakmica : Form
    {   

        string constring =
            ("Data Source=localhost\\;Initial Catalog=Podused;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        public NovaUtakmica()
        {
            InitializeComponent();

            Igraci();
        }

        private void Igraci()
        {
            comboBox1.Items.Clear();

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
                                comboBox1.Items.Add(igrac);
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

        private void NovaUtakmica_Load(object sender, EventArgs e)
        {

        }

        private void DodajTimA_Click(object sender, EventArgs e)
        {
            ListTimA.Items.Add(comboBox1.SelectedItem.ToString());
            if (comboBox1.SelectedIndex != -1)
            {
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            }

        }

        private void DodajTimB_Click(object sender, EventArgs e)
        {
            ListTimB.Items.Add(comboBox1.SelectedItem.ToString());
            if (comboBox1.SelectedIndex != -1)
            {
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int RezTimA = int.Parse(textBox1.Text.ToString());
            int RezTimB = int.Parse(textBox2.Text.ToString());

            List<string> listA = new List<string>();
            List<string> listB = new List<string>();

            List<int> listGoloviA = new List<int>();
            List<int> listGoloviB = new List<int>();

            foreach (var item in ListTimA.Items)
            {             
                using (var inputBox = new CustomInputBox(item.ToString()))
                {
                    if(inputBox.ShowDialog() == DialogResult.OK)
                    {
                        string userInput = inputBox.UserInput;
                        listGoloviA.Add(Convert.ToInt32(userInput));
                        listA.Add(item.ToString());
                    }
                }
            }

            foreach(var item in ListTimB.Items)
            {
                using (var inputBox = new CustomInputBox(item.ToString()))
                {
                    if (inputBox.ShowDialog() == DialogResult.OK)
                    {
                        string userInput = inputBox.UserInput;
                        listGoloviB.Add(Convert.ToInt32(userInput));
                        listB.Add(item.ToString());
                    }
                }
            }

            DatabaseHelper.SpremiUtakmica(dateTimePicker1.Value, RezTimA, RezTimB, listA, listB, listGoloviA, listGoloviB);

            this.Close();
        }       
    }
}
