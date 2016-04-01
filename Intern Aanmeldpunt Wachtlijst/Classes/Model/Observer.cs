using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.Model
{
    public interface Observer
    {
        void UpdateDBConnected(bool connected);
        void UpdateVoorziening();
    }
}
