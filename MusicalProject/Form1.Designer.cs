﻿namespace MusicalProject
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panspartcanz = new System.Windows.Forms.Panel();
            this.pancreaspart = new System.Windows.Forms.Panel();
            this.creaspart = new System.Windows.Forms.Button();
            this.spartcanz = new System.Windows.Forms.Button();
            this.brani = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panbrani = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.testocerca = new System.Windows.Forms.TextBox();
            this.cercabrano = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.titolo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.artisti = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.genere = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.datapubb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durata = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modbrano = new System.Windows.Forms.Button();
            this.rembrano = new System.Windows.Forms.Button();
            this.creacartella = new System.Windows.Forms.Button();
            this.creaplaylist = new System.Windows.Forms.Button();
            this.aggbrano = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panspartcanz.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panbrani.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 51);
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
            this.panel2.Controls.Add(this.panspartcanz);
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
            // panspartcanz
            // 
            this.panspartcanz.Controls.Add(this.pancreaspart);
            this.panspartcanz.Location = new System.Drawing.Point(18, 182);
            this.panspartcanz.Name = "panspartcanz";
            this.panspartcanz.Size = new System.Drawing.Size(242, 155);
            this.panspartcanz.TabIndex = 0;
            // 
            // pancreaspart
            // 
            this.pancreaspart.Location = new System.Drawing.Point(33, 34);
            this.pancreaspart.Name = "pancreaspart";
            this.pancreaspart.Size = new System.Drawing.Size(200, 100);
            this.pancreaspart.TabIndex = 0;
            // 
            // creaspart
            // 
            this.creaspart.Location = new System.Drawing.Point(18, 128);
            this.creaspart.Name = "creaspart";
            this.creaspart.Size = new System.Drawing.Size(254, 48);
            this.creaspart.TabIndex = 2;
            this.creaspart.Text = "CREA SPARTITO";
            this.creaspart.UseVisualStyleBackColor = true;
            // 
            // spartcanz
            // 
            this.spartcanz.Location = new System.Drawing.Point(18, 72);
            this.spartcanz.Name = "spartcanz";
            this.spartcanz.Size = new System.Drawing.Size(254, 48);
            this.spartcanz.TabIndex = 1;
            this.spartcanz.Text = "SPARTITI E CANZONIERI";
            this.spartcanz.UseVisualStyleBackColor = true;
            // 
            // brani
            // 
            this.brani.Location = new System.Drawing.Point(18, 18);
            this.brani.Name = "brani";
            this.brani.Size = new System.Drawing.Size(254, 48);
            this.brani.TabIndex = 0;
            this.brani.Text = "I TUOI BRANI";
            this.brani.UseVisualStyleBackColor = true;
            this.brani.Click += new System.EventHandler(this.brani_Click);
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
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MusicalProject.Properties.Resources.backsong;
            this.pictureBox3.Location = new System.Drawing.Point(51, 135);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MusicalProject.Properties.Resources.nextsong;
            this.pictureBox2.Location = new System.Drawing.Point(177, 135);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MusicalProject.Properties.Resources.playsong;
            this.pictureBox1.Location = new System.Drawing.Point(114, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
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
            this.label2.Location = new System.Drawing.Point(86, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Titolo Canzone";
            // 
            // panbrani
            // 
            this.panbrani.Controls.Add(this.treeView1);
            this.panbrani.Controls.Add(this.label4);
            this.panbrani.Controls.Add(this.testocerca);
            this.panbrani.Controls.Add(this.cercabrano);
            this.panbrani.Controls.Add(this.listView1);
            this.panbrani.Controls.Add(this.modbrano);
            this.panbrani.Controls.Add(this.rembrano);
            this.panbrani.Controls.Add(this.creacartella);
            this.panbrani.Controls.Add(this.creaplaylist);
            this.panbrani.Controls.Add(this.aggbrano);
            this.panbrani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panbrani.Location = new System.Drawing.Point(292, 51);
            this.panbrani.Name = "panbrani";
            this.panbrani.Size = new System.Drawing.Size(768, 583);
            this.panbrani.TabIndex = 3;
            this.panbrani.Paint += new System.Windows.Forms.PaintEventHandler(this.panbrani_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cercare";
            // 
            // testocerca
            // 
            this.testocerca.Location = new System.Drawing.Point(552, 38);
            this.testocerca.Name = "testocerca";
            this.testocerca.Size = new System.Drawing.Size(128, 26);
            this.testocerca.TabIndex = 8;
            // 
            // cercabrano
            // 
            this.cercabrano.Location = new System.Drawing.Point(687, 32);
            this.cercabrano.Name = "cercabrano";
            this.cercabrano.Size = new System.Drawing.Size(40, 35);
            this.cercabrano.TabIndex = 7;
            this.cercabrano.Text = "Cerca Brano";
            this.cercabrano.UseVisualStyleBackColor = true;
            this.cercabrano.Click += new System.EventHandler(this.cercabrano_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titolo,
            this.desc,
            this.artisti,
            this.genere,
            this.datapubb,
            this.durata});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(390, 89);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(336, 395);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // titolo
            // 
            this.titolo.Text = "Titolo";
            this.titolo.Width = 76;
            // 
            // desc
            // 
            this.desc.Text = "Descrizione";
            this.desc.Width = 124;
            // 
            // artisti
            // 
            this.artisti.Text = "Artisti";
            this.artisti.Width = 73;
            // 
            // genere
            // 
            this.genere.Text = "Genere";
            this.genere.Width = 87;
            // 
            // datapubb
            // 
            this.datapubb.Text = "Data Pubblicazione";
            this.datapubb.Width = 157;
            // 
            // durata
            // 
            this.durata.Text = "Durata";
            this.durata.Width = 103;
            // 
            // modbrano
            // 
            this.modbrano.Location = new System.Drawing.Point(340, 32);
            this.modbrano.Name = "modbrano";
            this.modbrano.Size = new System.Drawing.Size(146, 35);
            this.modbrano.TabIndex = 4;
            this.modbrano.Text = "Modifica Brano";
            this.modbrano.UseVisualStyleBackColor = true;
            this.modbrano.Click += new System.EventHandler(this.modbrano_Click);
            // 
            // rembrano
            // 
            this.rembrano.Location = new System.Drawing.Point(190, 32);
            this.rembrano.Name = "rembrano";
            this.rembrano.Size = new System.Drawing.Size(146, 35);
            this.rembrano.TabIndex = 3;
            this.rembrano.Text = "Rimuovi Brano";
            this.rembrano.UseVisualStyleBackColor = true;
            this.rembrano.Click += new System.EventHandler(this.rembrano_Click);
            // 
            // creacartella
            // 
            this.creacartella.Location = new System.Drawing.Point(390, 505);
            this.creacartella.Name = "creacartella";
            this.creacartella.Size = new System.Drawing.Size(146, 35);
            this.creacartella.TabIndex = 2;
            this.creacartella.Text = "Crea Cartella";
            this.creacartella.UseVisualStyleBackColor = true;
            this.creacartella.Click += new System.EventHandler(this.creacartella_Click);
            // 
            // creaplaylist
            // 
            this.creaplaylist.Location = new System.Drawing.Point(225, 505);
            this.creaplaylist.Name = "creaplaylist";
            this.creaplaylist.Size = new System.Drawing.Size(146, 35);
            this.creaplaylist.TabIndex = 1;
            this.creaplaylist.Text = "Crea Playlist";
            this.creaplaylist.UseVisualStyleBackColor = true;
            this.creaplaylist.Click += new System.EventHandler(this.creaplaylist_Click);
            // 
            // aggbrano
            // 
            this.aggbrano.Location = new System.Drawing.Point(46, 32);
            this.aggbrano.Name = "aggbrano";
            this.aggbrano.Size = new System.Drawing.Size(136, 35);
            this.aggbrano.TabIndex = 0;
            this.aggbrano.Text = "Aggiungi Brano";
            this.aggbrano.UseVisualStyleBackColor = true;
            this.aggbrano.Click += new System.EventHandler(this.aggbrano_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(46, 89);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(325, 395);
            this.treeView1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 634);
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
            this.panspartcanz.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panbrani.ResumeLayout(false);
            this.panbrani.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Button creacartella;
        private System.Windows.Forms.Button creaplaylist;
        private System.Windows.Forms.Button aggbrano;
        private System.Windows.Forms.Button modbrano;
        private System.Windows.Forms.Button rembrano;
        private System.Windows.Forms.ColumnHeader titolo;
        private System.Windows.Forms.ColumnHeader desc;
        private System.Windows.Forms.ColumnHeader artisti;
        private System.Windows.Forms.ColumnHeader genere;
        private System.Windows.Forms.ColumnHeader datapubb;
        private System.Windows.Forms.ColumnHeader durata;
        private System.Windows.Forms.Button cercabrano;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox testocerca;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.TreeView treeView1;
    }
}

