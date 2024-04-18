using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalProject
{
    internal class Cartella : IComponente
    {
        //attributi
        private string _titolo;
        private string _descrizione;
        private DateTime _datacreazione;
        private List<Playlist> _playlists;
        private string _version;

        //properties
        public string Titolo { get => _titolo; set => _titolo = value; }
        public string Descrizione { get => _descrizione; set => _descrizione = value; }
        public DateTime Datacreazione { get => _datacreazione; set => _datacreazione = value; }
        public List<Playlist> Playlists { get => _playlists; set => _playlists = value; }
        public string Version { get => _version; set => _version = value; }

        //costruttori (dati, vuoto, copia)
        public Cartella(string titolo, string descrizione)
        {
            Titolo = titolo;
            Descrizione = descrizione;
            Datacreazione = DateTime.Now;
            Playlists = new List<Playlist>();
            Version = "cartella";
        }
        public Cartella()
        {
            Titolo = "";
            Descrizione = "";
            Datacreazione = DateTime.Now;
            Playlists = new List<Playlist>();
            Version = "cartella";
        }
        public Cartella(Cartella c)
        {
            Titolo = c.Titolo;
            Descrizione = c.Descrizione;
            Datacreazione = c.Datacreazione;
            Playlists = c.Playlists;
            Version = "cartella";
        }

        //metodo ToString
        public override string ToString()
        {
            return "Titolo: " + Titolo + "\nDescrizione: " + Descrizione + "\nData creazione: " + Datacreazione + "\nPlaylists: " + Playlists;
        }

        //metodo Equals
        public override bool Equals(object obj)
        {
            return Equals(obj as Cartella);
        }
        public bool Equals(Cartella c)
        {
            return c != null && Titolo == c.Titolo && Descrizione == c.Descrizione && Datacreazione == c.Datacreazione && Playlists == c.Playlists;
        }

        //metodo GetHashCode (non implementato)
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //metodi IComponente
        public void Add(IComponente c)
        {
            if (c is Playlist)
                Playlists.Add(c as Playlist);
            else
                throw new Exception("Non è possibile aggiungere un oggetto di tipo " + c.GetType().Name + " a una cartella.");
        }
        public void Remove(IComponente c)
        {
            if (c is Playlist)
                Playlists.Remove(c as Playlist);
            else
                throw new Exception("Non è possibile rimuovere un oggetto di tipo " + c.GetType().Name + " da una cartella.");
        }
        public IComponente GetChild(int i)
        {
            if (i >= 0 && i < Playlists.Count)
                return Playlists[i];
            else
                throw new Exception("Non esiste un oggetto in posizione " + i + " nella cartella.");
        }

    }
}
