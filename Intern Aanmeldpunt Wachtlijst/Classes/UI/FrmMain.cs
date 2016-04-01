using Intern_Aanmeldpunt_Wachtlijst.Classes.Controller;
using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using Intern_Aanmeldpunt_Wachtlijst.Classes.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intern_Aanmeldpunt_Wachtlijst
{
    public partial class FrmMain : Form, Observer
    {
        private Controller controller = new Controller();

        public FrmMain()
        {
            InitializeComponent();
            controller.RegisterObserver(this);
            controller.Init();

            Init();
        }

        private void Init()
        {
            btnOverzichtDiensten.PerformClick();
            ResetForm();
            LoadDiensten();
            LoadConsulenten(new List<Consulent>());
            LoadMinderjarigen();
            LoadVoorzieningen();
        }

        private void LoadConsulenten(List<Consulent> consulentLijst)
        {
            cbbAanmelder.Items.Clear();
            if (consulentLijst.Count() == 0)
                consulentLijst = controller.GetAllConsulenten();
            cbbAanmelder.Items.AddRange(consulentLijst.ToArray());
            cbbAanmelder.Refresh();
        }

        private void LoadDiensten()
        {
            List<Dienst> dienstLijst = controller.GetAllDiensten();

            cbbDienst.Items.Clear();
            cbbDienst.Items.AddRange(dienstLijst.ToArray());
            lsvDiensten.Items.AddRange(GetDienstListViewItems<Dienst>(dienstLijst).ToArray());

            cbbDienst.Refresh();
            lsvDiensten.Refresh();
        }

        private List<ListViewItem> GetDienstListViewItems<T>(List<T> itemLijst)
        {
            List<ListViewItem> viewItemList = new List<ListViewItem>();

            foreach (T item in itemLijst)
            {
                string[] row = { item.ToString(), GetMinderjarigenCountPerDienst(itemLijst.IndexOf(item) + 1).ToString() };
                ListViewItem lvi = new ListViewItem(row);
                lvi.Tag = item;
                viewItemList.Add(lvi);
            }

            return viewItemList;
        }

        private int GetMinderjarigenCountPerDienst(int dienstId)
        {
            int minderjarigeCount = 0;

            minderjarigeCount = controller.GetMinderjarigenCountPerDienst(dienstId);

            return minderjarigeCount;
        }

        private void LoadVoorzieningen()
        {
            List<Aanmeldpunt> aanmeldpuntLijst = controller.GetAllAanmeldpunten();
            cbbAanmeldpunt.Items.Clear();
            cbbAanmeldpunt.Items.AddRange(aanmeldpuntLijst.ToArray());
            lsvVoorzieningen.Items.AddRange(GetVoorzieningListViewItems(aanmeldpuntLijst).ToArray());

            cbbAanmeldpunt.Refresh();
            lsvVoorzieningen.Refresh();
        }

        private List<ListViewItem> GetVoorzieningListViewItems(List<Aanmeldpunt> aanmeldpuntLijst)
        {
            List<ListViewItem> itemList = new List<ListViewItem>();

            foreach(Aanmeldpunt ap in aanmeldpuntLijst)
            {
                int aanmeldCount = controller.GetMinderjarigenInAanmeldpunt(ap.ID).Count();
                string[] row = { ap.ToString(), aanmeldCount.ToString() };
                ListViewItem lvi = new ListViewItem(row);
                lvi.Tag = ap;
                itemList.Add(lvi);
            }

            return itemList;
        }
        
        private void LoadMinderjarigen()
        {
            List<Minderjarige> minderjarigeLijst = controller.GetAllMinderjarige();
            lsvMinderjarige.Items.AddRange(GetMinderjarigeListViewItems(minderjarigeLijst).ToArray());
        }

        private List<ListViewItem> GetMinderjarigeListViewItems(List<Minderjarige> minderjarigeLijst)
        {
            List<ListViewItem> itemList = new List<ListViewItem>();

            foreach (Minderjarige mj in minderjarigeLijst)
            {
                int aanmeldingCount = controller.GetMinderjarigeInAanmeldpunten(mj.ID).Count();
                string[] row = new[] { mj.ToString(), aanmeldingCount.ToString() };
                ListViewItem lvi = new ListViewItem(row);
                lvi.Tag = mj;
                itemList.Add(lvi);
            }

            return itemList;
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

        public void UpdateDBConnected(bool connected)
        {
            if (connected)
            {
                icoConnected.Image = Properties.Resources.Connected.ToBitmap();
                icoConnected.Tag = "Connected";
            }
            else
            {
                icoConnected.Image = Properties.Resources.Disconnected.ToBitmap();
                icoConnected.Tag = "Disconnected";
            }   
        }

        private void icoConnected_Click(object sender, EventArgs e)
        {
            if ((string)icoConnected.Tag == "Connected")
            {
                MessageBox.Show("Geconnecteerd met de databank.");
            }
            else
            {
                MessageBox.Show("Niet geconnecteerd met de databank, probeer later opnieuw.");
            }
        }

        private void btnOverzichtDienst_Click(object sender, EventArgs e)
        {
            pnlOverzichtDiensten.Visible = true;
            pnlOverzichtVoorziening.Visible = false;
            pnlOverzichtMinderjarigen.Visible = false;
        }

        private void btnOverzichtAanmeldpunt_Click(object sender, EventArgs e)
        {
            pnlOverzichtVoorziening.Visible = true;
            pnlOverzichtDiensten.Visible = false;
            pnlOverzichtMinderjarigen.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnOverzichtMinderjarigen_Click(object sender, EventArgs e)
        {
            pnlOverzichtVoorziening.Visible = false;
            pnlOverzichtDiensten.Visible = false;
            pnlOverzichtMinderjarigen.Visible = true;
        }

        private void cbbDienst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbDienst.SelectedIndex != -1)
            {
                int idDienst = cbbDienst.SelectedIndex + 1;
                LoadConsulenten(controller.GetConsulentInDienst(idDienst));
            }
        }

        private void lsvDiensten_DoubleClick(object sender, EventArgs e)
        {
            if (lsvDiensten.SelectedItems.Count != 0)
            {
                Dienst selectedDienst = (Dienst)lsvDiensten.SelectedItems[0].Tag;
                FrmDienst frmDienst = new FrmDienst(selectedDienst, controller);
                frmDienst.Show();
            }
        }

        private void btnDienstOpenen_Click(object sender, EventArgs e)
        {
            lsvDiensten_DoubleClick(null, null);
        }

        private void btnOpenMinderjarige_Click(object sender, EventArgs e)
        {
            lsvMinderjarige_DoubleClick(null, null);
        }

        private void lsvMinderjarige_DoubleClick(object sender, EventArgs e)
        {
            if (lsvMinderjarige.SelectedItems.Count != 0)
            {
                Minderjarige minderjarige = (Minderjarige)lsvMinderjarige.SelectedItems[0].Tag;
                FrmMinderjarige frmMinderjarige = new FrmMinderjarige(controller, controller.GetMinderjarigeInAanmeldpunten(minderjarige.ID));
                frmMinderjarige.Show();
            }
        }

        private void lsvVoorzieningen_DoubleClick(object sender, EventArgs e)
        {
            if(lsvVoorzieningen.SelectedItems.Count != 0)
            {
                Aanmeldpunt ap = (Aanmeldpunt)lsvVoorzieningen.SelectedItems[0].Tag;
                FrmVoorziening frmVoorziening = new FrmVoorziening(ap, controller);
                frmVoorziening.Show();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenVoorziening_Click(object sender, EventArgs e)
        {
            lsvVoorzieningen_DoubleClick(null, null);
        }

        public void UpdateVoorziening()
        {
            LoadVoorzieningen();
        }

        private void btnNieuweAanmelding_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
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

                controller.InsertNewAanmelding(new MinderjarigeAanmeldpunt(mj, aanmeldpunt, consulent, datumAanmelding));
                MessageBox.Show("Nieuwe aanmelding is geregistreerd!");
                Init();
            }
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
                if(cbbAanmelder.SelectedItem == null)
                {
                    erpAanmelding.SetError(cbbAanmelder, "Gelieve een consulent te selecteren!");
                    valid = false;
                }
            }   

            return valid;
        }
    }
}
