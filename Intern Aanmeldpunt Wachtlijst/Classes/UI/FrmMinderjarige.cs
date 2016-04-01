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
    public partial class FrmMinderjarige : Form
    {
        private Controller.Controller controller;
        private List<MinderjarigeAanmeldpunt> minderjarigeInAanmeldpunt = new List<MinderjarigeAanmeldpunt>();

        public FrmMinderjarige(Controller.Controller controller, List<MinderjarigeAanmeldpunt> minderjarigeInAanmeldpunt)
        {
            InitializeComponent();
            Init(controller, minderjarigeInAanmeldpunt);
        }

        private void Init(Controller.Controller controller, List<MinderjarigeAanmeldpunt> minderjarigeInAanmeldpunt)
        {
            this.controller = controller;
            this.minderjarigeInAanmeldpunt = minderjarigeInAanmeldpunt;

            lblMinderjarige.Text = "Overzicht " + minderjarigeInAanmeldpunt.FirstOrDefault().Minderjarige.ToString();

            InitListView();

            lblAantalAanmeldingen.Text = "Aantal aanmeldingen: " + lsvMinderjarige.Items.Count;
        }

        private void InitListView()
        {
            List<ListViewItem> itemList = new List<ListViewItem>();
            foreach (MinderjarigeAanmeldpunt mja in minderjarigeInAanmeldpunt)
            {
                List<string> row = new List<string>();
                Dienst dienstConsulent = new Dienst(0, "", "", 0);
                if(mja.Consulent.ID != 0)
                    dienstConsulent = controller.GetDienstVanConsulent(mja.Consulent.ID);

                if (mja.DatumOpneming < new DateTime(1970, 1, 1))
                {
                    string[] rowArr ={  mja.Consulent.ToString(), dienstConsulent.ToString(), mja.Aanmeldpunt.ToString(),
                                        mja.DatumAanmelding.ToShortDateString(), "Nog niet opgenomen" };
                    row.AddRange(rowArr);
                }
                else
                {
                    string[] rowArr = { mja.Consulent.ToString(), dienstConsulent.ToString(), mja.Aanmeldpunt.ToString(),
                                    mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString() };
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
    }
}
