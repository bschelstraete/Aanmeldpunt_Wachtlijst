using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmVoorzieningAanpassen : Form
    {
        private Controller.Controller controller;
        private Aanmeldpunt aanmeldpunt;
        private bool aanpassing = false;
        private bool aanpassingActief = false;
        private string type;

        public FrmVoorzieningAanpassen(Controller.Controller controller, Aanmeldpunt aanmeldpunt, string type)
        {
            InitializeComponent();
            Init(controller, aanmeldpunt);
            this.type = type;
        }

        private void Init(Controller.Controller controller, Aanmeldpunt aanmeldpunt)
        {
            this.controller = controller;
            this.aanmeldpunt = aanmeldpunt;

            if (aanmeldpunt.Actief)
                rbtActief.Checked = true;
            else
                rbtNietActief.Checked = true;

            InitText();
        }

        private void InitText()
        {
            txtNaam.Text = aanmeldpunt.Naam;
            txtAdres.Text = aanmeldpunt.Adres;
            txtTelefoonnummer.Text = aanmeldpunt.Telefoonnummer.ToString();
            txtEmail.Text = aanmeldpunt.Email;
            txtContactpersoon.Text = aanmeldpunt.Contactpersoon;

            aanpassing = false;
            aanpassingActief = false;
        }

        private void EditVoorziening(Aanmeldpunt newVoorziening)
        {
            controller.EditAanmeldpunt(aanmeldpunt, newVoorziening);

            if (aanpassingActief)
            {
                bool actief = rbtActief.Checked;
                controller.SetAanmeldpuntActief(aanmeldpunt, actief);
                MessageBox.Show("Voorziening succesvol aangepast!", "Voorziening aanpassen");
            }
        }

        private void CreateNewVoorziening(Aanmeldpunt newVoorziening)
        {
            controller.AddNewAanmeldpunt(newVoorziening);
            MessageBox.Show("Nieuwe voorziening succesvol toegevoegd!", "Voorziening toevoegen");
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (aanpassing == true)
            {
                int telefoonnummer = 0;

                if (String.IsNullOrEmpty(txtNaam.Text))
                    erpNaam.SetError(txtNaam, "Gelieve een naam in te vullen!");
                else if (!int.TryParse(txtTelefoonnummer.Text, out telefoonnummer))
                {
                    erpNaam.SetError(txtTelefoonnummer, "Gelieve een geldig telefoonnummer in te vullen!");
                }
                else
                {
                    string naam = txtNaam.Text;
                    string adres = txtAdres.Text;
                    string telefoonnummerText = txtTelefoonnummer.Text;
                    string email = txtEmail.Text;
                    string contactpersoon = txtContactpersoon.Text;

                    int.TryParse(telefoonnummerText, out telefoonnummer);

                    bool aanpassingActief = rbtActief.Checked;

                    Aanmeldpunt newAanmeldpunt = new Aanmeldpunt(0, naam, adres, telefoonnummer, email, contactpersoon, aanpassingActief);

                    if (type == "edit")
                        EditVoorziening(newAanmeldpunt);
                    else
                        CreateNewVoorziening(newAanmeldpunt);

                    this.Close();
                }
            }
        }

        private void Text_TextChanged(object sender, EventArgs e)
        {
            aanpassing = true;
        }

        private void Radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            aanpassingActief = true;
        }
    }
}
