namespace Individuele_Opdracht
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Vraag
    {

        public DateTime Datum { get; set; }
        public string Tekst { get; set; }
        public string Titel { get; set; }
        public Product Product { get; set; }
        public Antwoord Antwoord { get; set; }

        public Vraag(DateTime datum, string tekst,string titel)
        {
            this.Datum = datum;
            this.Tekst = tekst;
            this.Titel = titel;

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

        public override string ToString()
        {
            return Environment.NewLine + "VRAAG:" + Environment.NewLine +
                "Titel: " + this.Titel + Environment.NewLine +
                "Datum: " + this.Datum + Environment.NewLine +
                "Tekst: " + this.Tekst + Environment.NewLine;
        }
    }
}