using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.Model
{
    public class ConsulentDienst
    {
        public Consulent Consult { get; private set; }
        public Dienst Dienst { get; private set; }

        public ConsulentDienst(Consulent consulent, Dienst dienst)
        {
            Consult = consulent;
            Dienst = dienst;
        }
    }
}
