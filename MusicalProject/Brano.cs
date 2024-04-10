using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalProject
{
    internal class Brano : IComponente
    {
        //attributi
        private string _titolo;
        private string _descrizione;
        private string _artisti;
        private string _genere;
        private DateTime _datapubblicazione;
        private int _durata;
        private Spartito _spartito;
        
        //properties
        public string Titolo { get => _titolo; set => _titolo = value; }
        public string Descrizione { get => _descrizione; set => _descrizione = value; }
        public string Artisti { get => _artisti; set => _artisti = value; }
        public string Genere { get => _genere; set => _genere = value; }
        public DateTime Datapubblicazione { get => _datapubblicazione; set => _datapubblicazione = value; }
        public int Durata { get => _durata; set => _durata = value; }
        public Spartito Spartito { get => _spartito; set => _spartito = value; }

        //costruttori (dati, vuoto, copia)
        public Brano(string titolo, string descrizione, string artisti, string genere, DateTime datapubblicazione, int durata, Spartito spartito)
        {
            Titolo = titolo;
            Descrizione = descrizione;
            Artisti = artisti;
            Genere = genere;
            Datapubblicazione = datapubblicazione;
            Durata = durata;
            Spartito = spartito;
        }
        public Brano()
        {
            Titolo = "";
            Descrizione = "";
            Artisti = "";
            Genere = "";
            Datapubblicazione = DateTime.Now;
            Durata = 0;
            Spartito = new Spartito();
        }
        public Brano(Brano b)
        {
            Titolo = b.Titolo;
            Descrizione = b.Descrizione;
            Artisti = b.Artisti;
            Genere = b.Genere;
            Datapubblicazione = b.Datapubblicazione;
            Durata = b.Durata;
            Spartito = b.Spartito;
        }

        //metodo ToString
        public override string ToString()
        {
            return "Titolo: " + Titolo + "\nDescrizione: " + Descrizione + "\nArtisti: " + Artisti + "\nGenere: " + Genere + "\nData di pubblicazione: " + Datapubblicazione + "\nDurata: " + Durata + "\nSpartito: " + Spartito;
        }

        //metodi Equals
        public override bool Equals(object obj)
        {
            return Equals(obj as Brano);
        }
        public bool Equals(Brano b)
        {
            return b != null && Titolo == b.Titolo && Descrizione == b.Descrizione && Artisti == b.Artisti && Genere == b.Genere && Datapubblicazione == b.Datapubblicazione && Durata == b.Durata && Spartito == b.Spartito;
        }

        //metodo GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //metodi IComponente
        public void Add(IComponente c)
        {
            throw new NotImplementedException();
        }
        public void Remove(IComponente c)
        {
            throw new NotImplementedException();
        }
        public IComponente GetChild(int i)
        {
            throw new NotImplementedException();
        }

    }
}
