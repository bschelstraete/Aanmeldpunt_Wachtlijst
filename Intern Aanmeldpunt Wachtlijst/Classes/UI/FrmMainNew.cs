using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmMainNew : Form, Observer
    {
        private bool mouseDown;
        private Point lastLocation;
        private List<Panel> containerPanels = new List<Panel>();
        private Label activeBtn = new Label();
        private Panel activePanel = new Panel();

        private Controller.Controller controller = new Controller.Controller();
        private List<Consulent> consulentLijst = new List<Consulent>();
        private List<Dienst> dienstLijst = new List<Dienst>();
        private List<Aanmeldpunt> aanmeldpuntLijst = new List<Aanmeldpunt>();
        private List<Minderjarige> minderjarigeLijst = new List<Minderjarige>();
        private List<MinderjarigeAanmeldpunt> alleAanmeldingen = new List<MinderjarigeAanmeldpunt>();

        //Aanmelding aanpassen
        private bool valueChanged = false;
        private bool initDone = false;
        private MinderjarigeAanmeldpunt editAanmelding = new MinderjarigeAanmeldpunt(null, null, null, new DateTime(1970, 1, 1), false);

        public FrmMainNew()
        {
            InitializeComponent(); 
            InitContainerPanels();
            InitSidebarButtons();
            InitSidebar();
            InitLists();
            InitComboBox();
            InitDatagridViews();
            InitAanmeldingCountLabel();
        }

        public void UpdateDeletedAanmelding()
        {
            InitAanmeldingList();
            InitDatagridViews();
        }

        public void UpdateDBConnected(bool connected)
        {
            //Not yet implemented
            //Will do when login is added
        }

        public void UpdateVoorziening()
        {
            aanmeldpuntLijst = controller.GetAllAanmeldpunten();
            InitVoorzieningCombobox();
        }


        #region Layout

        private void InitDatagridViews()
        {
            InitDataGrid(dgvAanmeldingen, alleAanmeldingen);
            InitDataGrid(dgvOverzichtMj, alleAanmeldingen);            
            
        }

        private void InitSidebarButtons()
        {
            btnNewAanmelding.Tag = pnlNewAanmelding;
            btnDiensten.Tag = pnlDiensten;
            btnVoorzieningen.Tag = pnlVoorzieningen;
            btnMinderjarige.Tag = pnlMinderjarige;
            btnStatistieken.Tag = pnlStatistieken;
        }

        private void InitAanmeldingCountLabel()
        {
            lblMJAantal.Text = "Aantal aanmeldingen: " + alleAanmeldingen.Count();
        }

        private void InitContainerPanels()
        {
            this.DoubleBuffered = true;
            containerPanels.Add(pnlDiensten);
            containerPanels.Add(pnlMinderjarige);
            containerPanels.Add(pnlNewAanmelding);
            containerPanels.Add(pnlStatistieken);
            containerPanels.Add(pnlVoorzieningen);

            foreach (Panel pnl in containerPanels)
                pnl.Visible = false;
        }

        private void TogglePanels(Panel VisiblePanel)
        {
            pnlEditAanmelding.Visible = false;

            if (activePanel != VisiblePanel)
            {
                activePanel.Visible = false;
                VisiblePanel.Visible = true;
                activePanel = VisiblePanel;
            }
        }

        private void btnConfirm_Hover(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == Color.FromName("Control"))
                ((Label)sender).BackColor = Color.FromArgb(150, 210, 130);
            else
                ((Label)sender).BackColor = Color.FromName("Control");
        }

        private void btnCancel_Hover(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == Color.FromName("Control"))
                ((Label)sender).BackColor = Color.FromArgb(220, 130, 130);
            else
                ((Label)sender).BackColor = Color.FromName("Control");
        }

        private void btnContainer_Hover(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == Color.FromName("Control"))
                ((Label)sender).BackColor = Color.FromArgb(220, 220, 220);
            else
                ((Label)sender).BackColor = Color.FromName("Control");
        }

        private void btnFunctions_Mouse(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == Color.FromArgb(253, 253, 253))
                ((Label)sender).BackColor = Color.FromArgb(240, 240, 240);
            else
                ((Label)sender).BackColor = Color.FromArgb(253, 253, 253);
        }

        private void btnNewAanmelding_MouseEnter(object sender, EventArgs e)
        {
            if (activeBtn != (Label)sender)
            {
                if (((Label)sender).BackColor == Color.FromArgb(40, 55, 65))
                    ((Label)sender).BackColor = Color.FromArgb(30, 45, 55);
                else
                    ((Label)sender).BackColor = Color.FromArgb(40, 55, 65);
            }
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSidebar_Click(object sender, EventArgs e)
        {
            if (activeBtn != (Label)sender)
            {
                activeBtn.BackColor = Color.FromArgb(40, 55, 65);
                activeBtn = (Label)sender;
                activeBtn.BackColor = Color.FromArgb(30, 45, 55);
            }
            Label clickedLabel = ((Label)sender);
            lblTitle.Text = clickedLabel.Text;
            TogglePanels((Panel)((Label)sender).Tag);
        }

        #endregion

        private void InitSidebar()
        {
            btnSidebar_Click(btnNewAanmelding, null);
        }


        private void InitLists()
        {
            consulentLijst = controller.GetAllConsulenten();
            dienstLijst = controller.GetAllDiensten();
            aanmeldpuntLijst = controller.GetAllAanmeldpunten();
            InitAanmeldingList();
        }

        private void InitAanmeldingList()
        {
            minderjarigeLijst = controller.GetAllMinderjarige();

            minderjarigeLijst = minderjarigeLijst.OrderBy(x => x.Naam).ThenBy(x => x.Voornaam).ToList();
            foreach (Minderjarige mj in minderjarigeLijst)
            {
                List<MinderjarigeAanmeldpunt> mja = controller.GetMinderjarigeInAanmeldpunten(mj.ID);
                alleAanmeldingen.AddRange(mja);
            }
        }

        private void InitComboBox()
        {
            InitDienstCombobox();
            InitConsulentCombobox();
            InitVoorzieningCombobox();
        }

        private void InitDienstCombobox()
        {
            cbbDienst.Items.Clear();
            cbbDienst.Items.AddRange(dienstLijst.ToArray());
            cbbDienst.Refresh();
        }

        private void InitConsulentCombobox()
        {
            cbbAanmelder.Items.Clear();
            cbbAanmelder.Items.AddRange(consulentLijst.ToArray());
            cbbAanmelder.Refresh();
        }


        private void InitVoorzieningCombobox()
        {
            cbbAanmeldpunt.Items.Clear();
            foreach (Aanmeldpunt ap in aanmeldpuntLijst)
            {
                if (ap.Actief)
                    cbbAanmeldpunt.Items.Add(ap);
            }
            cbbAanmeldpunt.Refresh();
        }

        private void InitDataGrid(DataGridView dvgActive, List<MinderjarigeAanmeldpunt> aanmeldingen)
        {
            int rowCount = 0;
            foreach (MinderjarigeAanmeldpunt mja in aanmeldingen)
            {
                string mjNaam = mja.Minderjarige.Naam + " " + mja.Minderjarige.Voornaam;
                string cNaam = mja.Consulent.Naam + " " + mja.Consulent.Voornaam;
                string datumOpneming = mja.DatumOpneming > new DateTime(1970, 1, 1) ? mja.DatumOpneming.ToShortDateString() : " ";
                Dienst aanmeldDienst = controller.GetDienstVanConsulent(mja.Consulent.ID);
                string[] row = { mjNaam, mja.Aanmeldpunt.Naam, cNaam, aanmeldDienst.Naam,
                                mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString() };
                dvgActive.Rows.Add(row);
                dvgActive.Rows[rowCount].Tag = mja;
                rowCount++;
            }
        }

        private void cbbDienst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDienst.SelectedIndex != -1)
            {
                int idDienst = cbbDienst.SelectedIndex + 1;
                consulentLijst = controller.GetConsulentInDienst(idDienst);
                InitConsulentCombobox();
            }
        }

        private void InitOverzichtAanmeldingen()
        {
            InitDataGrid(dgvAanmeldingen, alleAanmeldingen);
        }

        private void InitOverzichtMinderjarigen()
        {
            InitDataGrid(dgvOverzichtMj, alleAanmeldingen);
        }


        private void btnZoeken_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtZoeken.Text))
            {
                dgvAanmeldingen.Rows.Clear();

                string naamZoeken = txtZoeken.Text;
                List<MinderjarigeAanmeldpunt> minderjarigeResults = controller.FindMinderjarigeAanmelding(naamZoeken);

                if (minderjarigeResults.Count() != 0)
                {
                    InitDataGrid(dgvAanmeldingen, minderjarigeResults);
                }
                else
                    MessageBox.Show("Geen resultaten gevonden!", "Zoekresultaten");
            }
        }

        private void txtZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnZoeken_Click(null, null);
        }

        private void ResetForm()
        {
            txtNaamMJ.Text = "";
            txtVoornaamMJ.Text = "";
            cbbAanmelder.SelectedIndex = -1;
            cbbAanmeldpunt.SelectedIndex = -1;
            cbbDienst.SelectedIndex = -1;
            dtpAanmelddatum.Value = DateTime.Now;
        }

        private bool ValidateForm()
        {
            erpAanmelding.Clear();

            bool valid = true;

            if (String.IsNullOrEmpty(txtNaamMJ.Text))
            {
                erpAanmelding.SetError(txtNaamMJ, "Gelieve een naam in te vullen!");
                valid = false;
            }

            if (String.IsNullOrEmpty(txtVoornaamMJ.Text))
            {
                erpAanmelding.SetError(txtVoornaamMJ, "Gelieve een voornaam in te vullen!");
                valid = false;
            }
            if (cbbAanmeldpunt.SelectedItem == null)
            {
                erpAanmelding.SetError(cbbAanmeldpunt, "Gelieve een aanmeldpunt te kiezen!");
                valid = false;
            }
            if (cbbDienst.SelectedItem != null)
            {
                if (cbbAanmelder.SelectedItem == null)
                {
                    erpAanmelding.SetError(cbbAanmelder, "Gelieve een consulent te selecteren!");
                    valid = false;
                }
            }

            return valid;
        }

        private void btnAddAanmelding_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                DateTime datumAanmelding = dtpAanmelddatum.Value;
                Dienst dienst = (Dienst)cbbDienst.SelectedItem;
                Consulent consulent = (Consulent)cbbAanmelder.SelectedItem;
                Minderjarige mj = controller.GetMinderjarigeByNaam(txtNaamMJ.Text, txtVoornaamMJ.Text);
                if (mj == null)
                {
                    controller.InsertNewMinderjarige(txtNaamMJ.Text, txtVoornaamMJ.Text);
                    mj = controller.GetMinderjarigeByNaam(txtNaamMJ.Text, txtVoornaamMJ.Text);
                }

                Aanmeldpunt aanmeldpunt = (Aanmeldpunt)cbbAanmeldpunt.SelectedItem;

                controller.InsertNewAanmelding(new MinderjarigeAanmeldpunt(mj, aanmeldpunt, consulent, datumAanmelding, true));
                MessageBox.Show("Nieuwe aanmelding is geregistreerd!");
                ResetForm();
                InitOverzichtAanmeldingen();
            }
        }

        private void btnClearAanmelding_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        //Begin aanmelding aapassen

        private void btnMJAanmeldingAanpassen_Click(object sender, EventArgs e)
        {
            if(dgvOverzichtMj.SelectedRows.Count > 0)
            {
                editAanmelding = (MinderjarigeAanmeldpunt)dgvOverzichtMj.SelectedRows[0].Tag;
                InitAanmeldingAanpassen(editAanmelding);
                pnlEditAanmelding.Visible = true;
            }
            
        }

        private void InitAanmeldingAanpassen(MinderjarigeAanmeldpunt mja)
        {
            txtMinderjarigeNaam.Text = mja.Minderjarige.Naam;
            txtMinderjarigeVoornaam.Text = mja.Minderjarige.Voornaam;

            cbbMJDienst.Items.AddRange(dienstLijst.ToArray());
            cbbMJConsulent.Items.AddRange(consulentLijst.ToArray());
            cbbMJVoorziening.Items.AddRange(aanmeldpuntLijst.ToArray());
            dtpAanmelding.Value = mja.DatumAanmelding;

            if (mja.DatumOpneming > new DateTime(1970, 1, 1))
            {
                dtpOpneming.Value = mja.DatumOpneming;
                chkOpgenomen.Checked = true;
            }
            else
            {
                dtpOpneming.Value = DateTime.Now;
                chkOpgenomen.Checked = false;
            }

            if (mja.Consulent.ID != 0)
            {
                Dienst dienst = controller.GetDienstVanConsulent(mja.Consulent.ID);
                int iConsulent = consulentLijst.FindIndex(x => x.Naam == mja.Consulent.Naam);
                int iDienst = dienstLijst.FindIndex(x => x.Naam == dienst.Naam);
                cbbMJConsulent.SelectedItem = consulentLijst[iConsulent];
                cbbMJDienst.SelectedItem = dienstLijst[iDienst];
            }

            int iVoorziening = aanmeldpuntLijst.FindIndex(x => x.Naam == mja.Aanmeldpunt.Naam);
            cbbMJVoorziening.SelectedItem = cbbMJVoorziening.Items[iVoorziening];

            valueChanged = false;
        }

        private void EditAanmeldingChanged(object sender, EventArgs e)
        {
            valueChanged = true;
        }

        private void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            if (valueChanged)
            {
                if (MessageBox.Show("Bent u zeker dat u wilt opslaan?", "Aanmelding aanpassen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string naam = txtMinderjarigeNaam.Text;
                    string voornaam = txtMinderjarigeVoornaam.Text;
                    Consulent consulent = (Consulent)cbbMJConsulent.SelectedItem;
                    Aanmeldpunt voorziening = (Aanmeldpunt)cbbMJVoorziening.SelectedItem;
                    DateTime datumAanmelding = dtpAanmelding.Value;
                    DateTime datumOpneming = new DateTime();

                    if (chkOpgenomen.Checked)
                        datumOpneming = dtpOpneming.Value;
                    else
                        datumOpneming = new DateTime(1960, 1, 1);

                    if(editAanmelding.Minderjarige.Naam != naam || editAanmelding.Minderjarige.Voornaam != voornaam)
                    {
                        Minderjarige newMinderjarige = new Minderjarige(editAanmelding.Minderjarige.ID, naam, voornaam);
                        controller.EditMinderjarige(editAanmelding.Minderjarige, newMinderjarige);
                    }
                     

                    MinderjarigeAanmeldpunt newAanmelding = new MinderjarigeAanmeldpunt(editAanmelding.Minderjarige, voorziening, consulent, datumAanmelding, datumOpneming, true);
                    controller.EditAanmelding(editAanmelding, newAanmelding);
                    pnlEditAanmelding.Visible = false;
                }
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            //Dialogbox is niet nodig (feedback required)
            //DialogResult dialogResult = MessageBox.Show("Bent u zeker dat u wilt annuleren?", "Aanmelding aanpassen", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            pnlEditAanmelding.Visible = false;
        }

        private void cbbMJDienst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMJDienst.SelectedIndex != -1)
            {
                if(initDone)
                {
                    Dienst selectedDienst = (Dienst)cbbMJDienst.SelectedItem;
                    consulentLijst = controller.GetConsulentInDienst(selectedDienst.ID);
                    InitEditConsulentCbb();
                }
            }
            initDone = true;
        }

        private void InitEditConsulentCbb()
        {
            cbbMJConsulent.Items.Clear();
            cbbMJConsulent.Items.AddRange(consulentLijst.ToArray());
        }

        private void btnMjAanmeldingActief_Click(object sender, EventArgs e)
        {
            if (dgvOverzichtMj.SelectedRows.Count > 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)dgvOverzichtMj.SelectedRows[0].Tag;
                string msgString = mja.AanmeldingActief ? msgString = "Bent u zeker dat u de aanmelding op inactief wilt zetten?" : "Bent u zeker dat u de aanmelding op actief wilt zetten?";

                if (MessageBox.Show(msgString, "Aanmelding actief/inactief", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        controller.SetAanmeldingActief(mja, !mja.AanmeldingActief);
                        MessageBox.Show("De aanmelding is gewijzigd.", "Wijziging gelukt!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Er is iets fout gelopen bij het wijzigen van de aanmelding, probeer later eens opnieuw.", "Wijziging mislukt!");
                    }
                }
            }
        }

        private void dgvOverzichtMj_DoubleClick(object sender, EventArgs e)
        {
            btnMJAanmeldingAanpassen_Click(sender, e);
        }

        private void btnMJAanmeldingVerwijderen_Click(object sender, EventArgs e)
        {
            if (dgvOverzichtMj.SelectedRows.Count > 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)dgvOverzichtMj.SelectedRows[0].Tag;
                if (MessageBox.Show("Bent u zeker dat u de aanmelding wilt verwijderen?", "Aanmelding verwijderen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        controller.DeleteAanmelding(mja);
                        MessageBox.Show("De minderjarige is verwijderd.", "Verwijderen gelukt!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Er is iets fout gelopen bij het verwijderen van de aanmelding, probeer later eens opnieuw.", "Verwijderen mislukt!");
                    }
                }
            }
        }

        private void pnlNewAanmelding_Click(object sender, EventArgs e)
        {
            pnlNewAanmelding.Focus();
        }


        //End aanmelding aanpassen
    }
}
