using Intern_Aanmeldpunt_Wachtlijst.Classes.Controller;
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
    public partial class FrmMinderjarige : Form, Observer
    {
        private Controller.Controller controller;
        private List<MinderjarigeAanmeldpunt> minderjarigeInAanmeldpunt = new List<MinderjarigeAanmeldpunt>();


        public FrmMinderjarige(Controller.Controller controller, List<MinderjarigeAanmeldpunt> minderjarigeInAanmeldpunt)
        {
            InitializeComponent();
            Init(controller, minderjarigeInAanmeldpunt);
            controller.RegisterObserver(this);
        }

        private void Init(Controller.Controller controller, List<MinderjarigeAanmeldpunt> minderjarigeInAanmeldpunt)
        {
            this.controller = controller;
            this.minderjarigeInAanmeldpunt = minderjarigeInAanmeldpunt;

            lblMinderjarige.Text = "Overzicht " + minderjarigeInAanmeldpunt.FirstOrDefault().Minderjarige.ToString();

            InitColumns();
            InitListView();

            lblAantalAanmeldingen.Text = "Aantal aanmeldingen: " + lsvMinderjarige.Items.Count;
        }

        private void InitColumns()
        {
            lsvMinderjarige.Columns[0].Name = "clmConsulent";
            lsvMinderjarige.Columns[1].Name = "clmDienst";
            lsvMinderjarige.Columns[2].Name = "clmVoorziening";
            lsvMinderjarige.Columns[3].Name = "clmAanmelding";
            lsvMinderjarige.Columns[4].Name = "clmOpneming";
            lsvMinderjarige.Columns[5].Name = "clmWachttijd";

            foreach (ColumnHeader ch in lsvMinderjarige.Columns)
                ch.Tag = new ColumnProperty() { Ascending = true };
        }

        private void InitListView()
        {
            List<ListViewItem> itemList = new List<ListViewItem>();
            lsvMinderjarige.Items.Clear();
            foreach (MinderjarigeAanmeldpunt mja in minderjarigeInAanmeldpunt)
            {
                List<string> row = new List<string>();
                Dienst dienstConsulent = new Dienst(0, "", "", 0);
                if(mja.Consulent.ID != 0)
                    dienstConsulent = controller.GetDienstVanConsulent(mja.Consulent.ID);

                double wachttijdInDagen = controller.GetWachttijdInDagen(mja);
                mja.SetWachttijd(wachttijdInDagen);

                if (mja.DatumOpneming < new DateTime(1970, 1, 1))
                {
                    string[] rowArr ={  mja.Consulent.ToString(), dienstConsulent.ToString(), mja.Aanmeldpunt.ToString(),
                                        mja.DatumAanmelding.ToShortDateString(), "Nog niet opgenomen", mja.Wachttijd.ToString("0") };
                    row.AddRange(rowArr);
                }
                else
                {
                    string[] rowArr = { mja.Consulent.ToString(), dienstConsulent.ToString(), mja.Aanmeldpunt.ToString(),
                                    mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString(), mja.Wachttijd.ToString("0") };
                    row.AddRange(rowArr);
                }
                ListViewItem item = new ListViewItem(row.ToArray());
                item.Tag = new Object[] { mja, dienstConsulent } ;
                itemList.Add(item);
            }

            lsvMinderjarige.Items.AddRange(itemList.ToArray());
        }

        private void btnOverzichtDienst_Click(object sender, EventArgs e)
        {
            if (lsvMinderjarige.SelectedItems.Count != 0)
            {
                Dienst selectedDienst = (Dienst)((Object[])lsvMinderjarige.SelectedItems[0].Tag)[1];
                if (selectedDienst.ID != 0)
                {
                    FrmDienst frmDienst = new FrmDienst(selectedDienst, controller);
                    frmDienst.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Gelieve een aanmelding te selecteren.");
            }
        }

        private void btnOverzichtConsulent_Click(object sender, EventArgs e)
        {
            if (lsvMinderjarige.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt selectedMinderjarige = (MinderjarigeAanmeldpunt)((Object[])lsvMinderjarige.SelectedItems[0].Tag)[0];
                if (selectedMinderjarige.Consulent.ID != 0)
                {
                    FrmConsulent frmConsulent = new FrmConsulent(selectedMinderjarige.Consulent, controller);
                    frmConsulent.Show();
                }
            }
        }

        private void btnOverzichtVoorziening_Click(object sender, EventArgs e)
        {
            if (lsvMinderjarige.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)((Object[])lsvMinderjarige.SelectedItems[0].Tag)[0];
                FrmVoorziening frmVoorziening = new FrmVoorziening(mja.Aanmeldpunt, controller);
                frmVoorziening.Show();
            }
        }

        private void btnDeleteAanmelding_Click(object sender, EventArgs e)
        {
            if (lsvMinderjarige.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)((Object[])lsvMinderjarige.SelectedItems[0].Tag)[0];
                if(MessageBox.Show("Bent u zeker dat u de aanmelding wilt verwijderen?", "Aanmelding verwijderen", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void btnSetActiveAanmelding_Click(object sender, EventArgs e)
        {
            if (lsvMinderjarige.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)((Object[])lsvMinderjarige.SelectedItems[0].Tag)[0];
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

        private void lsvMinderjarige_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnProperty columnProperty = (ColumnProperty)lsvMinderjarige.Columns[e.Column].Tag;
            string name = lsvMinderjarige.Columns[e.Column].Name;
            columnProperty.Ascending  = !columnProperty.Ascending;
            lsvMinderjarige.Columns[e.Column].Tag = columnProperty;

            minderjarigeInAanmeldpunt = controller.SorteerOp(name, columnProperty.Ascending, minderjarigeInAanmeldpunt);

            InitListView();
        }


        public void UpdateDBConnected(bool connected)
        {
            throw new NotImplementedException();
        }

        public void UpdateVoorziening()
        {
            throw new NotImplementedException();
        }

        public void UpdateDeletedAanmelding()
        {
            InitListView();
        }

        private void btnAanmeldingAanpassen_Click(object sender, EventArgs e)
        {
            if (lsvMinderjarige.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt selectedmja = (MinderjarigeAanmeldpunt)((Object[])lsvMinderjarige.SelectedItems[0].Tag)[0];
                FrmAanmeldingAanpassen frmAanmeldingAanpassen = new FrmAanmeldingAanpassen(controller, selectedmja);
                frmAanmeldingAanpassen.ShowDialog();
            }           
        }
    }
}
