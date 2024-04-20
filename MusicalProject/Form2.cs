using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        private List<IComponente> lbcp;
        private bool vble;
        private int typeaggmod;

        public Form2(Form1 form1, bool vble, int typeaggmod)
        {
            InitializeComponent();
            this.form1 = form1;
            string json = System.IO.File.ReadAllText("brani.json");
            //json deserializzato in lista di brani
            lbcp = new List<IComponente>();
            if (System.IO.File.ReadAllText("brani.json") != "")
            {
                lbcp = JsonConvert.DeserializeObject<List<IComponente>>(json);
            }
            this.vble = vble;
            this.typeaggmod = typeaggmod;
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
            if (typeaggmod == 1) //se è un brano
            {
                //se tutti i campi sono compilati, allora aggiungi il brano alla treeView
                //se il path del file non è mp3
                if (titolotext.Text != "" && desctext.Text != "" && artistitext.Text != "" && generetext.Text != "" && duratatext.Text != "" && openFileDialog1.FileName.EndsWith(".mp3"))
                {
                    //crea un nuovo brano
                    Brano b = new Brano(titolotext.Text, desctext.Text, artistitext.Text, generetext.Text, dateTimePicker1.Value, int.Parse(duratatext.Text), openFileDialog1.FileName, new Spartito());
                    //se il branoplaylist.Text è vuoto, allora aggiungi il brano alla lista
                    if (branoplaylist.Text == "")
                    {
                        lbcp.Add(b);
                        //aggiungi il brano alla treeView
                        form1.treeView1.Nodes.Add(new TreeNode(b.Titolo));
                    }
                    else
                    {
                        //altrimenti cerca la playlist, sia tra le cartelle che nella lista e aggiungi il brano alla playlist
                        foreach (IComponente c in lbcp)
                        {
                            if (c is Cartella)
                            {
                                Cartella cr = ((Cartella)c);
                                foreach (Playlist p in cr.Playlists)
                                {
                                    if (p.Titolo == branoplaylist.Text)
                                    {
                                        p.Add(b);
                                        //aggiungi il brano alla treeView
                                        foreach (TreeNode tn in form1.treeView1.Nodes)
                                        {
                                            if (tn.Text == cr.Titolo)
                                            {
                                                foreach (TreeNode tn2 in tn.Nodes)
                                                {
                                                    if (tn2.Text == branoplaylist.Text)
                                                    {
                                                        tn2.Nodes.Add(new TreeNode(b.Titolo));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (c is Playlist)
                            {
                                Playlist p = ((Playlist)c);
                                if (p.Titolo == branoplaylist.Text)
                                {
                                    p.Add(b);
                                    foreach (TreeNode tn in form1.treeView1.Nodes)
                                    {
                                        if (tn.Text == branoplaylist.Text)
                                        {
                                            tn.Nodes.Add(new TreeNode(b.Titolo));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //serializza la lista in json
                    string json = JsonConvert.SerializeObject(lbcp);
                    //scrivi il json nel file
                    System.IO.File.WriteAllText("brani.json", json);
                    //chiudi il form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Compilare tutti i campi");
                }
            }
            else if (typeaggmod == 2) //se è una playlist
            {
                //se tutti i campi sono compilati, allora aggiungi la playlist alla treeView
                if (titolotext.Text != "" && desctext.Text != "")
                {
                    //crea una nuova playlist
                    Playlist p = new Playlist(titolotext.Text, desctext.Text);
                    //aggiungi la playlist alla lista o alla cartella specificata
                    if (branoplaylist.Text == "")
                    {
                        lbcp.Add(p);
                        //aggiungi la playlist alla treeView di form1
                        form1.treeView1.Nodes.Add(new TreeNode(p.Titolo));
                    }
                    else
                    {
                        foreach (IComponente c in lbcp)
                        {
                            if (c is Cartella)
                            {
                                Cartella cr = ((Cartella)c);
                                if (cr.Titolo == branoplaylist.Text)
                                {
                                    cr.Add(p);
                                    foreach (TreeNode tn in form1.treeView1.Nodes)
                                    {
                                        if (tn.Text == branoplaylist.Text)
                                        {
                                            tn.Nodes.Add(new TreeNode(p.Titolo));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //serializza la lista in json
                    string json = JsonConvert.SerializeObject(lbcp);
                    //scrivi il json nel file
                    System.IO.File.WriteAllText("brani.json", json);
                    //chiudi il form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Compilare tutti i campi");
                }
            }
            else if (typeaggmod == 3)
            {
                //se tutti i campi sono compilati, allora aggiungi la cartella alla treeView
                if (titolotext.Text != "" && desctext.Text != "")
                {
                    //crea una nuova cartella
                    Cartella cr = new Cartella(titolotext.Text, desctext.Text);
                    //aggiungi la cartella alla lista
                    lbcp.Add(cr);
                    //serializza la lista in json
                    string json = JsonConvert.SerializeObject(lbcp);
                    //scrivi il json nel file
                    System.IO.File.WriteAllText("brani.json", json);
                    //aggiungi la cartella alla treeView di form1
                    form1.treeView1.Nodes.Add(new TreeNode(cr.Titolo));
                    //chiudi il form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Compilare tutti i campi");
                }
            }
        }

        private void modificabrano_Click(object sender, EventArgs e)
        {
            //modifica il brano selezionato dalla lista (errore index)
            //selectedItems[0].Index non funziona
            //modifica il brano selezionato dalla lista
            IComponente br = lbcp[form1.listView1.SelectedItems[0].Index];
            Brano b = (Brano)br;
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
