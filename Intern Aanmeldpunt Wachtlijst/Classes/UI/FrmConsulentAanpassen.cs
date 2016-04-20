using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmConsulentAanpassen : Form
    {
        private Controller.Controller controller;
        private Consulent consulent;

        public FrmConsulentAanpassen(Controller.Controller controller, Consulent consulent)
        {
            InitializeComponent();
        }

        private void Init(Controller.Controller controller, Consulent consulent)
        {
            this.controller = controller;
            this.consulent = consulent;
        }

        private void InitForm()
        {
            txtNaam.Text = consulent.Naam;
            txtVoornaam.Text = consulent.Voornaam;
            //if(consulent)

        }


        private void btnOpslaan_Click(object sender, EventArgs e)
        {

        }
    }
}
