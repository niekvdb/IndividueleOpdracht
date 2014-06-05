namespace Individuele_Opdracht
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Categorie
    {

        public List<Product> Producten { get; set; }
        public string Naam { get; set; }
        public string ParentCategorieNaam { get; set; }

        public Categorie(string naam)
        {
            this.Naam = naam;
        }

        public void StelParentIn(string parentnaam)
        {
            this.ParentCategorieNaam = parentnaam;
        }
        
        public void Voegproductoe(Product product)
        {
            this.Producten.Add(product);
        }
    }
}