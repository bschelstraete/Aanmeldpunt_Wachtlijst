using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.Model
{
    public class Consulent
    {
        public int ID { get; private set; }
        public string Naam { get; private set; }
        public string Voornaam { get; private set; }
        public bool Actief { get; set; }

        public Consulent(int id, string naam, string voornaam)
        {
            ID = id;
            Naam = naam;
            Voornaam = voornaam;
        }

        public override string ToString()
        {
            return Voornaam + " " + Naam;
        }
    }
}
