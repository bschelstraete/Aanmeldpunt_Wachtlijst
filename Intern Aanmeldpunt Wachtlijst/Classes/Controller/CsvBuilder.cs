using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.Controller
{
    public class CsvBuilder
    {
        private Controller controller;

        public CsvBuilder(Controller controller)
        {
            this.controller = controller;
        }

        public void BuildCsv(List<MinderjarigeAanmeldpunt> aanmeldingen, string output)
        {
            using (StreamWriter writer = new StreamWriter(output + "\\RegistratielijstOverzicht.csv"))
            {
                writer.WriteLine("Minderjarigenaam;Consulent;Voorziening;Datum Aanmelding;Datum Begin;Tijd (dagen) in registratielijst");
                foreach (MinderjarigeAanmeldpunt am in aanmeldingen)
                    writer.WriteLine(SerializeAanmelding(am));
            }
        }

        private string SerializeAanmelding(MinderjarigeAanmeldpunt am)
        {
            string csvAanmelding = "";
            string datumOpneming = am.DatumOpneming < new DateTime(1970, 1, 1) ? "" : am.DatumOpneming.ToShortDateString();

            csvAanmelding = am.Minderjarige.Naam + " " + am.Minderjarige.Voornaam + ";"
                            + am.Consulent.Naam + " " + am.Consulent.Voornaam + ";"
                            + am.Aanmeldpunt.Naam + ";"
                            + am.DatumAanmelding.ToShortDateString() + ";"
                            + datumOpneming + ";"
                            + controller.GetWachttijdInDagen(am).ToString("0.##");

            return csvAanmelding;
        }
    }
}
