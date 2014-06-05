using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuele_Opdracht
{
    public class Product
    {
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public int Score { get; set; }
        public Categorie Categorie { get; set; }
        public Winkel Winkel { get; set; }
        public Specificatie Specificatie { get; set; }
        public Review Review { get; set; }
        public Vraag Vraag { get; set; }


        public Product(string naam, double prijs, int score, Categorie categorie, Winkel winkel, Specificatie specificatie)
        {
            this.Naam = naam;
            this.Prijs = prijs;
            this.Score = score;
            this.Categorie = categorie;
            this.Winkel = winkel;
            this.Specificatie = specificatie;
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

    }
}