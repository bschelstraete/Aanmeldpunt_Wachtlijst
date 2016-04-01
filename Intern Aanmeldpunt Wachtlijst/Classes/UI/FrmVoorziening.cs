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

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmVoorziening : Form
    {
        private Controller.Controller controller;
        private Aanmeldpunt aanmeldpunt;
        private List<MinderjarigeAanmeldpunt> minderjarigenInAanmeldpunt;
    

        public FrmVoorziening(Aanmeldpunt aanmeldpunt, Controller.Controller controller)
        {
            InitializeComponent();
            Init(aanmeldpunt, controller);
        }

        private void Init(Aanmeldpunt aanmeldpunt, Controller.Controller controller)
        {
            this.aanmeldpunt = aanmeldpunt;
            this.controller = controller;
            minderjarigenInAanmeldpunt = controller.GetMinderjarigenInAanmeldpunt(aanmeldpunt.ID);

            lblVoorziening.Text = "Overzicht " + aanmeldpunt;
            lblAantalminderjarige.Text = "Aantal minderjarigen in wachtlijst: " + controller.GetWachttijdCount(minderjarigenInAanmeldpunt);
            lblAverageWachttijd.Text = "Gemiddelde wachttijd in voorziening: " + controller.GetAverageWachtijdMinderjarigen(minderjarigenInAanmeldpunt).ToString("0.## dagen");

            lsvVoorziening.Items.Clear();
            lsvVoorziening.Items.AddRange(GetListViewItems().ToArray());
            lsvVoorziening.Refresh();
        }

        private List<ListViewItem> GetListViewItems()
        {
            List<ListViewItem> itemList = new List<ListViewItem>();
            foreach (MinderjarigeAanmeldpunt mja in minderjarigenInAanmeldpunt)
            {
                List<string> row = new List<string>();

                if (mja.DatumOpneming < new DateTime(1970, 1, 1))
                {
                    double wachttijdInDagen = controller.GetWachttijdInDagen(mja);
                    string[] rowArr ={  mja.Minderjarige.ToString(), mja.Consulent.ToString(),
                                        mja.DatumAanmelding.ToShortDateString(), "Nog niet opgenomen", wachttijdInDagen.ToString("0.##") };
                    row.AddRange(rowArr);
                }
                else
                {
                    double wachttijdInDagen = controller.GetWachttijdInDagen(mja);
                    string[] rowArr = { mja.Minderjarige.ToString(), mja.Consulent.ToString(),
                                    mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString(), wachttijdInDagen.ToString("0.##") };
                    row.AddRange(rowArr);
                }
                ListViewItem item = new ListViewItem(row.ToArray());
                item.Tag = mja;
                itemList.Add(item);
            }

            return itemList;
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
            FrmVoorzieningAanpassen frmVoorzieningAanpassen = new FrmVoorzieningAanpassen(controller, aanmeldpunt);
            frmVoorzieningAanpassen.ShowDialog();
        }
    }
}
