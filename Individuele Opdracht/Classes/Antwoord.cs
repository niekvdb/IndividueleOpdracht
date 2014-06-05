namespace Individuele_Opdracht
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Antwoord
    {
        public Gebruiker Gebruiker { get; set; }
        public Vraag Vraag { get; set; }
        public string Inhoud { get; set; }
        public DateTime Datum { get; set; }

        public Antwoord(Gebruiker gebruiker,Vraag vraag,string inhoud,DateTime datum)
        {
            this.Gebruiker = gebruiker;
            this.Vraag = vraag;
            this.Inhoud = inhoud;
            this.Datum = datum;
        }

    }
}