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
    public partial class FrmAanmeldingAanpassen : Form
    {
        private Controller.Controller controller;
        MinderjarigeAanmeldpunt mja;
        private List<Dienst> alleDiensten;
        private List<Consulent> alleConsulenten;
        private List<Aanmeldpunt> alleVoorzieningen;
        private bool valueChanged = false;

        public FrmAanmeldingAanpassen(Controller.Controller controller, MinderjarigeAanmeldpunt mja)
        {
            InitializeComponent();
            this.controller = controller;
            this.mja = mja;
            InitVars();
            InitControls(mja);
        }

        private void InitVars()
        {
            alleDiensten = controller.GetAllDiensten();
            alleConsulenten = controller.GetAllConsulenten();
            alleVoorzieningen = controller.GetAllAanmeldpunten();
        }

        private void InitControls(MinderjarigeAanmeldpunt mja)
        {
            txtMinderjarigeNaam.Text = mja.Minderjarige.Naam;
            txtMinderjarigeVoornaam.Text = mja.Minderjarige.Voornaam;

            cbbDienst.Items.AddRange(alleDiensten.ToArray());
            cbbConsulent.Items.AddRange(alleConsulenten.ToArray());
            cbbVoorziening.Items.AddRange(alleVoorzieningen.ToArray());
            dtpAanmelding.Value = mja.DatumAanmelding;
            if (mja.DatumOpneming > new DateTime(1970, 1, 1))
            {
                dtpOpneming.Value = mja.DatumOpneming;
                chkOpgenomen.Checked = true;
            }
               

            if(mja.Consulent.ID != 0)
            {
                cbbConsulent.SelectedItem = mja.Consulent.ID -1;
                cbbDienst.SelectedItem = controller.GetDienstVanConsulent(mja.Consulent.ID).ID -1;
            }
            cbbVoorziening.SelectedItem = mja.Aanmeldpunt.ID - 1;


            valueChanged = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (valueChanged)
            {
                if (MessageBox.Show("Bent u zeker dat u wilt opslaan?", "Aanmelding aanpassen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string naam = txtMinderjarigeNaam.Text;
                    string voornaam = txtMinderjarigeVoornaam.Text;
                    Consulent consulent = (Consulent)cbbConsulent.SelectedItem;
                    Aanmeldpunt voorziening = (Aanmeldpunt)cbbVoorziening.SelectedItem;
                    DateTime datumAanmelding = dtpAanmelding.Value;
                    DateTime datumOpneming = new DateTime();

                    if (chkOpgenomen.Checked)
                        datumOpneming = dtpOpneming.Value;
                    else
                        datumOpneming = new DateTime(1960, 1, 1);

                    MinderjarigeAanmeldpunt newAanmelding = new MinderjarigeAanmeldpunt(mja.Minderjarige, voorziening, consulent, datumAanmelding, datumOpneming, true);
                    controller.EditAanmelding(mja, newAanmelding);
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bent u zeker dat u wilt sluiten?", "Aanmelding aanpassen", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        private void txtMinderjarigeNaam_TextChanged(object sender, EventArgs e)
        {
            valueChanged = true;
        }

        private void chkOpgenomen_CheckedChanged(object sender, EventArgs e)
        {
            valueChanged = true;
        }
    }
}
