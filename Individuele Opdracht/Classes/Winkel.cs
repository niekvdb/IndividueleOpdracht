namespace Individuele_Opdracht
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Winkel
    {
        public string Naam { get; set; }
        public List<Product> Producten { get; set; }
        public double Verzendkosten { get; set; }

        public Winkel(string naam,double verzendkosten)
        {
            this.Naam = naam;
            this.Verzendkosten = verzendkosten;
        }

        public bool OpVoorraad(Product product)
        {
            return false;
        }
        public bool Bestel(Product product)
        {
            return false;
        }
    }
}