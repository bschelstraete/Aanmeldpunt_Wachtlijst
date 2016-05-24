using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmDienst : Form, Observer
    {
        private Controller.Controller controller;
        private Dienst activeDienst;
        private List<MinderjarigeAanmeldpunt> minderJarigenInDienst = new List<MinderjarigeAanmeldpunt>();

        public FrmDienst(Dienst activeDienst, Controller.Controller controller)
        {
            InitializeComponent();
            Init(activeDienst, controller);
        }

        private void Init(Dienst activeDienst, Controller.Controller controller)
        {
            this.controller = controller;
            this.activeDienst = activeDienst;

            lblOverzicht.Text = "Overzicht " + activeDienst.Naam;
            minderJarigenInDienst.AddRange(controller.GetMinderjarigenInDienst(activeDienst.ID));

            InitListView();
            InitColumns();
            InitLabels();
        }

        private void InitListView()
        {
            lsvDienstOverzicht.Items.Clear();

            List<ListViewItem> itemList = new List<ListViewItem>();

            foreach (MinderjarigeAanmeldpunt mja in minderJarigenInDienst)
            {
                List<string> row = new List<string>();
                double wachttijd = controller.GetWachttijdInDagen(mja);
                mja.SetWachttijd(wachttijd);
                if (mja.DatumOpneming < new DateTime(1970, 1, 1))
                {
                    string[] rowArr ={ mja.Minderjarige.ToString(), mja.Consulent.ToString(), mja.Aanmeldpunt.ToString(),
                                        mja.DatumAanmelding.ToShortDateString(), "Nog niet opgenomen", mja.Wachttijd.ToString("0") };
                    row.AddRange(rowArr);
                }
                else
                {
                    string[] rowArr = { mja.Minderjarige.ToString(), mja.Consulent.ToString(), mja.Aanmeldpunt.ToString(),
                                    mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString(), mja.Wachttijd.ToString("0") };
                    row.AddRange(rowArr);
                }
                if (!mja.AanmeldingActief)
                    row[4] = "n.v.t. - aanmelding niet actief";

                ListViewItem item = new ListViewItem(row.ToArray());
                item.Tag = mja;
                itemList.Add(item);
            }

            lsvDienstOverzicht.Items.AddRange(itemList.ToArray());
        }

        private void InitLabels()
        {
            int wachtijdCount = controller.GetWachttijdCount(minderJarigenInDienst);
            double averageWachttijd = controller.GetAverageWachtijdMinderjarigen(minderJarigenInDienst);

            lblAantalAanmeldingen.Text = "Aantal minderjarigen in wachtlijst: " + wachtijdCount.ToString();
            lblAverageWachttijd.Text = "Gemiddelde wachtijd: " + averageWachttijd.ToString("0.## dagen");
        }

        private void InitColumns()
        {
            lsvDienstOverzicht.Columns[0].Name = "clmMinderjarige";
            lsvDienstOverzicht.Columns[1].Name = "clmConsulent";
            lsvDienstOverzicht.Columns[2].Name = "clmVoorziening";
            lsvDienstOverzicht.Columns[3].Name = "clmAanmelding";
            lsvDienstOverzicht.Columns[4].Name = "clmOpneming";
            lsvDienstOverzicht.Columns[5].Name = "clmWachttijd";

            foreach (ColumnHeader ch in lsvDienstOverzicht.Columns)
                ch.Tag = new ColumnProperty() { Ascending = true };
        }

        private void lsvDienstOverzicht_DoubleClick(object sender, EventArgs e)
        {
            if (lsvDienstOverzicht.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvDienstOverzicht.SelectedItems[0].Tag;
                FrmMinderjarige frmMinderjarige = new FrmMinderjarige(controller, controller.GetMinderjarigeInAanmeldpunten(mja.Minderjarige.ID));
                frmMinderjarige.Show();
            }
        }

        private void btnOpenConsulent_Click(object sender, EventArgs e)
        {
            if (lsvDienstOverzicht.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt selectedMinderjarige = (MinderjarigeAanmeldpunt)lsvDienstOverzicht.SelectedItems[0].Tag;
                FrmConsulent frmConsulent = new FrmConsulent(selectedMinderjarige.Consulent, controller);
                frmConsulent.Show();
            }
        }

        private void btnOpenVoorziening_Click(object sender, EventArgs e)
        {
            if (lsvDienstOverzicht.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt selectedMinderjarige = (MinderjarigeAanmeldpunt)lsvDienstOverzicht.SelectedItems[0].Tag;
                FrmVoorziening frmVoorziening = new FrmVoorziening(selectedMinderjarige.Aanmeldpunt, controller);
                frmVoorziening.Show();
            }
        }

        private void btnDeleteAanmelding_Click(object sender, EventArgs e)
        {
            if (lsvDienstOverzicht.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvDienstOverzicht.SelectedItems[0].Tag;
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

        private void btnSetActiveAanmelding_Click(object sender, EventArgs e)
        {
            if (lsvDienstOverzicht.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvDienstOverzicht.SelectedItems[0].Tag;
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

        private void btnOpenMinderjarige_Click(object sender, EventArgs e)
        {

            if (lsvDienstOverzicht.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvDienstOverzicht.SelectedItems[0].Tag;
                FrmMinderjarige frmMinderjarige = new FrmMinderjarige(controller, controller.GetMinderjarigeInAanmeldpunten(mja.Minderjarige.ID));
                frmMinderjarige.Show();
            }
        }

        private void lsvDienstOverzicht_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnProperty columnProperty = (ColumnProperty)lsvDienstOverzicht.Columns[e.Column].Tag;
            string name = lsvDienstOverzicht.Columns[e.Column].Name;
            columnProperty.Ascending = !columnProperty.Ascending;
            lsvDienstOverzicht.Columns[e.Column].Tag = columnProperty;

            minderJarigenInDienst = controller.SorteerOp(name, columnProperty.Ascending, minderJarigenInDienst);

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

        private void btnOverzichtOpslaan_Click(object sender, EventArgs e)
        {
            string output = "";

            FolderBrowserDialog folderselecta = new FolderBrowserDialog();
            if (folderselecta.ShowDialog() == DialogResult.OK)
                output = folderselecta.SelectedPath;

            if (!String.IsNullOrEmpty(output))
            {
                controller.WriteToFile(minderJarigenInDienst, output);
                MessageBox.Show("Succesvol opgeslagen!", "Overzicht opslaan");
            }
                
        }
    }
}
