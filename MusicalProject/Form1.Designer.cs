namespace MusicalProject
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panbrani = new System.Windows.Forms.Panel();
            this.brani = new System.Windows.Forms.Button();
            this.spartcanz = new System.Windows.Forms.Button();
            this.creaspart = new System.Windows.Forms.Button();
            this.panspartcanz = new System.Windows.Forms.Panel();
            this.pancreaspart = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panbrani.SuspendLayout();
            this.panspartcanz.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1061, 51);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Musical Project";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.creaspart);
            this.panel2.Controls.Add(this.spartcanz);
            this.panel2.Controls.Add(this.brani);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 583);
            this.panel2.TabIndex = 2;
            // 
            // panbrani
            // 
            this.panbrani.Controls.Add(this.panspartcanz);
            this.panbrani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panbrani.Location = new System.Drawing.Point(292, 51);
            this.panbrani.Name = "panbrani";
            this.panbrani.Size = new System.Drawing.Size(769, 583);
            this.panbrani.TabIndex = 3;
            // 
            // brani
            // 
            this.brani.Location = new System.Drawing.Point(18, 19);
            this.brani.Name = "brani";
            this.brani.Size = new System.Drawing.Size(254, 48);
            this.brani.TabIndex = 0;
            this.brani.Text = "I TUOI BRANI";
            this.brani.UseVisualStyleBackColor = true;
            // 
            // spartcanz
            // 
            this.spartcanz.Location = new System.Drawing.Point(18, 73);
            this.spartcanz.Name = "spartcanz";
            this.spartcanz.Size = new System.Drawing.Size(254, 48);
            this.spartcanz.TabIndex = 1;
            this.spartcanz.Text = "SPARTITI E CANZONIERI";
            this.spartcanz.UseVisualStyleBackColor = true;
            // 
            // creaspart
            // 
            this.creaspart.Location = new System.Drawing.Point(18, 127);
            this.creaspart.Name = "creaspart";
            this.creaspart.Size = new System.Drawing.Size(254, 48);
            this.creaspart.TabIndex = 2;
            this.creaspart.Text = "CREA SPARTITO";
            this.creaspart.UseVisualStyleBackColor = true;
            // 
            // panspartcanz
            // 
            this.panspartcanz.Controls.Add(this.pancreaspart);
            this.panspartcanz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panspartcanz.Location = new System.Drawing.Point(0, 0);
            this.panspartcanz.Name = "panspartcanz";
            this.panspartcanz.Size = new System.Drawing.Size(769, 583);
            this.panspartcanz.TabIndex = 0;
            // 
            // pancreaspart
            // 
            this.pancreaspart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pancreaspart.Location = new System.Drawing.Point(0, 0);
            this.pancreaspart.Name = "pancreaspart";
            this.pancreaspart.Size = new System.Drawing.Size(769, 583);
            this.pancreaspart.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 357);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(292, 226);
            this.panel3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Artitsti Canzone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Titolo Canzone";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MusicalProject.Properties.Resources.playsong;
            this.pictureBox1.Location = new System.Drawing.Point(112, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MusicalProject.Properties.Resources.nextsong;
            this.pictureBox2.Location = new System.Drawing.Point(175, 96);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MusicalProject.Properties.Resources.backsong;
            this.pictureBox3.Location = new System.Drawing.Point(49, 96);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 634);
            this.Controls.Add(this.panbrani);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panbrani.ResumeLayout(false);
            this.panspartcanz.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button creaspart;
        private System.Windows.Forms.Button spartcanz;
        private System.Windows.Forms.Button brani;
        private System.Windows.Forms.Panel panbrani;
        private System.Windows.Forms.Panel panspartcanz;
        private System.Windows.Forms.Panel pancreaspart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

