using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmDienst : Form
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
            InitLabels();
        }

        private void InitListView()
        {
            lsvDienstOverzicht.Items.Clear();

            List<ListViewItem> itemList = new List<ListViewItem>();

            foreach (MinderjarigeAanmeldpunt mja in minderJarigenInDienst)
            {
                List<string> row = new List<string>();
                if (mja.DatumOpneming < new DateTime(1970, 1, 1))
                {
                    string[] rowArr ={ mja.Minderjarige.ToString(), mja.Consulent.ToString(), mja.Aanmeldpunt.ToString(),
                                        mja.DatumAanmelding.ToShortDateString(), "Nog niet opgenomen" };
                    row.AddRange(rowArr);
                }
                else
                {
                    string[] rowArr = { mja.Minderjarige.ToString(), mja.Consulent.ToString(), mja.Aanmeldpunt.ToString(),
                                    mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString() };
                    row.AddRange(rowArr);
                }
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
    }
}
