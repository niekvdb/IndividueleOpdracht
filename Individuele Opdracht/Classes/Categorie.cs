using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuele_Opdracht.Classes
{
    public class Categorie
    {

        public List<Product> Producten { get; set; }
        public string Naam { get; set; }
        public string ParentCategorieNaam { get; set; }

        public Categorie(string naam)
        {
            this.Naam = naam;
        }

        public void StelParentIn(string Parentnaam)
        {
            this.ParentCategorieNaam = Parentnaam;
        }
        
        public void VoegProductToe(Product product)
        {
            this.Producten.Add(product);
        }
    }
}