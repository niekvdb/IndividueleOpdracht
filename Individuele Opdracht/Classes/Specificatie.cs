namespace Individuele_Opdracht
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Specificatie
    {

        public string Model { get; set; }
        public Product Product { get; set; }
        public string Formaat { get; set; }
        public string Duurzaamheid { get; set; }

        public Specificatie(string model,Product product,string formaat,string duurzaamheid)
        {
            this.Model = model;
            this.Product = product;
            this.Formaat = formaat;
            this.Duurzaamheid = duurzaamheid;
        }
    }
}