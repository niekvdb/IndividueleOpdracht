using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuele_Opdracht
{
    public class Review
    {
        public Gebruiker Gebruiker { get; set; }
        public DateTime Datum { get; set; }
        public string Tekst { get; set; }
        public string Titel { get; set; }
        public Product Product { get; set; }
        public int Score { get; set; }

        public Review(Gebruiker gebruiker,DateTime datum,string tekst, string titel, Product product,int score)
        {
            this.Gebruiker = gebruiker;
            this.Datum = datum;
            this.Tekst = tekst;
            this.Titel = titel;
            this.Product = product;
            this.Score = score;
        }

       
    }
}