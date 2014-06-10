namespace Individuele_Opdracht
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public partial class Product
    {
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public int Score { get; set; }

        public Specificatie Specificatie { get; set; }
        public List<Review> Reviews { get; set; }
        public Vraag Vraag { get; set; }
        public Product(string naam, double prijs, int score, Specificatie specificatie)
        {
            this.Naam = naam;
            this.Prijs = prijs;
            this.Score = score;         
            this.Specificatie = specificatie;
            Reviews = new List<Review>();
        }
        public Product(string naam, double prijs, int score)
        {
            this.Naam = naam;
            this.Prijs = prijs;
            this.Score = score;
            Reviews = new List<Review>();
        }

        public bool OpVoorraad()
        {
            return false;
        }
      
        public void PlaatsVraag(Vraag vraag)
        {
            this.Vraag = vraag;
        }

        public override string ToString()
        {
            return "Naam: " + this.Naam + Environment.NewLine +
                "Prijs: " + this.Prijs + Environment.NewLine +
                "Score: " + this.Score + Environment.NewLine;
        }
    }
}