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
using System.Text.Json;

namespace MusicalProject
{
    public partial class Form1 : Form
    {
        //IncipitViewer viewer;
        WindowsMediaPlayer player = new WindowsMediaPlayer();

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

            //carica i brani da file json
            if (System.IO.File.Exists("brani.json"))
            {
                //leggi il file json
                string json = System.IO.File.ReadAllText("brani.json");
                //json deserializzato in lista di brani
                List<Brano> brani = JsonSerializer.Deserialize<List<Brano>>(json);

                //aggiungi i brani alla lista
                foreach (Brano b in brani)
                {
                    ListViewItem item = new ListViewItem(b.Titolo);
                    item.SubItems.Add(b.Artisti);
                    item.SubItems.Add(b.Genere);
                    item.SubItems.Add(b.Datapubblicazione.ToString());
                    item.SubItems.Add(b.Durata.ToString());
                    item.SubItems.Add(b.Descrizione);
                    listView1.Items.Add(item);
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
            Brano b = new Brano("ciao", "ciaone", "artist", "pop", DateTime.Now, 12, "/ciao", new Spartito());
            //serializza il brano in json
            string json = JsonSerializer.Serialize(b);
            //aggiungi il brano al file json
            System.IO.File.AppendAllText("brani.json", json);
            //aggiungi il brano alla lista
            ListViewItem item = new ListViewItem(b.Titolo);
            item.SubItems.Add(b.Artisti);
            item.SubItems.Add(b.Genere);
            item.SubItems.Add(b.Datapubblicazione.ToString());
            item.SubItems.Add(b.Durata.ToString());
            item.SubItems.Add(b.Descrizione);
            listView1.Items.Add(item);
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