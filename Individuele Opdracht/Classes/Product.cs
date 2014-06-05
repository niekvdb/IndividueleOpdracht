using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuele_Opdracht
{
    public partial class Product
    {
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public int Score { get; set; }

        public Specificatie Specificatie { get; set; }
        public Review Review { get; set; }
        public Vraag Vraag { get; set; }


        public Product(string naam, double prijs, int score, Specificatie specificatie)
        {
            this.Naam = naam;
            this.Prijs = prijs;
            this.Score = score;         
            this.Specificatie = specificatie;
        }
        public Product(string naam, double prijs, int score)
        {
            this.Naam = naam;
            this.Prijs = prijs;
            this.Score = score;
        }

        public bool OpVoorraad()
        {
            return false;
        }
        public void PlaatsReview(Review review)
        {
            this.Review = review;
        }
        public void PlaatsVraag(Vraag vraag)
        {
            this.Vraag = vraag;
        }

        public override string ToString()
        {
            return "Naam: " + this.Naam + " Prijs: " + this.Prijs + " Score: " + this.Score;
        }
    }
}