﻿using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
        private List<Consulent> alleConsulenten = new List<Consulent>();
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
            controller.RegisterObserver(this);
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
            InitDatagridOVerzichtVoorziening();

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
            pnlEditAanmelding.Parent = this;
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

        private void btnEditConfirm_Hover(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == Color.FromArgb(253, 253, 253))
                ((Label)sender).BackColor = Color.FromArgb(150, 210, 130);
            else
                ((Label)sender).BackColor = Color.FromArgb(253, 253, 253);
        }


        private void btnCancel_Hover(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == Color.FromName("Control"))
                ((Label)sender).BackColor = Color.FromArgb(220, 130, 130);
            else
                ((Label)sender).BackColor = Color.FromName("Control");
        }

        private void btnEditCancel_Hover(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == Color.FromArgb(253, 253, 253))
                ((Label)sender).BackColor = Color.FromArgb(220, 130, 130);
            else
                ((Label)sender).BackColor = Color.FromArgb(253, 253, 253);
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
            consulentLijst.Clear();
            dienstLijst.Clear();
            aanmeldpuntLijst.Clear();

            consulentLijst = controller.GetAllConsulenten();
            alleConsulenten = consulentLijst;
            dienstLijst = controller.GetAllDiensten();
            aanmeldpuntLijst = controller.GetAllAanmeldpunten();
            InitAanmeldingList();
        }

        private void InitAanmeldingList()
        {
            minderjarigeLijst.Clear();
            alleAanmeldingen.Clear();
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
            dvgActive.Rows.Clear();
            int rowCount = 0;
            foreach (MinderjarigeAanmeldpunt mja in aanmeldingen)
            {
                string mjNaam = mja.Minderjarige.Naam + " " + mja.Minderjarige.Voornaam;
                string cNaam = mja.Consulent.Naam + " " + mja.Consulent.Voornaam;
                string datumOpneming = mja.DatumOpneming > new DateTime(1970, 1, 1) ? mja.DatumOpneming.ToShortDateString() : " ";
                Dienst aanmeldDienst = controller.GetDienstVanConsulent(mja.Consulent.ID);
                string[] row = { mjNaam, mja.Aanmeldpunt.Naam, cNaam, aanmeldDienst.Naam,
                                mja.DatumAanmelding.ToShortDateString(), datumOpneming };
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
                InitDatagridViews();
            }
        }

        private void btnClearAanmelding_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        //Begin aanmelding aapassen

        private void btnMJAanmeldingAanpassen_Click(object sender, EventArgs e)
        {
            if (dgvOverzichtMj.SelectedRows.Count > 0)
            {
                editAanmelding = (MinderjarigeAanmeldpunt)dgvOverzichtMj.SelectedRows[0].Tag;
                InitAanmeldingAanpassen(editAanmelding);
                pnlEditAanmelding.BringToFront();
                pnlEditAanmelding.Visible = true;
            }
        }

        private void InitAanmeldingAanpassen(MinderjarigeAanmeldpunt mja)
        {
            cbbMJDienst_SelectedIndexChanged(null, null);

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
                int iDienst = dienstLijst.FindIndex(x => x.Naam == dienst.Naam);
                cbbMJDienst.SelectedItem = dienstLijst[iDienst];


                int iConsulent = consulentLijst.FindIndex(x => x.Naam == mja.Consulent.Naam);
                cbbMJConsulent.SelectedItem = consulentLijst[iConsulent];
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
                    try
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

                        if (editAanmelding.Minderjarige.Naam != naam || editAanmelding.Minderjarige.Voornaam != voornaam)
                        {
                            Minderjarige newMinderjarige = new Minderjarige(editAanmelding.Minderjarige.ID, naam, voornaam);
                            controller.EditMinderjarige(editAanmelding.Minderjarige, newMinderjarige);
                        }


                        MinderjarigeAanmeldpunt newAanmelding = new MinderjarigeAanmeldpunt(editAanmelding.Minderjarige, voorziening, consulent, datumAanmelding, datumOpneming, true);
                        controller.EditAanmelding(editAanmelding, newAanmelding);
                        InitDatagridViews();
                        pnlEditAanmelding.Visible = false;
                        lblEditSaved.Text = "Opgeslaan!";
                        lblEditSaved.ForeColor = Color.DarkGreen;
                        Task.Factory.StartNew(() =>
                            {
                                System.Timers.Timer timer = new System.Timers.Timer();
                                timer.Elapsed += OnTimedEvent;
                                timer.Interval = 10000;
                                timer.Start();
                            }
                        );
                    }
                    catch (Exception)
                    {
                        lblEditSaved.Text = "Fout in het opslaan!";
                        lblEditSaved.ForeColor = Color.DarkRed;
                        Task.Factory.StartNew(() =>
                            {
                                System.Timers.Timer timer = new System.Timers.Timer();
                                timer.Elapsed += OnTimedEvent;
                                timer.Interval = 10000;
                                timer.Start();
                            }
                         );
                    }

                }
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (lblEditSaved.InvokeRequired)
            {
                lblEditSaved.Invoke(new Action(() => lblEditSaved.Text = ""));
            }
            else
                lblEditSaved.Text = "";
            ((System.Timers.Timer)source).Stop();
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
                if (initDone)
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
        //End aanmelding aanpassen

        private void pnlNewAanmelding_Click(object sender, EventArgs e)
        {
            pnlNewAanmelding.Focus();
        }


        //Begin Overzicht voorziening

        private void pnlVoorzieningen_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlVoorzieningen.Visible == true)
            {
                InitOverzichtVoorziening();
            }
        }

        private void InitOverzichtVoorziening()
        {
            pnlDetailVoorziening.Visible = false;
            InitDatagridOVerzichtVoorziening();
            lblOverzichtAverageVoorziening.Text = "Gemiddelde wachttijd voor alle voorzieningen: " + controller.GetAverageWachttijdOverAlleVoorzieningen().ToString("0") + " dagen";
        }

        private void InitDatagridOVerzichtVoorziening()
        {
            int rowCount = 0;
            dgvOverzichtVoorziening.Rows.Clear();
            foreach (Aanmeldpunt voorziening in aanmeldpuntLijst)
            {
                List<MinderjarigeAanmeldpunt> aanmeldingenInVoorziening = controller.GetMinderjarigenInAanmeldpunt(voorziening.ID);
                double averageWachttijd = controller.GetAverageWachtijdMinderjarigen(aanmeldingenInVoorziening);
                string[] row = { voorziening.Naam, aanmeldingenInVoorziening.Count.ToString(), averageWachttijd.ToString("0.##") };
                dgvOverzichtVoorziening.Rows.Add(row);
                dgvOverzichtVoorziening.Rows[rowCount].Tag = aanmeldingenInVoorziening;
                rowCount++;
            }
        }

        private void btnDetailVoorziening_Click(object sender, EventArgs e)
        {
            dgvOverzichtVoorziening_CellMouseDoubleClick(null, null);
        }

        private void dgvOverzichtVoorziening_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvOverzichtVoorziening.SelectedRows.Count > 0)
            {
                if (((List<MinderjarigeAanmeldpunt>)dgvOverzichtVoorziening.SelectedRows[0].Tag).Count() > 0)
                {
                    pnlDetailVoorziening.Visible = true;
                }
            }
        }

        //Begin Detail Voorziening

        private void pnlDetailVoorziening_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlDetailVoorziening.Visible == true)
            {
                InitPnlDetailVoorziening();
            }
        }

        private void InitPnlDetailVoorziening()
        {
            lblDetailVoorziening.Text = "> " + ((List<MinderjarigeAanmeldpunt>)dgvOverzichtVoorziening.SelectedRows[0].Tag)[0].Aanmeldpunt.Naam;
            lblDetailVAantal.Text = "Aantal aanmeldingen: " + ((List<MinderjarigeAanmeldpunt>)dgvOverzichtVoorziening.SelectedRows[0].Tag).Count().ToString();
            lblDetailVAverageWachttijd.Text = "Gemiddeld aantal dagen in registratielijst: " + controller.GetAverageWachtijdMinderjarigen((List<MinderjarigeAanmeldpunt>)dgvOverzichtVoorziening.SelectedRows[0].Tag).ToString("0");
            InitDatagridDetailVoorziening();
        }

        private void InitDatagridDetailVoorziening()
        {
            List<MinderjarigeAanmeldpunt> aanmeldingen = (List<MinderjarigeAanmeldpunt>)dgvOverzichtVoorziening.SelectedRows[0].Tag;
            dgvDetailVoorziening.Rows.Clear();
            int rowCount = 0;
            foreach (MinderjarigeAanmeldpunt mja in aanmeldingen)
            {
                string mjNaam = mja.Minderjarige.Naam + " " + mja.Minderjarige.Voornaam;
                string cNaam = mja.Consulent.Naam + " " + mja.Consulent.Voornaam;
                string datumOpneming = mja.DatumOpneming > new DateTime(1970, 1, 1) ? mja.DatumOpneming.ToShortDateString() : " ";
                Dienst aanmeldDienst = controller.GetDienstVanConsulent(mja.Consulent.ID);
                string[] row = { mjNaam, cNaam, aanmeldDienst.Naam,
                                mja.DatumAanmelding.ToShortDateString(), datumOpneming };
                dgvDetailVoorziening.Rows.Add(row);
                dgvDetailVoorziening.Rows[rowCount].Tag = mja;
                rowCount++;
            }
        }

        private void btnVoorzieningAanmeldingAanpassen_Click(object sender, EventArgs e)
        {
            if (dgvDetailVoorziening.SelectedRows.Count > 0)
            {
                editAanmelding = (MinderjarigeAanmeldpunt)dgvDetailVoorziening.SelectedRows[0].Tag;
                InitAanmeldingAanpassen(editAanmelding);
                pnlEditAanmelding.BringToFront();
                pnlEditAanmelding.Visible = true;

            }
        }

        private void btnVoorzieningAanmeldingToggle_Click(object sender, EventArgs e)
        {
            if (dgvDetailVoorziening.SelectedRows.Count > 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)dgvDetailVoorziening.SelectedRows[0].Tag;
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

        private void btnVoorzieningAanmeldingVerwijderen_Click(object sender, EventArgs e)
        {
            if (dgvDetailVoorziening.SelectedRows.Count > 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)dgvDetailVoorziening.SelectedRows[0].Tag;
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

        private void btnOverzichtVoorziening_Click(object sender, EventArgs e)
        {
            pnlDetailVoorziening.Visible = false;
        }

        private void dgvDetailVoorziening_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVoorzieningAanmeldingAanpassen_Click(btnDetailVAanpassen, null);
        }

        private void dgvAanmeldingen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAanmeldingen.SelectedRows.Count > 0)
            {
                editAanmelding = (MinderjarigeAanmeldpunt)dgvAanmeldingen.SelectedRows[0].Tag;
                InitAanmeldingAanpassen(editAanmelding);
                pnlEditAanmelding.BringToFront();
                pnlEditAanmelding.Visible = true;

            }
        }

        private void btnResetZoeken_Click(object sender, EventArgs e)
        {
            txtZoeken.Text = "";
            InitDatagridViews();
        }


        //End Detail Voorziening

        //End Overzicht voorziening

        //Begin Overzicht Diensten

        private void pnlDiensten_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlDiensten.Visible)
            {
                InitPnlDiensten();
            }
        }

        private void InitPnlDiensten()
        {
            pnlDienstDetail.Visible = false;
            pnlDienstConsulent.Visible = false;
            InitDienstLabels();
            InitDgvDienstAlgemeen();
        }

        private void InitDienstLabels()
        {
            lblDienstAlgemeen.Text = "Aantal aanmeldingen: " + alleAanmeldingen.Count();
            lblDienstGemiddeld.Text = "Gemiddeld aantal dagen in registratielijst: " + controller.GetAverageWachtijdMinderjarigen(alleAanmeldingen).ToString("0.00") + " dagen";
        }

        private void InitDgvDienstAlgemeen()
        {
            dgvDienstAlgemeen.Rows.Clear();
            int rowCount = 0;

            foreach (Dienst dienst in dienstLijst)
            {
                List<MinderjarigeAanmeldpunt> aanmeldingen = controller.GetMinderjarigenInDienst(dienst.ID);
                List<Consulent> consulentInDienst = controller.GetConsulentInDienst(dienst.ID);
                int nrAanmeldingen = aanmeldingen.Count();
                double averageWachttijd = controller.GetAverageWachtijdMinderjarigen(aanmeldingen);
                string[] row = { dienst.Naam, consulentInDienst.Count().ToString(), nrAanmeldingen.ToString(), averageWachttijd.ToString("0.00")};
                dgvDienstAlgemeen.Rows.Add(row);
                dgvDienstAlgemeen.Rows[rowCount].Tag = consulentInDienst;
                rowCount++;
            }
        }

        private void btnDetailDienst_Click(object sender, EventArgs e)
        {
            if(dgvDienstAlgemeen.SelectedRows.Count > 0)
            {
                pnlDienstDetail.Visible = true;
            }
        }

        private void dgvDienstAlgemeen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDetailDienst_Click(null, null);
        }


        //Begin Detail Diensten
        private void btnReturnToDienst_Click(object sender, EventArgs e)
        {
            pnlDienstDetail.Visible = false;
        }

        private void pnlDienstDetail_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlDienstDetail.Visible)
            {
                InitDetailDiensten();
            }
        }

        private void InitDetailDiensten()
        {
            pnlAddNewConsulent.Visible = false;
            List<Consulent> consulentenInDienst = (List <Consulent>)dgvDienstAlgemeen.SelectedRows[0].Tag;
            InitDetailDienstenLabels(consulentenInDienst);
            InitDetailDienstenDatagridView(consulentenInDienst);
        }

        private void InitDetailDienstenLabels(List<Consulent> consulentenInDienst)
        {
            lblDetailDienst.Text = "> " + controller.GetDienstVanConsulent(consulentenInDienst.FirstOrDefault().ID).Naam;
            List<MinderjarigeAanmeldpunt> aanmeldingen = controller.GetMinderjarigenInDienst(controller.GetDienstVanConsulent(consulentenInDienst.FirstOrDefault().ID).ID);
            lblDetailDienstAanmelding.Text = "Aantal aanmeldingen: " + aanmeldingen.Count();
            lblDetailDienstAverage.Text = "Gemiddeld aantal dagen in registratielijst: " + controller.GetAverageWachtijdMinderjarigen(aanmeldingen).ToString("0.00") + " dagen";
        }

        private void InitDetailDienstenDatagridView(List<Consulent> consulentenInDienst)
        {
            int rowCount = 0;
            dgvDetailDienst.Rows.Clear();
            foreach (Consulent cons in consulentenInDienst)
            {
                List<MinderjarigeAanmeldpunt> aanmeldingen = controller.GetMinderjarigenAangemeldDoor(cons.ID);
                string consNaam = cons.Naam + " " + cons.Voornaam;
                int totAanmeldingen = aanmeldingen.Count();
                double averWachttijd = controller.GetAverageWachtijdMinderjarigen(aanmeldingen);

                string[] row = { consNaam, totAanmeldingen.ToString(), averWachttijd.ToString("0.00") };
                dgvDetailDienst.Rows.Add(row);
                dgvDetailDienst.Rows[rowCount].Tag = cons;
                rowCount++;
            }
        }

        private void btnAddConsulent_Click(object sender, EventArgs e)
        {
            List<Consulent> consList = (List<Consulent>)dgvDienstAlgemeen.SelectedRows[0].Tag;
            txtNewConsDienst.Text = controller.GetDienstVanConsulent(consList.FirstOrDefault().ID).ToString();
            pnlAddNewConsulent.Visible = true;
        }

        private void btnCancelConsulent_Click(object sender, EventArgs e)
        {
            pnlAddNewConsulent.Visible = false;
            txtNewConsDienst.Text = "";
            txtNewConsFamilienaam.Text = "";
            txtNewConsVoornaam.Text = "";
        }

        private void btnSaveConsulent_Click(object sender, EventArgs e)
        {
            erpAanmelding.Clear();

            if (String.IsNullOrEmpty(txtNewConsVoornaam.Text))
            {
                erpAanmelding.SetError(txtNewConsVoornaam, "Gelieve een waarde in te vullen");
            }
            else if(String.IsNullOrEmpty(txtNewConsFamilienaam.Text))
            {
                erpAanmelding.SetError(txtNewConsFamilienaam, "Gelieve een waarde in te vullen");
            }
            else
            {
                try
                {
                    string voornaam = txtNewConsVoornaam.Text;
                    string familienaam = txtNewConsFamilienaam.Text;
                    List<Consulent> consList = (List<Consulent>)dgvDienstAlgemeen.SelectedRows[0].Tag;
                    Dienst dienst = controller.GetDienstVanConsulent(consList.FirstOrDefault().ID);

                    controller.AddNewConsulent(voornaam, familienaam, dienst);

                    MessageBox.Show("Opgeslagen!");
                }
                catch(SqlException )
                {
                    MessageBox.Show("Er ging iets verkeerd tijdens het opslaan, probeer later opnieuw");
                }

            }
        }

        private void dgvDetailDienst_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDetailConsulent_Click(null, null);
        }

        private void btnDetailConsulent_Click(object sender, EventArgs e)
        {
            if(dgvDetailDienst.SelectedRows.Count > 0)
            {
                pnlDienstConsulent.Visible = true;
                pnlDienstConsulent.BringToFront();
            }
        }

        //Begin DetailOverzicht Consulent

        private void pnlDienstConsulent_VisibleChanged(object sender, EventArgs e)
        {
            if(pnlDienstConsulent.Visible == true)
            {
                InitPnlDienstConsulent();
            }
        }

        private void InitPnlDienstConsulent()
        {
            Consulent consulent = (Consulent)dgvDetailDienst.SelectedRows[0].Tag;
            InitPnlDienstConsulentLabels(consulent);
            InitPnlDienstDatagridViews(consulent);
        }

        private void InitPnlDienstConsulentLabels(Consulent consulent)
        {
            Dienst dienst = controller.GetDienstVanConsulent(consulent.ID);
            btnReturnToDienstOverzicht.Text = "> " + dienst.Naam;
            lblDetailConsulent.Location = new Point(btnReturnToDienstOverzicht.Location.X + btnReturnToDienstOverzicht.Size.Width + 4, lblDetailConsulent.Location.Y);
            lblDetailConsulent.Text = "> " + consulent.Naam + " " + consulent.Voornaam;
        }

        private void InitPnlDienstDatagridViews(Consulent consulent)
        {
            List<MinderjarigeAanmeldpunt> aanmeldingen = controller.GetMinderjarigenAangemeldDoor(consulent.ID);
            InitDataGrid(dgvConsulentAanmeldingen, aanmeldingen);
        }

        private void btnConsulentAanmAanpassen_Click(object sender, EventArgs e)
        {
            if (dgvConsulentAanmeldingen.SelectedRows.Count > 0)
            {
                editAanmelding = (MinderjarigeAanmeldpunt)dgvConsulentAanmeldingen.SelectedRows[0].Tag;
                InitAanmeldingAanpassen(editAanmelding);
                pnlEditAanmelding.BringToFront();
                pnlEditAanmelding.Visible = true;

            }
        }

        private void btnConsulentAanmToggle_Click(object sender, EventArgs e)
        {

            if (dgvConsulentAanmeldingen.SelectedRows.Count > 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)dgvConsulentAanmeldingen.SelectedRows[0].Tag;
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

        private void btnConsulentAanmDelete_Click(object sender, EventArgs e)
        {

            if (dgvConsulentAanmeldingen.SelectedRows.Count > 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)dgvConsulentAanmeldingen.SelectedRows[0].Tag;
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

        private void btnReturnToDienstenCons_Click(object sender, EventArgs e)
        {
            pnlDienstConsulent.Visible = false;
            pnlDienstDetail.Visible = false;
            pnlDiensten.Visible = true;
            pnlDiensten.BringToFront();
        }

        private void btnReturnToDienstOverzicht_Click(object sender, EventArgs e)
        {
            pnlDienstConsulent.Visible = false;
            pnlDienstDetail.Visible = true;
            pnlDiensten.Visible = true;
            pnlDienstDetail.BringToFront();
        }

        //End Detailoverzicht Consulent

        //End Detail Diensten

        //End Overzicht Diensten

        //Begin Statistics

        private void pnlStatistieken_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlStatistieken.Visible)
            {
                InitStatistics(new DateTime(2000, 01, 01), DateTime.Now);
            }
        }

        private void btnStatToepassen_Click(object sender, EventArgs e)
        {
            DateTime datumVan = dtpVan.Value;
            DateTime datumTot = dtpTot.Value;

            if (datumVan > datumTot)
                MessageBox.Show("Gelieve een begindatum te kiezen die kleiner is dan de einddatum", "Datum selecteren");
            else if (datumVan < datumTot)
            {
                InitStatistics(datumVan, datumTot);
            }
        }

        private void btnStatReset_Click(object sender, EventArgs e)
        {

        }

        private void InitStatistics(DateTime datumVan, DateTime datumTot)
        {
            InitDiensten(datumVan, datumTot);
            InitVoorzieningen(datumVan, datumTot);
            InitWachttijdDiensten(datumVan, datumTot);
            InitWachttijdVoorzieningen(datumVan, datumTot);
        }

        private void InitDiensten(DateTime datumVan, DateTime datumTot)
        {
            List<int> dienstAanmelding = new List<int>();
            List<int> dienstOpneming = new List<int>();
            LoadLijsten<Dienst>(dienstLijst, dienstAanmelding, dienstOpneming, datumVan, datumTot);
            chtDiensten.Text = "Overzicht actieve aanmeldingen in alle diensten";

            if (chtDiensten.Titles.Count == 0)
                chtDiensten.Titles.Add("Overzicht actieve aanmeldingen in alle diensten");
            else
                chtDiensten.Titles[0].Text = "Overzicht actieve aanmeldingen in alle diensten";
            LoadChartAanmelding<Dienst>(dienstLijst, dienstAanmelding, dienstOpneming, chtDiensten);
        }

        private void InitVoorzieningen(DateTime datumVan, DateTime datumTot)
        {
            List<int> voorzieningAanmelding = new List<int>();
            List<int> voorzieningOpneming = new List<int>();
            LoadLijsten<Aanmeldpunt>(aanmeldpuntLijst, voorzieningAanmelding, voorzieningOpneming, datumVan, datumTot);
            chtVoorzieningen.Text = "Overzicht actieve aanmeldingen in alle voorzieningen";

            if (chtVoorzieningen.Titles.Count == 0)
                chtVoorzieningen.Titles.Add("Overzicht actieve aanmeldingen in alle voorzieningen");
            else
                chtVoorzieningen.Titles[0].Text = "Overzicht actieve aanmeldingen in alle voorzieningen";

            LoadChartAanmelding<Aanmeldpunt>(aanmeldpuntLijst, voorzieningAanmelding, voorzieningOpneming, chtVoorzieningen);
        }

        private void InitWachttijdDiensten(DateTime datumVan, DateTime datumTot)
        {
            List<int> dienstAanmelding = new List<int>();
            List<int> dienstOpneming = new List<int>();
            LoadLijsten<Dienst>(dienstLijst, dienstAanmelding, dienstOpneming, datumVan, datumTot);
            chtWachttijdDienst.Text = "Overzicht gemiddelde wachtijd per dienst";

            if (chtWachttijdDienst.Titles.Count == 0)
                chtWachttijdDienst.Titles.Add(chtWachttijdDienst.Text);
            else
                chtWachttijdDienst.Titles[0].Text = "Overzicht gemiddelde wachtijd per dienst";

            LoadChartWachttijd<Dienst>(dienstLijst, dienstAanmelding, dienstOpneming, chtWachttijdDienst);
        }

        private void InitWachttijdVoorzieningen(DateTime datumVan, DateTime datumTot)
        {
            List<int> voorzieningAanmelding = new List<int>();
            List<int> voorzieningOpneming = new List<int>();
            LoadLijsten<Aanmeldpunt>(aanmeldpuntLijst, voorzieningAanmelding, voorzieningOpneming, datumVan, datumTot);
            chtWachttijdVoorziening.Text = "Overzicht gemiddelde wachttijd per voorziening";

            if (chtWachttijdVoorziening.Titles.Count == 0)
                chtWachttijdVoorziening.Titles.Add(chtWachttijdVoorziening.Text);
            else
                chtWachttijdVoorziening.Titles[0].Text = chtWachttijdVoorziening.Text;
            LoadChartWachttijd<Aanmeldpunt>(aanmeldpuntLijst, voorzieningAanmelding, voorzieningOpneming, chtWachttijdVoorziening);
        }


        private void LoadLijsten<T>(List<T> inputList, List<int> aanmeldingCountLijst, List<int> opnemingCountLijst, DateTime datumVan, DateTime datumTot)
        {
            aanmeldingCountLijst.Clear();
            opnemingCountLijst.Clear();

            List<T> objectLijst = inputList;

            foreach (Object item in objectLijst)
            {
                List<MinderjarigeAanmeldpunt> aanmeldingLijst = new List<MinderjarigeAanmeldpunt>();
                if (item.GetType() == typeof(Dienst))
                    aanmeldingLijst = controller.GetMinderjarigeBetweenDatesInDienst(((Dienst)item), datumVan, datumTot);
                if (item.GetType() == typeof(Aanmeldpunt))
                    aanmeldingLijst = controller.GetMinderjarigeBetweenDatesInAanmeldpunt(((Aanmeldpunt)item), datumVan, datumTot);
                int aanmeldingCount = 0;
                int opnemingCount = 0;
                foreach (MinderjarigeAanmeldpunt mja in aanmeldingLijst)
                {
                    if (mja.AanmeldingActief)
                    {
                        aanmeldingCount++;
                        if (mja.DatumOpneming > new DateTime(1970, 1, 1))
                        {
                            opnemingCount++;
                        }
                    }

                }
                aanmeldingCountLijst.Add(aanmeldingCount);
                opnemingCountLijst.Add(opnemingCount);
            }
        }

        private void LoadChartAanmelding<T>(List<T> overzichtLijst, List<int> aanmeldingCount, List<int> opnemingCount, Chart chart)
        {
            chart.Series.Clear();
            chart.Series.Add("Aanmeldingen");
            chart.Series["Aanmeldingen"].Label = "#VALX\n#VALY aanmelding(en)\n#PERCENT";
            chart.Series["Aanmeldingen"].IsVisibleInLegend = false;
            chart.Series["Aanmeldingen"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart.Series["Aanmeldingen"]["PieLabelStyle"] = "Outside";
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;

            for (int i = 0; i < overzichtLijst.Count(); i++)
            {
                if (aanmeldingCount[i] != 0)
                {
                    if (opnemingCount[i] == 0)
                    {
                        Object b = overzichtLijst[i];
                        if (typeof(T) == typeof(Dienst))
                        {
                            Dienst dienst = (Dienst)b;
                            chart.Series["Aanmeldingen"].Points.AddXY(dienst.Naam, aanmeldingCount[i]);
                        }
                        else
                        {
                            Aanmeldpunt ap = (Aanmeldpunt)b;
                            chart.Series["Aanmeldingen"].Points.AddXY(ap.Naam, aanmeldingCount[i]);
                        }
                    }
                }
            }
            chart.Legends.Clear();
            chart.Update();
        }

        private void LoadChartWachttijd<T>(List<T> overzichtLijst, List<int> aanmeldingCount, List<int> opnemeingCount, Chart chart)
        {
            chart.Series.Clear();
            chart.Series.Add("Gemiddelde wachttijd in dagen");
            //chart.Series["Gemiddelde wachttijd in dagen"].Label = "#VALX\n#VALY dagen";
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            //chart.Series["Gemiddelde wachttijd in dagen"].IsVisibleInLegend = false;
            //chart.Series["Gemiddelde wachttijd in dagen"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //chart.Series["Gemiddelde wachttijd in dagen"]["PieLabelStyle"] = "Outside";
            //chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            double totalAverageWachttijd = 0.0;

            for (int i = 0; i < overzichtLijst.Count(); i++)
            {
                if (aanmeldingCount[i] != 0)
                {
                    Object b = overzichtLijst[i];
                    if (typeof(T) == typeof(Dienst))
                    {
                        Dienst dienst = (Dienst)b;
                        List<MinderjarigeAanmeldpunt> aanmeldingen = controller.GetMinderjarigenInDienst(dienst.ID);
                        totalAverageWachttijd += controller.GetAverageWachtijdMinderjarigen(aanmeldingen);
                        double averageWachttijd = controller.GetAverageWachtijdMinderjarigen(aanmeldingen);
                        chart.Series["Gemiddelde wachttijd in dagen"].Points.AddXY(dienst.Naam, Convert.ToInt32(averageWachttijd));
                    }
                    if (typeof(T) == typeof(Aanmeldpunt))
                    {
                        Aanmeldpunt aanmeldpunt = (Aanmeldpunt)b;
                        List<MinderjarigeAanmeldpunt> aanmeldingen = controller.GetMinderjarigenInAanmeldpunt(aanmeldpunt.ID);
                        totalAverageWachttijd += controller.GetAverageWachtijdMinderjarigen(aanmeldingen);
                        double averageWachttijd = controller.GetAverageWachtijdMinderjarigen(aanmeldingen);
                        chart.Series["Gemiddelde wachttijd in dagen"].Points.AddXY(aanmeldpunt.Naam, Convert.ToInt32(averageWachttijd));
                    }
                }
            }

            if (totalAverageWachttijd != 0.0)
            {
                totalAverageWachttijd /= overzichtLijst.Count();
                chart.Titles[0].Text += " - Totale gemiddelde wachttijd: " + totalAverageWachttijd.ToString("0.## dagen");
            }
            chart.Legends.Clear();
            chart.Update();
        }



        //End Statistics
    }
}
