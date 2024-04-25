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
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Newtonsoft.Json;
using MusicalProject.Properties;

namespace MusicalProject
{
    public partial class Form1 : Form
    {
        //IncipitViewer viewer;
        //Naudio variables
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;

        //spartito crea
        IncipitViewer viewer;

        //lista globale brani
        List<IComponente> lbcp = new List<IComponente>();
 

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
            treeView1.Nodes.Clear();

            //carica i brani da file json o se file è vuoto
            if (System.IO.File.Exists("brani.json"))
            {
                if (System.IO.File.ReadAllText("brani.json") != "")
                {
                    //json deserializzato in lista di IComponente
                    lbcp = JsonConvert.DeserializeObject<List<IComponente>>(System.IO.File.ReadAllText("brani.json"));
                    //aggiungi i brani alla treeView
                    foreach (IComponente c in lbcp)
                    {
                        //se è una Cartella
                        if (c is Cartella)
                        {
                            Cartella cr = ((Cartella)c);
                            TreeNode tn = new TreeNode(cr.Titolo);
                            treeView1.Nodes.Add(tn);
                            //aggiungi nei figli le playlist al suo interno
                            foreach (Playlist p in cr.Playlists)
                            {
                                TreeNode tn1 = new TreeNode(p.Titolo);
                                tn.Nodes.Add(tn1);
                                //per ogni playlist aggiungi i brani al suo interno
                                foreach (Brano b in p.Brani)
                                {
                                    TreeNode tn2 = new TreeNode(b.Titolo);
                                    tn1.Nodes.Add(tn2);
                                }
                            }
                        }
                        //se è una playlist
                        else if (c is Playlist)
                        {
                            Playlist p = ((Playlist)c);
                            TreeNode tn = new TreeNode(p.Titolo);
                            treeView1.Nodes.Add(tn);
                            //aggiungi nei figli i brani al suo interno
                            foreach (Brano b in p.Brani)
                            {
                                TreeNode tn1 = new TreeNode(b.Titolo);
                                tn.Nodes.Add(tn1);
                            }
                        }
                        //se è un brano
                        else if (c is Brano)
                        {
                            TreeNode tn = new TreeNode(((Brano)c).Titolo);
                            treeView1.Nodes.Add(tn);
                        }
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
            //apri form 2 per inserire i dati del Brano
            Form2 f2 = new Form2(this, true, 1);
            f2.ShowDialog(); 
        }

        private void rembrano_Click(object sender, EventArgs e)
        {
            //rimuovi il brano selezionato dalla treeView
            if (treeView1.SelectedNode != null)
            {
                //cerca il brano selezionato nella lista
                foreach (IComponente c in lbcp)
                {
                    if (c is Brano)
                    {
                        Brano b = ((Brano)c);
                        if (b.Titolo == treeView1.SelectedNode.Text)
                        {
                            lbcp.Remove(b);
                            treeView1.Nodes.Remove(treeView1.SelectedNode);
                            break;
                        }
                    }
                    else if (c is Cartella)
                    {
                        Cartella cr = ((Cartella)c);
                        foreach (Playlist p in cr.Playlists)
                        {
                            if (p.Titolo == treeView1.SelectedNode.Text)
                            {
                                cr.Playlists.Remove(p);
                                treeView1.Nodes.Remove(treeView1.SelectedNode);
                                break;
                            }
                            else
                            {
                                foreach (Brano b in p.Brani)
                                {
                                    if (b.Titolo == treeView1.SelectedNode.Text)
                                    {
                                        p.Brani.Remove(b);
                                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (c is Playlist)
                    {
                        Playlist p = ((Playlist)c);
                        if (p.Titolo == treeView1.SelectedNode.Text)
                        {
                            lbcp.Remove(p);
                            treeView1.Nodes.Remove(treeView1.SelectedNode);
                            break;
                        }
                        else
                        {
                            foreach (Brano b in p.Brani)
                            {
                                if (b.Titolo == treeView1.SelectedNode.Text)
                                {
                                    p.Brani.Remove(b);
                                    treeView1.Nodes.Remove(treeView1.SelectedNode);
                                    break;
                                }
                            }
                        }
                    }
                }
                //serializza la lista in json
                string json = JsonConvert.SerializeObject(lbcp);
                //scrivi il json nel file
                System.IO.File.WriteAllText("brani.json", json);
            }
            else
            {
                MessageBox.Show("Selezionare un brano da rimuovere");
            }
        }

        private void modbrano_Click(object sender, EventArgs e)
        {
            //modifica brano selezionato dalla listView chiamando form2
            if (listView1.SelectedItems.Count > 0)
            {
                //cerca il brano selezionato nella lista
                foreach (IComponente c in lbcp)
                {
                    if (c is Brano)
                    {
                        Brano b = ((Brano)c);
                        if (b.Titolo == listView1.SelectedItems[0].Text)
                        {
                            //apri form 2 per inserire i dati del Brano
                            Form2 f2 = new Form2(this, false, 1);
                            f2.ShowDialog();
                            break;
                        }
                    }
                    else if (c is Cartella)
                    {
                        Cartella cr = ((Cartella)c);
                        foreach (Playlist p in cr.Playlists)
                        {
                            if (p.Titolo == listView1.SelectedItems[0].Text)
                            {
                                //apri form 2 per inserire i dati della Playlist
                                Form2 f2 = new Form2(this, false, 2);
                                f2.ShowDialog();
                                break;
                            }
                            else
                            {
                                foreach (Brano b in p.Brani)
                                {
                                    if (b.Titolo == listView1.SelectedItems[0].Text)
                                    {
                                        //apri form 2 per inserire i dati del Brano
                                        Form2 f2 = new Form2(this, false, 1);
                                        f2.ShowDialog();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (c is Playlist)
                    {
                        Playlist p = ((Playlist)c);
                        if (p.Titolo == listView1.SelectedItems[0].Text)
                        {
                            //apri form 2 per inserire i dati della Playlist
                            Form2 f2 = new Form2(this, false, 2);
                            f2.ShowDialog();
                            break;
                        }
                        else
                        {
                            foreach (Brano b in p.Brani)
                            {
                                if (b.Titolo == listView1.SelectedItems[0].Text)
                                {
                                    //apri form 2 per inserire i dati del Brano
                                    Form2 f2 = new Form2(this, false, 1);
                                    f2.ShowDialog();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selezionare un brano da modificare");
            }
        }
        private void cercabrano_Click(object sender, EventArgs e)
        {
            //cerca brano nella lista e stampa i risultati con nella listView
            //aggiorna il file json e la lista
            lbcp = JsonConvert.DeserializeObject<List<IComponente>>(System.IO.File.ReadAllText("brani.json"));
            listView1.Items.Clear();
            if (testocerca.Text != "")
            {
                foreach (IComponente c in lbcp)
                {
                    if (c is Brano)
                    {
                        Brano b = ((Brano)c);
                        //se tutti i campi di brano contengono testocerca.Text
                        if (b.Titolo.Contains(testocerca.Text) || b.Descrizione.Contains(testocerca.Text) || b.Artisti.Contains(testocerca.Text) || b.Genere.Contains(testocerca.Text) || b.Datapubblicazione.ToString().Contains(testocerca.Text) || b.Durata.ToString().Contains(testocerca.Text))
                        {
                            //aggiungi alla listView
                            ListViewItem lvi = new ListViewItem(b.Titolo);
                            lvi.SubItems.Add(b.Descrizione);
                            lvi.SubItems.Add(b.Artisti);
                            lvi.SubItems.Add(b.Genere);
                            lvi.SubItems.Add(b.Datapubblicazione.ToString());
                            lvi.SubItems.Add(b.Durata.ToString());
                            listView1.Items.Add(lvi);
                        }
                    }
                    else if (c is Playlist)
                    {
                        //cerca in tutti i brani della playlist in tutti i campi, se contengono testocerca.Text allora aggiungi la playlist alla listView
                        Playlist p = ((Playlist)c);
                        foreach (Brano b in p.Brani)
                        {
                            if (b.Titolo.Contains(testocerca.Text) || b.Descrizione.Contains(testocerca.Text) || b.Artisti.Contains(testocerca.Text) || b.Genere.Contains(testocerca.Text) || b.Datapubblicazione.ToString().Contains(testocerca.Text) || b.Durata.ToString().Contains(testocerca.Text))
                            {
                                ListViewItem lvi = new ListViewItem(b.Titolo);
                                lvi.SubItems.Add(b.Descrizione);
                                lvi.SubItems.Add(b.Artisti);
                                lvi.SubItems.Add(b.Genere);
                                lvi.SubItems.Add(b.Datapubblicazione.ToString());
                                lvi.SubItems.Add(b.Durata.ToString());
                                listView1.Items.Add(lvi);
                            }
                        }
                    }
                    else if (c is Cartella)
                    {
                        //cerca nelle cartelle e nelle playlist in tutti i campi, se contengono testocerca.Text allora aggiungi la cartella alla listView
                        Cartella cr = ((Cartella)c);
                        foreach (Playlist p in cr.Playlists)
                        {
                            foreach (Brano b in p.Brani)
                            {
                                if (b.Titolo.Contains(testocerca.Text) || b.Descrizione.Contains(testocerca.Text) || b.Artisti.Contains(testocerca.Text) || b.Genere.Contains(testocerca.Text) || b.Datapubblicazione.ToString().Contains(testocerca.Text) || b.Durata.ToString().Contains(testocerca.Text))
                                {
                                    ListViewItem lvi = new ListViewItem(b.Titolo);
                                    lvi.SubItems.Add(b.Descrizione);
                                    lvi.SubItems.Add(b.Artisti);
                                    lvi.SubItems.Add(b.Genere);
                                    lvi.SubItems.Add(b.Datapubblicazione.ToString());
                                    lvi.SubItems.Add(b.Durata.ToString());
                                    listView1.Items.Add(lvi);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void panbrani_Paint(object sender, PaintEventArgs e)
        {

        }

        private void creaplaylist_Click(object sender, EventArgs e)
        {
            //apri form 2 per inserire i dati della Playlist
            //1 brano, 2 playlist, 3 cartella
            Form2 f2 = new Form2(this, true, 2);
            f2.ShowDialog();
        }

        private void creacartella_Click(object sender, EventArgs e)
        {
            //apri form 2 per inserire i dati della Cartella
            //1 brano, 2 playlist, 3 cartella
            Form2 f2 = new Form2(this, true, 3);
            f2.ShowDialog();
        }

        private void playbrano_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //seleziona il brano e riproduci con windowsmediaplayer, se si riclicca sul picturebox si ferma la riproduzione
            if (listView1.SelectedItems.Count > 0)
            {
                //cerca il brano selezionato nella lista
                foreach (IComponente c in lbcp)
                {
                    if (c is Brano)
                    {
                        Brano b = ((Brano)c);
                        if (b.Titolo == listView1.SelectedItems[0].Text)
                        {
                            labeltitolo.Text = b.Titolo;
                            labelartisti.Text = b.Artisti;
                            PlayMedia(b.Path);
                            break;
                        }
                    }
                    else if (c is Cartella)
                    {
                        Cartella cr = ((Cartella)c);
                        foreach (Playlist p in cr.Playlists)
                        {
                            foreach (Brano b in p.Brani)
                            {
                                if (b.Titolo == listView1.SelectedItems[0].Text)
                                {
                                    labeltitolo.Text = b.Titolo;
                                    labelartisti.Text = b.Artisti;
                                    PlayMedia(b.Path);
                                    break;
                                }
                            }
                        }
                    }
                    else if (c is Playlist)
                    {
                        Playlist p = ((Playlist)c);
                        foreach (Brano b in p.Brani)
                        {
                            if (b.Titolo == listView1.SelectedItems[0].Text)
                            {
                                labeltitolo.Text = b.Titolo;
                                labelartisti.Text = b.Artisti;
                                PlayMedia(b.Path);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selezionare un brano da riprodurre");
            }
        }

        //metodi di servizio
        public void PlayMedia(string path)
        {
            // se il file audio è nuovo rispetto a quello presente in Naudio
            if (audioFileReader == null || audioFileReader.FileName != path)
            {
                //riproduzione brano path con Naudio
                waveOutDevice = new WaveOut();
                audioFileReader = new AudioFileReader(path);
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();

            }
            else
            {
                // Se il file audio è lo stesso, mette in pausa o riprende la riproduzione in Naudio
                if (waveOutDevice.PlaybackState == PlaybackState.Playing)
                {
                    waveOutDevice.Pause();
                }
                else if (waveOutDevice.PlaybackState == PlaybackState.Paused)
                {
                    waveOutDevice.Play();
                }
            }
        }

        private void creaspart_Click(object sender, EventArgs e)
        {
            //visibilità pannello creazione spartito
            pancreaspart.Visible = true;
            panspartcanz.Visible = false;
            panbrani.Visible = true;

            viewer = new IncipitViewer();

            //aggiungi viewer a tabPage1
            tabPage1.Controls.Add(viewer);
        }

        private void addmusicalsymb_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "clef":
                    Clef c;
                    switch (valnota.Text)
                    {
                        case "C":
                            c = new Clef(ClefType.CClef, 4);
                            viewer.AddMusicalSymbol(c);
                            break;
                        case "F":
                            c = new Clef(ClefType.FClef, 4);
                            viewer.AddMusicalSymbol(c);
                            break;
                        case "G":
                            c = new Clef(ClefType.GClef, 4);
                            viewer.AddMusicalSymbol(c);
                            break;
                        default:
                            MessageBox.Show("Inserire una nota tra C, F, G");
                            break;
                    }
                    //aggiorna il viewer
                    viewer.Invalidate();
                    break;
                case "key signature":
                    bool bemolle;
                    if (diebem.Text == "bemolle")
                    {
                        bemolle = true;
                    }
                    else
                    {
                        bemolle = false;
                    }
                    Key ks;
                    switch (int.Parse(valnota.Text))
                    {
                        case 1:
                            if (bemolle)
                            {
                                ks = new Key(-1);
                                viewer.AddMusicalSymbol(ks);
                            }
                            else
                            {
                                ks = new Key(1);
                                viewer.AddMusicalSymbol(ks);
                            }
                            viewer.AddMusicalSymbol(ks);
                            break;
                        case 2:
                            if (bemolle)
                            {
                                ks = new Key(-2);
                                viewer.AddMusicalSymbol(ks);
                            }
                            else
                            {
                                ks = new Key(2);
                                viewer.AddMusicalSymbol(ks);
                            }
                            viewer.AddMusicalSymbol(ks);
                            break;
                        case 3:
                            if (bemolle)
                            {
                                ks = new Key(-3);
                                viewer.AddMusicalSymbol(ks);
                            }
                            else
                            {
                                ks = new Key(3);
                                viewer.AddMusicalSymbol(ks);
                            }
                            viewer.AddMusicalSymbol(ks);
                            break;
                        case 4:
                            ks = new Key(4);
                            viewer.AddMusicalSymbol(ks);
                            break;
                        case 5:
                            if (bemolle)
                            {
                                ks = new Key(-5);
                                viewer.AddMusicalSymbol(ks);
                            }
                            else
                            {
                                ks = new Key(5);
                                viewer.AddMusicalSymbol(ks);
                            }
                            viewer.AddMusicalSymbol(ks);
                            break;
                        case 6:
                            if (bemolle)
                            {
                                ks = new Key(-6);
                                viewer.AddMusicalSymbol(ks);
                            }
                            else
                            {
                                ks = new Key(6);
                                viewer.AddMusicalSymbol(ks);
                            }
                            viewer.AddMusicalSymbol(ks);
                            break;
                        case 7:
                            if (bemolle)
                            {
                                ks = new Key(-7);
                                viewer.AddMusicalSymbol(ks);
                            }
                            else
                            {
                                ks = new Key(7);
                                viewer.AddMusicalSymbol(ks);
                            }
                            viewer.AddMusicalSymbol(ks);
                            break;
                        default:
                            MessageBox.Show("Inserire un valore tra 1 e 7");
                            break;
                    }
                    //aggiorna il viewer
                    viewer.Invalidate();
                    break;
                case "time signature":
                    TimeSignature ts;
                    switch (valnota.Text)
                    {
                        case "2/2":
                            ts = new TimeSignature(TimeSignatureType.Numbers, 2, 2);
                            viewer.AddMusicalSymbol(ts);
                            break;
                        case "2/4":
                            ts = new TimeSignature(TimeSignatureType.Numbers, 2, 4);
                            viewer.AddMusicalSymbol(ts);
                            break;
                        case "3/4":
                            ts = new TimeSignature(TimeSignatureType.Numbers, 3, 4);
                            viewer.AddMusicalSymbol(ts);
                            break;
                        case "4/4":
                            ts = new TimeSignature(TimeSignatureType.Numbers, 4, 4);
                            viewer.AddMusicalSymbol(ts);
                            break;
                        case "3/8":
                            ts = new TimeSignature(TimeSignatureType.Numbers, 3, 8);
                            viewer.AddMusicalSymbol(ts);
                            break;
                        case "6/8":
                            ts = new TimeSignature(TimeSignatureType.Numbers, 6, 8);
                            viewer.AddMusicalSymbol(ts);
                            break;
                        case "9/8":
                            ts = new TimeSignature(TimeSignatureType.Numbers, 9, 8);
                            viewer.AddMusicalSymbol(ts);
                            break;
                        case "12/8":
                            ts = new TimeSignature(TimeSignatureType.Numbers, 12, 8);
                            viewer.AddMusicalSymbol(ts);
                            break;
                        default:
                            MessageBox.Show("Inserire un valore tra 2/2, 2/4, 3/4, 4/4, 3/8, 6/8, 9/8, 12/8");
                            break;
                    }
                    //aggiorna il viewer
                    viewer.Invalidate();
                    break;
                default:
                    break;
            }
        }

        private void remultimaagg_Click(object sender, EventArgs e)
        {
            //rimuovi ultimo simbolo aggiunto
            viewer.RemoveLastMusicalSymbol();
            //aggiorna il viewer
            viewer.Invalidate();
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