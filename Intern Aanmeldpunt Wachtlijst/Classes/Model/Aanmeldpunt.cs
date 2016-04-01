using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.Model
{
    public class Aanmeldpunt
    {
        public int ID { get; private set; }
        public string Naam { get; private set; }
        public string Adres { get; private set; }
        public int Telefoonnummer { get; private set; }
        public string Email { get; private set; }
        public string Contactpersoon { get; private set; }

        public Aanmeldpunt(int id, string naam, string adres, int telefoonnummer, string email, string contactpersoon)
        {
            ID = id;
            Naam = naam;
            Adres = adres;
            Telefoonnummer = telefoonnummer;
            Email = email;
            Contactpersoon = contactpersoon;
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
