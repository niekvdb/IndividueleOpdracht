using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuele_Opdracht.Classes
{
    public class Vraag
    {
        public Gebruiker Gebruiker { get; set; }
        public DateTime Datum { get; set; }
        public string Tekst { get; set; }
        public string Titel { get; set; }
        public Product Product { get; set; }
        public Antwoord Antwoord { get; set; }

        public Vraag(Gebruiker gebruiker,DateTime datum, string tekst,string titel,Product product)
        {
            this.Gebruiker = gebruiker;
            this.Datum = datum;
            this.Tekst = tekst;
            this.Titel = titel;
            this.Product = product;
        }

        public bool IsBeantwoord()
        {
            if (this.Antwoord == null)
                return false;
            else
                return true;
        }
        public void Beantwoord(Antwoord antwoord)
        {
            this.Antwoord = antwoord;

        }
    }
}