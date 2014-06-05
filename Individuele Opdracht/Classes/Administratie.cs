using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuele_Opdracht
{
    public class Administratie
    {
        public List<Product> Producten { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Vraag> Vragen { get; set; }
        
        public Administratie()
        { }

        public bool VerwijderReview(Review review)
        {
            if(review!=null)
            {
                this.Reviews.Remove(review);
                return true;
            }
            return false;
        }
        public void VoegToe(Review review)
        {
            this.Reviews.Add(review);
  
        }
         public void VoegToe(Product product)
        {
            this.Producten.Add(product);
         }

        public void VerwijderProduct(Product product)
         {
             this.Producten.Remove(product);
         }
        public Product ZoekProduct(string naam)
        {
            foreach (Product product in this.Producten)
                if (product.Naam == naam)
                    return product;

            return null;
        }
    }
}