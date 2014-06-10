namespace Individuele_Opdracht
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Gebruiker
    {

        public string Wachtwoord { get; set; }
        public string Email { get; set; }

        public Gebruiker(string wachtwoord,string email)
        {

            this.Wachtwoord = wachtwoord;
            this.Email = email;
        }

        public override string ToString()
        {
            return this.Email + " " + this.Wachtwoord;
        }
    }
}