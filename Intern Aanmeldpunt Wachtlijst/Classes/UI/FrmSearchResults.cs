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
    public partial class FrmSearchResults : Form
    {
        private Controller.Controller controller;
        private List<Minderjarige> results;

        public FrmSearchResults(Controller.Controller controller, List<Minderjarige> results, string search)
        {
            InitializeComponent();
            Init(controller, results, search);
            InitResultList();
        }

        private void Init(Controller.Controller controller, List<Minderjarige> results, string search)
        {
            this.controller = controller;
            this.results = results;
            lblResults.Text += search;
        }

        private void InitResultList()
        {
            lsvResults.Columns[0].Name = "clmNaam";
            lsvResults.Columns[1].Name = "clmVoornaam";

            foreach (ColumnHeader ch in lsvResults.Columns)
                ch.Tag = new ColumnProperty() { Ascending = true };

            lsvResults.Items.Clear();
            
            foreach (Minderjarige mj in results)
            {
                string[] row = { mj.Naam, mj.Voornaam };
                ListViewItem item = new ListViewItem(row);
                item.Tag = mj;
                lsvResults.Items.Add(item);
            }
        }

        private void btnOpenMJ_Click(object sender, EventArgs e)
        {
            if (lsvResults.SelectedItems.Count != 0)
            {
                Minderjarige mj = (Minderjarige)lsvResults.SelectedItems[0].Tag;
                List<MinderjarigeAanmeldpunt> minderjarigeAanmeldingen = controller.GetMinderjarigeInAanmeldpunten(mj.ID);
                FrmMinderjarige frmMinderjarige = new FrmMinderjarige(controller, minderjarigeAanmeldingen);
                frmMinderjarige.Show();
            }
            
        }

        private void lsvResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOpenMJ_Click(sender, e);
        }
    }
}
