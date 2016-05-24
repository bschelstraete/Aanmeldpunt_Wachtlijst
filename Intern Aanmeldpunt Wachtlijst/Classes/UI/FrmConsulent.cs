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
    public partial class FrmConsulent : Form, Observer
    {
        private Controller.Controller controller;
        private Consulent consulent;
        private List<MinderjarigeAanmeldpunt> minderjarigenAangemeld;

        public FrmConsulent(Consulent consulent, Controller.Controller controller)
        {
            InitializeComponent();
            Init(consulent, controller);
            InitViewList();
            InitColumns();
        }

        private void Init(Consulent consulent, Controller.Controller controller)
        {
            this.controller = controller;
            this.consulent = consulent;
            minderjarigenAangemeld = this.controller.GetMinderjarigenAangemeldDoor(consulent.ID);

            lblConsulent.Text = "Overzicht van consulent: " + consulent;
            lblAantalMinderjarigen.Text = "Aantal minderjarigen in wachtlijst: " + controller.GetWachttijdCount(minderjarigenAangemeld);
        }

        private void InitColumns()
        {
            lsvOverzicht.Columns[0].Name = "clmMinderjarige";
            lsvOverzicht.Columns[1].Name = "clmVoorziening";
            lsvOverzicht.Columns[2].Name = "clmAanmelding";
            lsvOverzicht.Columns[3].Name = "clmOpneming";
            lsvOverzicht.Columns[4].Name = "clmWachttijd";

            foreach (ColumnHeader ch in lsvOverzicht.Columns)
                ch.Tag = new ColumnProperty() { Ascending = true };
        }

        private void InitViewList()
        {
            lsvOverzicht.Items.Clear();
            List<ListViewItem> itemList = GetItemList();
            lsvOverzicht.Items.AddRange(itemList.ToArray());
        }

        private List<ListViewItem> GetItemList()
        {
            List<ListViewItem> itemList = new List<ListViewItem>();

            foreach (MinderjarigeAanmeldpunt mja in minderjarigenAangemeld)
            {
                double wachttijd = controller.GetWachttijdInDagen(mja);
                mja.SetWachttijd(wachttijd);
                List<string> row = new List<string>();
                if (mja.DatumOpneming < new DateTime(1970, 1, 1))
                {
                    string[] rowArr ={ mja.Minderjarige.ToString(), mja.Aanmeldpunt.ToString(),
                                        mja.DatumAanmelding.ToShortDateString(), "Nog niet opgenomen", mja.Wachttijd.ToString("0") };
                    row.AddRange(rowArr);
                }
                else
                {
                    string[] rowArr = { mja.Minderjarige.ToString(), mja.Aanmeldpunt.ToString(),
                                    mja.DatumAanmelding.ToShortDateString(), mja.DatumOpneming.ToShortDateString(), mja.Wachttijd.ToString("0") };
                    row.AddRange(rowArr);
                }
                ListViewItem item = new ListViewItem(row.ToArray());
                item.Tag = mja;
                itemList.Add(item);
            }

            return itemList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lsvOverzicht.SelectedItems.Count != 0)
            {
                MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvOverzicht.SelectedItems[0].Tag;
                FrmMinderjarige frmMinderjarige = new FrmMinderjarige(controller, controller.GetMinderjarigeInAanmeldpunten(mja.Minderjarige.ID));
                frmMinderjarige.ShowDialog();
            }
        }

        private void lsvOverzicht_DoubleClick(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }

        private void btnOverzichtVoorziening_Click(object sender, EventArgs e)
        {
            MinderjarigeAanmeldpunt mja = (MinderjarigeAanmeldpunt)lsvOverzicht.SelectedItems[0].Tag;
            FrmVoorziening frmVoorziening = new FrmVoorziening(mja.Aanmeldpunt, controller);
            frmVoorziening.Show();
        }

        private void lsvOverzicht_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnProperty columnProperty = (ColumnProperty)lsvOverzicht.Columns[e.Column].Tag;
            string name = lsvOverzicht.Columns[e.Column].Name;
            columnProperty.Ascending = !columnProperty.Ascending;
            lsvOverzicht.Columns[e.Column].Tag = columnProperty;

            minderjarigenAangemeld = controller.SorteerOp(name, columnProperty.Ascending, minderjarigenAangemeld);

            InitViewList();
        }

        public void UpdateDeletedAanmelding()
        {
            InitViewList();
        }

        public void UpdateDBConnected(bool connected)
        {
            //DoNothing
        }

        public void UpdateVoorziening()
        {
            //DoNothing
        }

        private void btnEditConsulent_Click(object sender, EventArgs e)
        {
            FrmConsulentAanpassen frmConsulentAanpassen = new FrmConsulentAanpassen(controller, consulent);
            frmConsulentAanpassen.ShowDialog();
        }
    }
}
