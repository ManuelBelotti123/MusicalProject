using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalProject
{
    internal class Playlist : IComponente
    {
        //attributi
        private string _titolo;
        private string _descrizione;
        private DateTime _datacreazione;
        private List<Brano> _brani;

        //proprerties su una riga
        public string Titolo { get => _titolo; set => _titolo = value; }
        public string Descrizione { get => _descrizione; set => _descrizione = value; }
        public DateTime Datacreazione { get => _datacreazione; set => _datacreazione = value; }
        public List<Brano> Brani { get => _brani; set => _brani = value; }
         
        //costruttori (dati, vuoto, copia)
        public Playlist(string titolo, string descrizione, DateTime datacreazione, List<Brano> brani)
        {
            Titolo = titolo;
            Descrizione = descrizione;
            Datacreazione = datacreazione;
            Brani = brani;
        }
        public Playlist()
        {
            Titolo = "";
            Descrizione = "";
            Datacreazione = DateTime.Now;
            Brani = new List<Brano>();
        }
        public Playlist(Playlist p)
        {
            Titolo = p.Titolo;
            Descrizione = p.Descrizione;
            Datacreazione = p.Datacreazione;
            Brani = p.Brani;
        }

        //metodo ToString
        public override string ToString()
        {
            return "Titolo: " + Titolo + "\nDescrizione: " + Descrizione + "\nData creazione: " + Datacreazione + "\nBrani: " + Brani;
        }

        //metodo Equals
        public override bool Equals(object obj)
        {
            return Equals(obj as Playlist);
        }
        public bool Equals(Playlist p)
        {
            return Titolo == p.Titolo && Descrizione == p.Descrizione && Datacreazione == p.Datacreazione && Brani == p.Brani;
        }

        //metodo GetHashCode (non implementato)
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //metodi IComponente
        public void Add(IComponente c)
        {
            Brani.Add((Brano)c);
        }
        public void Remove(IComponente c)
        {
            Brani.Remove((Brano)c);
        }
        public void GetChild(int i)
        {
            Brani[i].ToString();
        }
    }
}
