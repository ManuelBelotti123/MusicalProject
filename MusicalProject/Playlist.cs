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
        private List<IComponente> _brani;

        //proprerties su una riga
        public string Titolo { get => _titolo; set => _titolo = value; }
        public string Descrizione { get => _descrizione; set => _descrizione = value; }
        public DateTime Datacreazione { get => _datacreazione; set => _datacreazione = value; }
        public List<IComponente> Brani { get => _brani; set => _brani = value; }
         
        //costruttori (dati, vuoto, copia)
        public Playlist(string titolo, string descrizione)
        {
            Titolo = titolo;
            Descrizione = descrizione;
            Datacreazione = DateTime.Now;
            Brani = new List<IComponente>();
        }
        public Playlist()
        {
            Titolo = "";
            Descrizione = "";
            Datacreazione = DateTime.Now;
            Brani = new List<IComponente>();
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
            if (c is Brano)
                Brani.Add(c);
            else
                throw new Exception("Non è possibile aggiungere un oggetto di tipo " + c.GetType().Name + " ad una Playlist");
        }
        public void Remove(IComponente c)
        {
            if (c is Brano)
                Brani.Remove(c);
            else
                throw new Exception("Non è possibile rimuovere un oggetto di tipo " + c.GetType().Name + " da una Playlist");
        }
        public IComponente GetChild(int i)
        {
            if (i >= 0 && i < Brani.Count)
                return Brani[i];
            else
                throw new Exception("Indice non valido");
        }
    }
}
