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
        private List<Consulent> consulentLijst = new List<Consulent>();
        private List<Dienst> dienstLijst = new List<Dienst>();
        private List<Aanmeldpunt> aanmeldpuntLijst = new List<Aanmeldpunt>();
        private List<Minderjarige> minderjarigeLijst = new List<Minderjarige>();

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
            InitListViews();
            InitComboBox();
        }

        private void InitLists()
        {
            consulentLijst = controller.GetAllConsulenten();
            dienstLijst = controller.GetAllDiensten();
            aanmeldpuntLijst = controller.GetAllAanmeldpunten();
            minderjarigeLijst = controller.GetAllMinderjarige();
        }

        private void InitListViews()
        {
            InitLists();
            LoadDiensten();
            LoadMinderjarigen();
            LoadVoorzieningen();
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

        private void LoadDiensten()
        {
            LoadList<Dienst>(GetDienstListViewItems, lsvDiensten, dienstLijst);
        }

        private void LoadMinderjarigen()
        {
            LoadList<Minderjarige>(GetMinderjarigeListViewItems, lsvMinderjarige, minderjarigeLijst);
        }

        private void LoadVoorzieningen()
        {
            LoadList<Aanmeldpunt>(GetVoorzieningListViewItems, lsvVoorzieningen, aanmeldpuntLijst);
        }

        private void LoadList<T>(Func<List<T>, List<ListViewItem>> GetListViewItems, ListView listview, List<T> objectList)
        {
            listview.Items.Clear();
            listview.Items.AddRange(GetListViewItems(objectList).ToArray());
            listview.Refresh();
        }

        private List<ListViewItem> GetDienstListViewItems(List<Dienst> itemLijst)
        {
            List<ListViewItem> viewItemList = new List<ListViewItem>();

            foreach (Dienst item in itemLijst)
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
                consulentLijst = controller.GetConsulentInDienst(idDienst);
                InitConsulentCombobox();
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
                if (lsvMinderjarige.SelectedItems[0].SubItems[1].Text != "0")
                {
                    Minderjarige minderjarige = (Minderjarige)lsvMinderjarige.SelectedItems[0].Tag;
                    FrmMinderjarige frmMinderjarige = new FrmMinderjarige(controller, controller.GetMinderjarigeInAanmeldpunten(minderjarige.ID));
                    frmMinderjarige.Show();
                }

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

                controller.InsertNewAanmelding(new MinderjarigeAanmeldpunt(mj, aanmeldpunt, consulent, datumAanmelding, true));
                MessageBox.Show("Nieuwe aanmelding is geregistreerd!");
                ResetForm();
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

        private void btnVoorzieningToevoegen_Click(object sender, EventArgs e)
        {
            Aanmeldpunt newAanmeldpunt = new Aanmeldpunt(0, "", "", 0, "", "", true);
            FrmVoorzieningAanpassen frmvoorzieningAanpassen = new FrmVoorzieningAanpassen(controller, newAanmeldpunt);
            frmvoorzieningAanpassen.ShowDialog();
        }

        public void UpdateDeletedAanmelding()
        {
            InitListViews();
        }
    }
}
