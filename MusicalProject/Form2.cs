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
        private bool vble;

        public Form2(Form1 form1, string json, bool vble)
        {
            InitializeComponent();
            this.form1 = form1;
            lbcp = JsonConvert.DeserializeObject<List<Brano>>(json);
            this.vble = vble;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (vble)
            {
                aggiungibrano.Visible = true;
                modificabrano.Visible = false;
            }
            else
            {
                modificabrano.Visible = true;
                aggiungibrano.Visible = false;
            }
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "mp3 files (*.mp3)|*.mp3";
            openFileDialog1.Title = "Open a mp3 file";
            openFileDialog1.ShowDialog();
        }

        private void aggiungibrano_Click(object sender, EventArgs e)
        {
            //rendi visibile aggiungibrano
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

        private void modificabrano_Click(object sender, EventArgs e)
        {
            //modifica il brano selezionato dalla lista
            //modifica il brano selezionato
            Brano b = lbcp[form1.listView1.SelectedItems[0].Index];
            b.Titolo = titolotext.Text;
            b.Descrizione = desctext.Text;
            b.Artisti = artistitext.Text;
            b.Genere = generetext.Text;
            b.Datapubblicazione = dateTimePicker1.Value;
            b.Durata = int.Parse(duratatext.Text);
            b.Path = openFileDialog1.FileName;

            //serializza la lista in json
            string json = JsonConvert.SerializeObject(lbcp);
            //scrivi il json nel file
            System.IO.File.WriteAllText("brani.json", json);

            //modifica il brano nella listView
            form1.listView1.Items[form1.listView1.SelectedItems[0].Index].Text = b.Titolo;
            form1.listView1.Items[form1.listView1.SelectedItems[0].Index].SubItems[1].Text = b.Descrizione;
            form1.listView1.Items[form1.listView1.SelectedItems[0].Index].SubItems[2].Text = b.Artisti;
            form1.listView1.Items[form1.listView1.SelectedItems[0].Index].SubItems[3].Text = b.Genere;
            form1.listView1.Items[form1.listView1.SelectedItems[0].Index].SubItems[4].Text = b.Datapubblicazione.ToString();
            form1.listView1.Items[form1.listView1.SelectedItems[0].Index].SubItems[5].Text = b.Durata.ToString();

            //chiudi il form
            this.Close();
        }
    }
}
