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

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmVoorziening : Form, Observer
    {
        private Controller.Controller controller;
        private Aanmeldpunt aanmeldpunt;
        private List<MinderjarigeAanmeldpunt> minderjarigenInAanmeldpunt;
    

        public FrmVoorziening(Aanmeldpunt aanmeldpunt, Controller.Controller controller)
        {
            InitializeComponent();
            Init(aanmeldpunt, controller);
            InitListView();
            InitColumns();
            controller.RegisterObserver(this);
        }

        private void Init(Aanmeldpunt aanmeldpunt, Controller.Controller controller)
        {
            this.aanmeldpunt = aanmeldpunt;
            this.controller = controller;
            minderjarigenInAanmeldpunt = controller.GetMinderjarigenInAanmeldpunt(aanmeldpunt.ID);

            lblVoorziening.Text = "Overzicht " + aanmeldpunt;
            lblAantalminderjarige.Text = "Aantal minderjarigen in wachtlijst: " + controller.GetWachttijdCount(minderjarigenInAanmeldpunt);
            lblAverageWachttijd.Text = "Gemiddelde wachttijd in voorziening: " + controller.GetAverageWachtijdMinderjarigen(minderjarigenInAanmeldpunt).ToString("0.## dagen");
            
        }

        private void InitColumns()
        {
            lsvVoorziening.Columns[0].Name = "clmMinderjarige";
            lsvVoorziening.Columns[1].Name = "clmConsulent";
            lsvVoorziening.Columns[2].Name = "clmAanmelding";
            lsvVoorziening.Columns[3].Name = "clmOpneming";
            lsvVoorziening.Columns[4].Name = "clmWachttijd";

            foreach (ColumnHeader ch in lsvVoorziening.Columns)
                ch.Tag = new ColumnProperty() { Ascending = true };
        }

        private void InitListView()
        {
            lsvVoorziening.Items.Clear();
            List<ListViewItem> itemList = new List<ListViewItem>();
            foreach (MinderjarigeAanmeldpunt mja in minderjarigenInAanmeldpunt)
            {
                List<string> row = new List<string>();

                double wachttijdInDagen = controller.GetWachttijdInDagen(mja);
                mja.SetWachttijd(wachttijdInDagen);

                if (mja.DatumOpneming < new DateTime(1970, 1, 1))
                {                   
                    string[] rowArr ={  mja.Minderjarige.ToString(), mja.Consulent.ToString(),
                                        mja.DatumAanmelding.ToShortDateString(), "Nog niet opgenomen", mja.Wachttijd.ToString("0") };
                    row.AddRange(rowArr);
                   
                }
                else
                {                   
                    string[] rowArr = { mja.Minderjarige.ToString(), mja.Consulent.ToString(),
                                    mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString(), mja.Wachttijd.ToString("0") };
                    row.AddRange(rowArr);
                }

                if(!mja.AanmeldingActief)
                    row[4] = "n.v.t. - aanmelding niet actief";
                
                ListViewItem item = new ListViewItem(row.ToArray());
                item.Tag = mja;
                itemList.Add(item);
            }

            lsvVoorziening.Items.AddRange(itemList.ToArray());
            lsvVoorziening.Refresh();
        }

        private void btnOverzichtMJ_Click(object sender, EventArgs e)
        {
            if (lsvVoorziening.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvVoorziening.SelectedItems[0].Tag;
                FrmMinderjarige frmMinderjarige = new FrmMinderjarige(controller, controller.GetMinderjarigeInAanmeldpunten(mja.Minderjarige.ID));
                frmMinderjarige.Show();
            }
        }

        private void btnOverzichtConsulent_Click(object sender, EventArgs e)
        {
            if (lsvVoorziening.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvVoorziening.SelectedItems[0].Tag;

                if(mja.Consulent.ID != 0)
                {
                    FrmConsulent frmConsulent = new FrmConsulent(mja.Consulent, controller);
                    frmConsulent.Show();
                }
            }
        }

        private void btnVoorzieningAanpassen_Click(object sender, EventArgs e)
        {
            FrmVoorzieningAanpassen frmVoorzieningAanpassen = new FrmVoorzieningAanpassen(controller, aanmeldpunt, "edit");
            frmVoorzieningAanpassen.ShowDialog();
        }

        private void lsvVoorziening_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnProperty columnProperty = (ColumnProperty)lsvVoorziening.Columns[e.Column].Tag;
            string name = lsvVoorziening.Columns[e.Column].Name;
            columnProperty.Ascending = !columnProperty.Ascending;
            lsvVoorziening.Columns[e.Column].Tag = columnProperty;

            minderjarigenInAanmeldpunt = controller.SorteerOp(name, columnProperty.Ascending, minderjarigenInAanmeldpunt);

            InitListView();
           
        }

        public void UpdateDeletedAanmelding()
        {
            InitListView();
        }

        public void UpdateDBConnected(bool connected)
        {
            //DoNothing
        }

        public void UpdateVoorziening()
        {
            //DoNothing
        }

        private void btnAanmeldingAanpassen_Click(object sender, EventArgs e)
        {
            if (lsvVoorziening.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt selectedmja = (MinderjarigeAanmeldpunt)lsvVoorziening.SelectedItems[0].Tag;
                FrmAanmeldingAanpassen frmAanmeldingAanpassen = new FrmAanmeldingAanpassen(controller, selectedmja);
                frmAanmeldingAanpassen.ShowDialog();
            }
        }

        private void btnSetActiveAanmelding_Click(object sender, EventArgs e)
        {
            if (lsvVoorziening.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvVoorziening.SelectedItems[0].Tag;
                string msgString = mja.AanmeldingActief ? msgString = "Bent u zeker dat u de aanmelding op inactief wilt zetten?" : "Bent u zeker dat u de aanmelding op actief wilt zetten?";

                if (MessageBox.Show(msgString, "Aanmelding actief/inactief", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        controller.SetAanmeldingActief(mja, !mja.AanmeldingActief);
                        MessageBox.Show("De aanmelding is gewijzigd.", "Wijziging gelukt!");
                        InitListView();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Er is iets fout gelopen bij het wijzigen van de aanmelding, probeer later eens opnieuw.", "Wijziging mislukt!");
                    }
                }
            }
        }

        private void btnDeleteAanmelding_Click(object sender, EventArgs e)
        {
            if (lsvVoorziening.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvVoorziening.SelectedItems[0].Tag;
                if (MessageBox.Show("Bent u zeker dat u de aanmelding wilt verwijderen?", "Aanmelding verwijderen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        controller.DeleteAanmelding(mja);
                        MessageBox.Show("De aanmelding is verwijderd.", "Verwijderen gelukt!");
                        InitListView();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Er is iets fout gelopen bij het verwijderen van de aanmelding, probeer later eens opnieuw.", "Verwijderen mislukt!");
                    }
                }
            }
        }

        private void lsvVoorziening_DoubleClick(object sender, EventArgs e)
        {
            btnOverzichtMJ_Click(sender, e);
        }
    }
}
