namespace Podsused
{
    partial class NoviIgrac
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoviIgrac));
            this.IgracIme = new System.Windows.Forms.TextBox();
            this.IgracPrezime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IgracSlikaPretrazi = new System.Windows.Forms.Button();
            this.Unesi = new System.Windows.Forms.Button();
            this.IgracSlika = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IgracSlika)).BeginInit();
            this.SuspendLayout();
            // 
            // IgracIme
            // 
            this.IgracIme.Location = new System.Drawing.Point(12, 28);
            this.IgracIme.Name = "IgracIme";
            this.IgracIme.Size = new System.Drawing.Size(250, 20);
            this.IgracIme.TabIndex = 0;
            // 
            // IgracPrezime
            // 
            this.IgracPrezime.Location = new System.Drawing.Point(12, 76);
            this.IgracPrezime.Name = "IgracPrezime";
            this.IgracPrezime.Size = new System.Drawing.Size(250, 20);
            this.IgracPrezime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prezime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Slika";
            // 
            // IgracSlikaPretrazi
            // 
            this.IgracSlikaPretrazi.Location = new System.Drawing.Point(13, 193);
            this.IgracSlikaPretrazi.Name = "IgracSlikaPretrazi";
            this.IgracSlikaPretrazi.Size = new System.Drawing.Size(250, 23);
            this.IgracSlikaPretrazi.TabIndex = 7;
            this.IgracSlikaPretrazi.Text = "Pretraži sliku...";
            this.IgracSlikaPretrazi.UseVisualStyleBackColor = true;
            this.IgracSlikaPretrazi.Click += new System.EventHandler(this.IgracSlikaPretrazi_Click);
            // 
            // Unesi
            // 
            this.Unesi.Location = new System.Drawing.Point(12, 406);
            this.Unesi.Name = "Unesi";
            this.Unesi.Size = new System.Drawing.Size(250, 32);
            this.Unesi.TabIndex = 8;
            this.Unesi.Text = "Unesi";
            this.Unesi.UseVisualStyleBackColor = true;
            this.Unesi.Click += new System.EventHandler(this.button2_Click);
            // 
            // IgracSlika
            // 
            this.IgracSlika.Location = new System.Drawing.Point(12, 222);
            this.IgracSlika.Name = "IgracSlika";
            this.IgracSlika.Size = new System.Drawing.Size(250, 178);
            this.IgracSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IgracSlika.TabIndex = 9;
            this.IgracSlika.TabStop = false;
            // 
            // NoviIgrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 450);
            this.Controls.Add(this.IgracSlika);
            this.Controls.Add(this.Unesi);
            this.Controls.Add(this.IgracSlikaPretrazi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IgracPrezime);
            this.Controls.Add(this.IgracIme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoviIgrac";
            this.Text = "NoviIgrac";
            ((System.ComponentModel.ISupportInitialize)(this.IgracSlika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IgracIme;
        private System.Windows.Forms.TextBox IgracPrezime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button IgracSlikaPretrazi;
        private System.Windows.Forms.Button Unesi;
        private System.Windows.Forms.PictureBox IgracSlika;
    }
}