namespace Individuele_Opdracht
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Review
    {

        public DateTime Datum { get; set; }
        public string Tekst { get; set; }
        public string Titel { get; set; }

        public int Score { get; set; }

        public Review(DateTime datum,string tekst, string titel, int score)
        {
  
            this.Datum = datum;
            this.Tekst = tekst;
            this.Titel = titel;
            this.Score = score;
        }
        public override string ToString()
        {
            return Environment.NewLine+"REVIEW:" +Environment.NewLine+
                "Titel: " + this.Titel + Environment.NewLine +
                "Datum: " + this.Datum + Environment.NewLine +
                "Tekst: " + this.Tekst + Environment.NewLine +
                "Score: " + this.Score + Environment.NewLine;
  
        }
    }
}