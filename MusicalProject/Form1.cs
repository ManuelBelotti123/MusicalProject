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
//using Manufaktura.Controls.Model;
//using Manufaktura.Controls.Extensions;
//using Manufaktura.Music.Model.MajorAndMinor;
//using Manufaktura.Music.Model;
//using Manufaktura.Controls.Rendering.Common;
//using Manufaktura.Controls.Rendering.Implementations;
//using Manufaktura.Controls.Rendering;
//using Manufaktura.Controls.Parser;
using System.Xml;

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
            viewer.Dock = DockStyle.Fill;

            //aggiungi viewer a tabPage1
            tabPage1.Controls.Add(viewer);
        }

        private void addmusicalsymb_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Barline":
                    //aggiungi una battuta al viewer
                    viewer.AddMusicalSymbol(new Barline());
                    //aggiorna il viewer
                    viewer.Invalidate();
                    break;
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
                    if (bemolle)
                    {
                        ks = new Key(-int.Parse(valnota.Text));
                    }
                    else
                    {
                        ks = new Key(int.Parse(valnota.Text));
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
                case "note":
                    if (valnota.Text != "")
                    {
                        //se combobox bemolle diesis è bemolle = -1, altrimenti = 1, se è vuoto = 0
                        int alterazione;
                        if (diebem.Text == "bemolle")
                        {
                            alterazione = -1;
                        }
                        else if (diebem.Text == "diesis")
                        {
                            alterazione = 1;
                        }
                        else
                        {
                            alterazione = 0;
                        }
                        //durata nota in base al combobox durata
                        MusicalSymbolDuration durata;
                        switch (comboboxdirection.Text)
                        {
                            case "Whole":
                                durata = MusicalSymbolDuration.Whole;
                                break;
                            case "Half":
                                durata = MusicalSymbolDuration.Half;
                                break;
                            case "Quarter":
                                durata = MusicalSymbolDuration.Quarter;
                                break;
                            case "Eighth":
                                durata = MusicalSymbolDuration.Eighth;
                                break;
                            case "Sixteenth":
                                durata = MusicalSymbolDuration.Sixteenth;
                                break;
                            case "Thirty-second":
                                durata = MusicalSymbolDuration.d32nd;
                                break;
                            case "Sixty-fourth":
                                durata = MusicalSymbolDuration.d64th;
                                break;
                            case "Hundred-twenty-eighth":
                                durata = MusicalSymbolDuration.d128th;
                                break;
                            default:
                                durata = MusicalSymbolDuration.Quarter;
                                break;
                        }
                        //notestemdirection in base al combobox stem
                        NoteStemDirection stem;
                        if (comboboxdirection.Text == "up")
                        {
                            stem = NoteStemDirection.Up;
                        }
                        else
                        {
                            stem = NoteStemDirection.Down;
                        }
                        //note tie type in base al combobox tie
                        NoteTieType tie;
                        switch (comboboxtie.Text)
                        {
                            case "None":
                                tie = NoteTieType.None;
                                break;
                            case "Start":
                                tie = NoteTieType.Start;
                                break;
                            case "Stop":
                                tie = NoteTieType.Stop;
                                break;
                            case "StopAndStartAnother":
                                tie = NoteTieType.StopAndStartAnother;
                                break;
                            default:
                                tie = NoteTieType.None;
                                break;
                        }
                        Note n = new Note(valnota.Text, alterazione, int.Parse(ottavanota.Text), durata, stem, tie, new List<NoteBeamType>() { NoteBeamType.Single });
                        if (ischordelement.Text == "Yes")
                        {
                            n.IsChordElement = true;
                        }
                        viewer.AddMusicalSymbol(n);
                    }
                    else
                    {
                        MessageBox.Show("Inserire un valore per la nota");
                    }
                    //aggiorna il viewer
                    viewer.Invalidate();
                    break;
                case "rest":
                    //durata nota in base al combobox durata
                    MusicalSymbolDuration durata1;
                    switch (comboboxdurata.Text)
                    {
                        case "Whole":
                            durata1 = MusicalSymbolDuration.Whole;
                            break;
                        case "Half":
                            durata1 = MusicalSymbolDuration.Half;
                            break;
                        case "Quarter":
                            durata1 = MusicalSymbolDuration.Quarter;
                            break;
                        case "Eighth":
                            durata1 = MusicalSymbolDuration.Eighth;
                            break;
                        case "Sixteenth":
                            durata1 = MusicalSymbolDuration.Sixteenth;
                            break;
                        case "Thirty-second":
                            durata1 = MusicalSymbolDuration.d32nd;
                            break;
                        case "Sixty-fourth":
                            durata1 = MusicalSymbolDuration.d64th;
                            break;
                        case "Hundred-twenty-eighth":
                            durata1 = MusicalSymbolDuration.d128th;
                            break;
                        default:
                            durata1 = MusicalSymbolDuration.Quarter;
                            break;
                    }
                    Rest r = new Rest(durata1);
                    viewer.AddMusicalSymbol(r);
                    //aggiorna il viewer
                    viewer.Invalidate();
                    break;
                case "dot":
                    //punto nota
                    // viewer.AddMusicalSymbol(new Dot());
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

        /*public void AddMusicSymbSpart()
        {
            var score = Score.CreateOneStaffScore(Clef.Alto, new MajorScale(Step.C, false));
            var currentStaff = score.FirstStaff;

            currentStaff.Elements.Add(new TimeSignature(TimeSignatureType.Numbers, 4, 4));
            currentStaff.Elements.AddRange(StaffBuilder
                .FromPitches(Pitch.C4, Pitch.C4, Pitch.C4, Pitch.C4)
                .AddRhythm("16. 32 16 16")
                .ApplyStemDirection(VerticalDirection.Up)
                .Rebeam());
            currentStaff.Elements.AddRange(StaffBuilder
                .FromPitches(Pitch.C4, Pitch.E4, Pitch.G4, Pitch.C4, Pitch.E4, Pitch.G4, Pitch.C4)
                .AddRhythm(16, 32, 16, 32, 8, 8, 16)
                .ApplyStemDirection(VerticalDirection.Up)
                .AddLyrics("Wlazł ko-tek na pło-tek"));

            
            MusicXmlParser musicXmlParser = new MusicXmlParser();
            System.Xml.Linq.XDocument doc = musicXmlParser.ParseBack(score);
            doc.Save("provaxml.xml");

            

            switch (comboBox1.Text)
            {
                case "Barline":
                    break;
                case "clef":
                    break;
                case "key signature":
                    break;
                case "time signature":
                    break;
                case "note":
                    break;
                case "rest":
                default:

                    break;
            }
        }*/

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pancreaspart_Paint(object sender, PaintEventArgs e)
        {

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