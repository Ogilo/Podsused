namespace Podsused
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviIgračToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaUtakmicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.igračaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utakmicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rezultatLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.datumLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajToolStripMenuItem,
            this.pregledToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviIgračToolStripMenuItem,
            this.novaUtakmicaToolStripMenuItem});
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            // 
            // noviIgračToolStripMenuItem
            // 
            this.noviIgračToolStripMenuItem.Name = "noviIgračToolStripMenuItem";
            this.noviIgračToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.noviIgračToolStripMenuItem.Text = "Novi igrač";
            this.noviIgračToolStripMenuItem.Click += new System.EventHandler(this.noviIgračToolStripMenuItem_Click);
            // 
            // novaUtakmicaToolStripMenuItem
            // 
            this.novaUtakmicaToolStripMenuItem.Name = "novaUtakmicaToolStripMenuItem";
            this.novaUtakmicaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.novaUtakmicaToolStripMenuItem.Text = "Nova utakmica";
            this.novaUtakmicaToolStripMenuItem.Click += new System.EventHandler(this.novaUtakmicaToolStripMenuItem_Click);
            // 
            // pregledToolStripMenuItem
            // 
            this.pregledToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.igračaToolStripMenuItem,
            this.utakmicaToolStripMenuItem});
            this.pregledToolStripMenuItem.Name = "pregledToolStripMenuItem";
            this.pregledToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.pregledToolStripMenuItem.Text = "Pregled";
            // 
            // igračaToolStripMenuItem
            // 
            this.igračaToolStripMenuItem.Name = "igračaToolStripMenuItem";
            this.igračaToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.igračaToolStripMenuItem.Text = "Igrača";
            this.igračaToolStripMenuItem.Click += new System.EventHandler(this.igračaToolStripMenuItem_Click);
            // 
            // utakmicaToolStripMenuItem
            // 
            this.utakmicaToolStripMenuItem.Name = "utakmicaToolStripMenuItem";
            this.utakmicaToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.utakmicaToolStripMenuItem.Text = "Utakmica";
            this.utakmicaToolStripMenuItem.Click += new System.EventHandler(this.utakmicaToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zadnje odigrano kolo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-14, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 78);
            this.label2.TabIndex = 3;
            this.label2.Text = "TimA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(437, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 78);
            this.label3.TabIndex = 4;
            this.label3.Text = "TimB";
            // 
            // rezultatLabel
            // 
            this.rezultatLabel.AutoSize = true;
            this.rezultatLabel.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rezultatLabel.Location = new System.Drawing.Point(213, 248);
            this.rezultatLabel.Name = "rezultatLabel";
            this.rezultatLabel.Size = new System.Drawing.Size(333, 78);
            this.rezultatLabel.TabIndex = 5;
            this.rezultatLabel.Text = "Rezultat";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(0, 376);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(168, 175);
            this.listBox1.TabIndex = 6;
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(450, 376);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(168, 175);
            this.listBox2.TabIndex = 7;
            // 
            // datumLabel
            // 
            this.datumLabel.AutoSize = true;
            this.datumLabel.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumLabel.Location = new System.Drawing.Point(185, 376);
            this.datumLabel.Name = "datumLabel";
            this.datumLabel.Size = new System.Drawing.Size(145, 45);
            this.datumLabel.TabIndex = 8;
            this.datumLabel.Text = "Datum";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Podsused.Properties.Resources.Pozadina;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(619, 534);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 560);
            this.Controls.Add(this.datumLabel);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.rezultatLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(634, 599);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(634, 599);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Početna";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviIgračToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaUtakmicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem igračaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utakmicaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label rezultatLabel;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label datumLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

