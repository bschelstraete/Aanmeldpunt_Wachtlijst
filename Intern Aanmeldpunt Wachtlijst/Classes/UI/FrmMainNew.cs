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
using System.Windows.Forms.VisualStyles;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmMainNew : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private Label activeBtn = new Label();

        private Controller.Controller controller = new Controller.Controller();
        private List<Consulent> consulentLijst = new List<Consulent>();
        private List<Dienst> dienstLijst = new List<Dienst>();
        private List<Aanmeldpunt> aanmeldpuntLijst = new List<Aanmeldpunt>();
        private List<Minderjarige> minderjarigeLijst = new List<Minderjarige>();
        private List<MinderjarigeAanmeldpunt> alleAanmeldingen = new List<MinderjarigeAanmeldpunt>();

        public FrmMainNew()
        {
            InitializeComponent();
            InitSidebar();
            InitLists();
            InitComboBox();
            InitOverzichtAanmeldingen();
        }

        #region Layout
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
                ((Label)sender).BackColor = Color.FromArgb(230, 230, 230);
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
            minderjarigeLijst = controller.GetAllMinderjarige();
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
            dgvAanmeldingen.Rows.Clear();

            minderjarigeLijst.OrderBy(x => x.Naam).ThenBy(x => x.Voornaam).ToList();
            foreach (Minderjarige mj in minderjarigeLijst)
            {
                List<MinderjarigeAanmeldpunt> mja = controller.GetMinderjarigeInAanmeldpunten(mj.ID);
                alleAanmeldingen.AddRange(mja);
            }

            foreach (MinderjarigeAanmeldpunt mja in alleAanmeldingen)
            {
                string mjNaam = mja.Minderjarige.Naam + " " + mja.Minderjarige.Voornaam;
                string cNaam = mja.Consulent.Naam + " " + mja.Consulent.Voornaam;
                Dienst aanmeldDienst = controller.GetDienstVanConsulent(mja.Consulent.ID);
                string[] row = { mjNaam, mja.Aanmeldpunt.Naam, cNaam, aanmeldDienst.Naam,
                                mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString() };
                //dgvAanmeldingen.Rows.Add(row);
            }
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
                    foreach(MinderjarigeAanmeldpunt mja in minderjarigeResults)
                    {
                        string mjNaam = mja.Minderjarige.Naam + " " + mja.Minderjarige.Voornaam;
                        string cNaam = mja.Consulent.Naam + " " + mja.Consulent.Voornaam;
                        Dienst aanmeldDienst = controller.GetDienstVanConsulent(mja.Consulent.ID);
                        string[] row = { mjNaam, mja.Aanmeldpunt.Naam, cNaam, aanmeldDienst.Naam,
                                mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString() };
                        //dgvAanmeldingen.Rows.Add(row);
                    }
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

        private void pnlNewAanmelding_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
