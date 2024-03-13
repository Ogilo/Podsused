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
    public partial class CustomInputBox : Form
    {
        public string UserInput {  get; set; }
        public CustomInputBox(string Ime)
        {
            InitializeComponent();
            label1.Text = Ime;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            UserInput = textBoxGolovi.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
