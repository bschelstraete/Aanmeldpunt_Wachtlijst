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
        private Dienst dienst;
        private string type;
        private bool aanpassing = false;
        private bool aanpassingActief = false;

        public FrmConsulentAanpassen(Controller.Controller controller, Consulent consulent, string type)
        {
            InitializeComponent();
            Init(controller, consulent);
            this.type = type;
        }

        private void Init(Controller.Controller controller, Consulent consulent)
        {
            this.controller = controller;
            this.consulent = consulent;
            if(consulent.ID != 0)
            {
                this.dienst = controller.GetDienstVanConsulent(consulent.ID);
            }

            InitForm();
        }

        private void InitForm()
        {
            txtNaam.Text = consulent.Naam;
            txtVoornaam.Text = consulent.Voornaam;
            if (consulent.ID != 0)
            {
                if (consulent.Actief)
                    rbtActief.Checked = true;
                else
                    rbtNietActief.Checked = true;
            }
            else
                rbtActief.Checked = true;


            cbbDienst.Items.AddRange(controller.GetAllDiensten().ToArray());
            if (dienst != null)
            {
                cbbDienst.SelectedIndex = dienst.ID - 1;
            }

            aanpassing = false;
            aanpassingActief = false;
        }

        private void SaveEdit(Consulent newConsulent)
        {
            controller.EditConsulent(consulent, newConsulent);

            if (aanpassingActief)
            {
                bool actief = rbtActief.Checked;
                controller.SetConsulentActief(consulent, aanpassingActief);
                MessageBox.Show("Consulent succesvol aangepast!", "Consulent aanpassen");
            }
        }

        private void CreateNew(Consulent newConsulent, Dienst dienst)
        {
            controller.AddNewConsulent(newConsulent, dienst);
            MessageBox.Show("Nieuwe consulent succesvol toegevoegd!", "Consulent toevoegen");
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            erpNaam.Clear();

            if (aanpassing == true)
            {
                if (String.IsNullOrEmpty(txtNaam.Text))
                    erpNaam.SetError(txtNaam, "Gelieve een naam in te vullen!");
                if (string.IsNullOrEmpty(txtVoornaam.Text))
                    erpNaam.SetError(txtVoornaam, "Gelieve een geldig telefoonnummer in te vullen!");
                if (cbbDienst.SelectedIndex == -1)
                    erpNaam.SetError(cbbDienst, "Gelieve een dienst te selecteren!");


                if (string.IsNullOrEmpty(erpNaam.GetError(txtVoornaam)) && string.IsNullOrEmpty(erpNaam.GetError(txtNaam))
                    && string.IsNullOrEmpty(erpNaam.GetError(cbbDienst)))
                {
                    string naam = txtNaam.Text;
                    string voornaam = txtVoornaam.Text;
                    bool aanpassingActief = rbtActief.Checked;
                    Dienst dienst = (Dienst)cbbDienst.SelectedItem;

                    Consulent newConsulent = new Consulent(0, naam, voornaam);
                    if (type == "edit")
                        SaveEdit(newConsulent);
                    else
                        CreateNew(newConsulent, dienst);

                    this.Close();
                }
            }
        }

        private void rbtActief_CheckedChanged(object sender, EventArgs e)
        {
            aanpassingActief = true;
        }

        private void txtNaam_TextChanged(object sender, EventArgs e)
        {
            aanpassing = true;
        }

        private void cbbDienst_SelectedIndexChanged(object sender, EventArgs e)
        {
            aanpassing = true;
        }

        private void txtVoornaam_TextChanged(object sender, EventArgs e)
        {
            aanpassing = true;
        }
    }
}
