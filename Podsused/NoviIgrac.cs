using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podsused
{
    public partial class NoviIgrac : Form
    {
        public NoviIgrac()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Ime = IgracIme.Text;
            string Prezime = IgracPrezime.Text;
            Image Slika = IgracSlika.Image;

            DatabaseHelper.SpremiIgrac(Ime, Prezime, Slika);

            this.Close();
        }

        private void IgracSlikaPretrazi_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            ofd.Title = "Odaberi sliku";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                IgracSlika.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
