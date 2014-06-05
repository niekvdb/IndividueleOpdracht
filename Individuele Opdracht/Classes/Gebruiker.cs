using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Individuele_Opdracht.Classes
{
    public class Gebruiker
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }

        public Gebruiker(string voornaam,string achternaam, string email, string wachtwoord)
        {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
            this.Email = email;
            this.Wachtwoord = wachtwoord;
        }

        public override string ToString()
        {
            return this.Voornaam + " " + this.Achternaam;
        }
    }
}