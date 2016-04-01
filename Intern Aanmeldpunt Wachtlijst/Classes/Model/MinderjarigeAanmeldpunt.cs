using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.Model
{
    public class MinderjarigeAanmeldpunt
    {
        public Minderjarige Minderjarige { get; private set; }
        public Aanmeldpunt Aanmeldpunt { get; private set; }
        public Consulent Consulent { get; private set; }
        public DateTime DatumAanmelding { get; private set; }
        public DateTime DatumOpneming { get; private set; }

        public MinderjarigeAanmeldpunt(Minderjarige minderjarige, Aanmeldpunt aanmeldpunt, Consulent consulent, DateTime aanmelding)
        {
            Minderjarige = minderjarige;
            Aanmeldpunt = aanmeldpunt;
            Consulent = consulent;
            DatumAanmelding = aanmelding;
        }

        public MinderjarigeAanmeldpunt(Minderjarige minderjarige, Aanmeldpunt aanmeldpunt, Consulent consulent, DateTime aanmelding, DateTime opneming)
        {
            Minderjarige = minderjarige;
            Aanmeldpunt = aanmeldpunt;
            Consulent = consulent;
            DatumAanmelding = aanmelding;
            DatumOpneming = opneming;
        }
    }
}
