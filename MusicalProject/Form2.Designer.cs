namespace MusicalProject
{
    partial class Form2
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
            this.aggiungibrano = new System.Windows.Forms.Button();
            this.titolotext = new System.Windows.Forms.TextBox();
            this.desctext = new System.Windows.Forms.TextBox();
            this.artistitext = new System.Windows.Forms.TextBox();
            this.generetext = new System.Windows.Forms.TextBox();
            this.duratatext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.openfile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.modificabrano = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aggiungibrano
            // 
            this.aggiungibrano.Location = new System.Drawing.Point(322, 335);
            this.aggiungibrano.Name = "aggiungibrano";
            this.aggiungibrano.Size = new System.Drawing.Size(126, 38);
            this.aggiungibrano.TabIndex = 0;
            this.aggiungibrano.Text = "Aggiungi Brano";
            this.aggiungibrano.UseVisualStyleBackColor = true;
            this.aggiungibrano.Click += new System.EventHandler(this.aggiungibrano_Click);
            // 
            // titolotext
            // 
            this.titolotext.Location = new System.Drawing.Point(147, 132);
            this.titolotext.Name = "titolotext";
            this.titolotext.Size = new System.Drawing.Size(100, 26);
            this.titolotext.TabIndex = 1;
            // 
            // desctext
            // 
            this.desctext.Location = new System.Drawing.Point(275, 132);
            this.desctext.Multiline = true;
            this.desctext.Name = "desctext";
            this.desctext.Size = new System.Drawing.Size(100, 26);
            this.desctext.TabIndex = 2;
            // 
            // artistitext
            // 
            this.artistitext.Location = new System.Drawing.Point(401, 132);
            this.artistitext.Name = "artistitext";
            this.artistitext.Size = new System.Drawing.Size(100, 26);
            this.artistitext.TabIndex = 3;
            // 
            // generetext
            // 
            this.generetext.Location = new System.Drawing.Point(520, 132);
            this.generetext.Name = "generetext";
            this.generetext.Size = new System.Drawing.Size(100, 26);
            this.generetext.TabIndex = 4;
            // 
            // duratatext
            // 
            this.duratatext.Location = new System.Drawing.Point(368, 219);
            this.duratatext.Name = "duratatext";
            this.duratatext.Size = new System.Drawing.Size(100, 26);
            this.duratatext.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Titolo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descrizione";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Artisti";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Genere";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Durata";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Path";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(147, 219);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Data Pubblicazione";
            // 
            // openfile
            // 
            this.openfile.Location = new System.Drawing.Point(483, 216);
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(137, 29);
            this.openfile.TabIndex = 15;
            this.openfile.Text = "Carica Brano";
            this.openfile.UseVisualStyleBackColor = true;
            this.openfile.Click += new System.EventHandler(this.openfile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(299, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 37);
            this.label8.TabIndex = 16;
            this.label8.Text = "Dati Brano";
            // 
            // modificabrano
            // 
            this.modificabrano.Location = new System.Drawing.Point(320, 335);
            this.modificabrano.Name = "modificabrano";
            this.modificabrano.Size = new System.Drawing.Size(126, 38);
            this.modificabrano.TabIndex = 17;
            this.modificabrano.Text = "Modifica Brano";
            this.modificabrano.UseVisualStyleBackColor = true;
            this.modificabrano.Click += new System.EventHandler(this.modificabrano_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.modificabrano);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.openfile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.duratatext);
            this.Controls.Add(this.generetext);
            this.Controls.Add(this.artistitext);
            this.Controls.Add(this.desctext);
            this.Controls.Add(this.titolotext);
            this.Controls.Add(this.aggiungibrano);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aggiungibrano;
        private System.Windows.Forms.TextBox titolotext;
        private System.Windows.Forms.TextBox desctext;
        private System.Windows.Forms.TextBox artistitext;
        private System.Windows.Forms.TextBox duratatext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button openfile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox generetext;
        private System.Windows.Forms.Button modificabrano;
    }
}