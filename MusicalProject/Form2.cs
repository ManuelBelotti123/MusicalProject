using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MusicalProject
{
    public partial class Form2 : Form
    {

        private Form1 form1;
        private List<Brano> lbcp;

        public Form2(Form1 form1, string json)
        {
            InitializeComponent();
            this.form1 = form1;
            lbcp = JsonConvert.DeserializeObject<List<Brano>>(json);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void openfile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "mp3 files (*.mp3)|*.mp3";
            openFileDialog1.Title = "Open a mp3 file";
            openFileDialog1.ShowDialog();
        }

        private void aggiungibrano_Click(object sender, EventArgs e)
        {
            //if tutti i campi sono pieni and
            if (titolotext.Text != "" && desctext.Text != "" && artistitext.Text != "" && generetext.Text != "" && duratatext.Text != "" && openFileDialog1.FileName != "")
            {
                Brano b = new Brano(titolotext.Text, desctext.Text, artistitext.Text, generetext.Text, dateTimePicker1.Value, int.Parse(duratatext.Text), openFileDialog1.FileName, new Spartito());
                lbcp.Add(b);
                //serializza la lisra in json with newtonsoft
                string json = JsonConvert.SerializeObject(lbcp);

                //scrivi il json nel file
                System.IO.File.WriteAllText("brani.json", json);

                //aggiungi il brano alla lista
                ListViewItem item = new ListViewItem(b.Titolo);
                item.SubItems.Add(b.Descrizione);
                item.SubItems.Add(b.Artisti);
                item.SubItems.Add(b.Genere);
                item.SubItems.Add(b.Datapubblicazione.ToString());
                item.SubItems.Add(b.Durata.ToString());
                form1.listView1.Items.Add(item);

                //chiudi il form
                this.Close();
            }
            else
            {
                MessageBox.Show("Inserire tutti i campi");
            }
        }
    }
}
