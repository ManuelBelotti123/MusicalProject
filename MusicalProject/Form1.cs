using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSAMControlLibrary;
using WMPLib;
using Newtonsoft.Json;

namespace MusicalProject
{
    public partial class Form1 : Form
    {
        //IncipitViewer viewer;
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        //lista globale brani
        List<Brano> lbcp = new List<Brano>();

        public Form1()
        {
            InitializeComponent();
            panbrani.Visible = false;
            panspartcanz.Visible = false;
            pancreaspart.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void brani_Click(object sender, EventArgs e)
        {
            //visibile il pannello dei brani
            panspartcanz.Visible = false;
            pancreaspart.Visible = false;
            panbrani.Visible = true;
            listView1.Items.Clear();

            //carica i brani da file json o se file è vuoto
            if (System.IO.File.Exists("brani.json"))
            {
                if (System.IO.File.ReadAllText("brani.json") != "")
                {
                    //leggi il file json
                    string json = System.IO.File.ReadAllText("brani.json");
                    //json deserializzato in lista di brani
                    lbcp = JsonConvert.DeserializeObject<List<Brano>>(json);

                    //aggiungi i brani alla lista
                    foreach (Brano b in lbcp)
                    {
                        //brano
                        ListViewItem item = new ListViewItem(b.Titolo);
                        item.SubItems.Add(b.Descrizione);
                        item.SubItems.Add(b.Artisti);
                        item.SubItems.Add(b.Genere);
                        item.SubItems.Add(b.Datapubblicazione.ToString());
                        item.SubItems.Add(b.Durata.ToString());
                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("File brani.json vuoto");
                }
            }
            else
            {
                //crea un file json vuoto
                System.IO.File.WriteAllText("brani.json", "");
                MessageBox.Show("File brani.json non trovato, creato file vuoto");
            }
        }

        private void aggbrano_Click(object sender, EventArgs e)
        {
            //crea un form per inserire i dati del brano (da fare)
            //crea un nuovo brano
            Brano b = new Brano("ciao", "ciaone", "artist", "pop", DateTime.Now, 12, "", new Spartito());
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
            listView1.Items.Add(item);
        }

        private void rembrano_Click(object sender, EventArgs e)
        {
            //rimuovi il brano selezionato dalla lista
            if (listView1.SelectedItems.Count > 0)
            {
                //rimuovi il brano dalla lista
                lbcp.RemoveAt(listView1.SelectedItems[0].Index);
                //serializza la lista in json
                string json = JsonConvert.SerializeObject(lbcp);
                //scrivi il json nel file
                System.IO.File.WriteAllText("brani.json", json);
                //rimuovi il brano dalla listView
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
            }
            else
            {
                lbcp.RemoveAt(0);
            }
        }

        private void modbrano_Click(object sender, EventArgs e)
        {
            //modifica brano selezionato
            if (listView1.SelectedItems.Count > 0)
            {
                //crea un form per modificare i dati del brano (da fare)
                //modifica il brano selezionato
                Brano b = lbcp[listView1.SelectedItems[0].Index];
                b.Titolo = "modificato";
                //serializza la lista in json
                string json = JsonConvert.SerializeObject(lbcp);
                //scrivi il json nel file
                System.IO.File.WriteAllText("brani.json", json);
                //aggiorna la listView
                listView1.Items[listView1.SelectedItems[0].Index].Text = b.Titolo;
            }
            else
            {
                lbcp.RemoveAt(0);
            }
        }
    }
}

/*
            viewer = new IncipitViewer();
            viewer.Dock = DockStyle.Fill;

            Clef c = new Clef(ClefType.GClef, 2);
            viewer.AddMusicalSymbol(c);

            Note n = new Note("G", 0, 4, MusicalSymbolDuration.Quarter, NoteStemDirection.Up, NoteTieType.None, new List<NoteBeamType>() { NoteBeamType.Single });
            viewer.AddMusicalSymbol(n);

            Note n1 = new Note("B", 0, 4, MusicalSymbolDuration.Sixteenth, NoteStemDirection.Up, NoteTieType.None, new List<NoteBeamType>() { NoteBeamType.Single });
            viewer.AddMusicalSymbol(n1);

            Rest r = new Rest(MusicalSymbolDuration.Quarter);
            viewer.AddMusicalSymbol(r);

            //aggiungi viewer a tabPage1
            Controls.Add(viewer);
*/