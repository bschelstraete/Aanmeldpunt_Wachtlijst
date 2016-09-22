using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmStatistics : Form
    {
        private Controller.Controller controller;
        private List<Dienst> dienstLijst = new List<Dienst>();
        private List<int> dienstAanmelding = new List<int>();
        private List<int> dienstOpneming = new List<int>();
        private List<Aanmeldpunt> voorzieningLijst = new List<Aanmeldpunt>();
        private List<int> voorzieningAanmelding = new List<int>();
        private List<int> voorzieningOpneming = new List<int>();
        private DateTime datumVan = DateTime.Now;
        private DateTime datumTot = DateTime.Now;

        public FrmStatistics(Controller.Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            Init();
        }

        private void Init()
        {
            //dienstLijst = LoadLijsten<Dienst>(GetDienstLijst, dienstAanmelding, dienstOpneming);
            //voorzieningLijst = LoadLijsten<Aanmeldpunt>(GetVoorzieningLijst, voorzieningAanmelding, voorzieningOpneming);
            //InitDiensten();
            //InitVoorzieningen();
            //InitWachttijdDiensten();
            //InitWachttijdVoorzieningen();
        }

        
        private List<Dienst> GetDienstLijst()
        {
            return controller.GetAllDiensten();
        }

        private List<Aanmeldpunt> GetVoorzieningLijst()
        {
            return controller.GetAllAanmeldpunten();
        }

        

        private void btnToepassen_Click(object sender, EventArgs e)
        {

        }

        private void lblAanmeldingen_Click(object sender, EventArgs e)
        {
            if(splContainerAanmeldingen.Visible)
            {
                lblAanmeldingen.Text = "Statistieken i.v.m. Aanmeldingen    +";
                splContainerAanmeldingen.Visible = false;
            }
            else
            {
                lblAanmeldingen.Text = "Statistieken i.v.m. Aanmeldingen    -";
                splContainerAanmeldingen.Visible = true;
            }
        }

        private void dtpVan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void splContainerAanmeldingen_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void spcAanmeldingen_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void chtDiensten_Click(object sender, EventArgs e)
        {

        }

        private void chtVoorzieningen_Click(object sender, EventArgs e)
        {

        }

        private void spcWachttijd_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void chtWachttijdDienst_Click(object sender, EventArgs e)
        {

        }

        private void chtWachttijdVoorziening_Click(object sender, EventArgs e)
        {

        }
    }
}
