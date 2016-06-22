using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    public partial class FrmStatistics : Form
    {
        private Controller.Controller controller;
        private List<Dienst> dienstLijst = new List<Dienst>();
        private List<int> dienstAanmelding = new List<int>();
        private List<int> dienstOpneming = new List<int>();
        private List<Aanmeldpunt> voorzieningLijst = new List<Aanmeldpunt>();
        private List<int> voorzieningAanmelding = new List<int>();
        private List<int> voorzieningOpneming = new List<int>();
        private DateTime datumVan = DateTime.Now;
        private DateTime datumTot = DateTime.Now;

        public FrmStatistics(Controller.Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            Init();
        }

        private void Init()
        {
            dienstLijst = LoadLijsten<Dienst>(GetDienstLijst, dienstAanmelding, dienstOpneming);
            voorzieningLijst = LoadLijsten<Aanmeldpunt>(GetVoorzieningLijst, voorzieningAanmelding, voorzieningOpneming);
            InitDiensten();
            InitVoorzieningen();
            InitWachttijdDiensten();
            InitWachttijdVoorzieningen();
        }

        private void InitDiensten()
        {
            chtDiensten.Text = "Overzicht actieve aanmeldingen in alle diensten";

            if (chtDiensten.Titles.Count == 0)
                chtDiensten.Titles.Add("Overzicht actieve aanmeldingen in alle diensten");
            else
                chtDiensten.Titles[0].Text = "Overzicht actieve aanmeldingen in alle diensten";
            LoadChartAanmelding<Dienst>(dienstLijst, dienstAanmelding, dienstOpneming, chtDiensten);
        }

        private void InitVoorzieningen()
        {
            chtVoorzieningen.Text = "Overzicht actieve aanmeldingen in alle voorzieningen";

            if (chtVoorzieningen.Titles.Count == 0)
                chtVoorzieningen.Titles.Add("Overzicht actieve aanmeldingen in alle voorzieningen");
            else
                chtVoorzieningen.Titles[0].Text = "Overzicht actieve aanmeldingen in alle voorzieningen";

            LoadChartAanmelding<Aanmeldpunt>(voorzieningLijst, voorzieningAanmelding, voorzieningOpneming, chtVoorzieningen);
        }

        private void InitWachttijdDiensten()
        {
            chtWachttijdDienst.Text = "Overzicht gemiddelde wachtijd per dienst";

            if (chtWachttijdDienst.Titles.Count == 0)
                chtWachttijdDienst.Titles.Add(chtWachttijdDienst.Text);
            else
                chtWachttijdDienst.Titles[0].Text = "Overzicht gemiddelde wachtijd per dienst";

            LoadChartWachttijd<Dienst>(dienstLijst, dienstAanmelding, dienstOpneming, chtWachttijdDienst);
        }

        private void InitWachttijdVoorzieningen()
        {
            chtWachttijdVoorziening.Text = "Overzicht gemiddelde wachttijd per voorziening";

            if (chtWachttijdVoorziening.Titles.Count == 0)
                chtWachttijdVoorziening.Titles.Add(chtWachttijdVoorziening.Text);
            else
                chtWachttijdVoorziening.Titles[0].Text = chtWachttijdVoorziening.Text;
            LoadChartWachttijd<Aanmeldpunt>(voorzieningLijst, voorzieningAanmelding, voorzieningOpneming, chtWachttijdVoorziening);
        }

        private List<Dienst> GetDienstLijst()
        {
            return controller.GetAllDiensten();
        }

        private List<Aanmeldpunt> GetVoorzieningLijst()
        {
            return controller.GetAllAanmeldpunten();
        }

        private List<T> LoadLijsten<T>(Func<List<T>> GetLijst, List<int> aanmeldingCountLijst, List<int> opnemingCountLijst)
        {
            aanmeldingCountLijst.Clear();
            opnemingCountLijst.Clear();

            List<T> objectLijst = GetLijst();

            foreach (Object item in objectLijst)
            {
                List<MinderjarigeAanmeldpunt> aanmeldingLijst = new List<MinderjarigeAanmeldpunt>();
                if (item.GetType() == typeof(Dienst))
                    aanmeldingLijst = controller.GetMinderjarigeBetweenDatesInDienst(((Dienst)item), datumVan, datumTot);
                if (item.GetType() == typeof(Aanmeldpunt))
                    aanmeldingLijst = controller.GetMinderjarigeBetweenDatesInAanmeldpunt(((Aanmeldpunt)item), datumVan, datumTot);
                int aanmeldingCount = 0;
                int opnemingCount = 0;
                foreach (MinderjarigeAanmeldpunt mja in aanmeldingLijst)
                {
                    if (mja.AanmeldingActief)
                    {
                        aanmeldingCount++;
                        if (mja.DatumOpneming > new DateTime(1970, 1, 1))
                        {
                            opnemingCount++;
                        }
                    }

                }
                aanmeldingCountLijst.Add(aanmeldingCount);
                opnemingCountLijst.Add(opnemingCount);
            }

            return objectLijst;
        }

        private void LoadChartAanmelding<T>(List<T> overzichtLijst, List<int> aanmeldingCount, List<int> opnemingCount, Chart chart)
        {
            chart.Series.Clear();
            chart.Series.Add("Aanmeldingen");
            chart.Series["Aanmeldingen"].Label = "#VALX\n#VALY aanmelding(en)\n#PERCENT";
            chart.Series["Aanmeldingen"].IsVisibleInLegend = false;
            chart.Series["Aanmeldingen"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart.Series["Aanmeldingen"]["PieLabelStyle"] = "Outside";
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;

            for (int i = 0; i < overzichtLijst.Count(); i++)
            {
                if (aanmeldingCount[i] != 0)
                {
                    if(opnemingCount[i] == 0)
                    {
                        Object b = overzichtLijst[i];
                        if (typeof(T) == typeof(Dienst))
                        {
                            Dienst dienst = (Dienst)b;
                            chart.Series["Aanmeldingen"].Points.AddXY(dienst.Naam, aanmeldingCount[i]);
                        }
                        else
                        {
                            Aanmeldpunt ap = (Aanmeldpunt)b;
                            chart.Series["Aanmeldingen"].Points.AddXY(ap.Naam, aanmeldingCount[i]);
                        }
                    }
                }
            }

            chart.Update();
        }

        private void LoadChartWachttijd<T>(List<T> overzichtLijst, List<int> aanmeldingCount, List<int> opnemeingCount, Chart chart)
        {
            chart.Series.Clear();
            chart.Series.Add("Gemiddelde wachttijd in dagen");
            //chart.Series["Gemiddelde wachttijd in dagen"].Label = "#VALX\n#VALY dagen";
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            //chart.Series["Gemiddelde wachttijd in dagen"].IsVisibleInLegend = false;
            //chart.Series["Gemiddelde wachttijd in dagen"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            //chart.Series["Gemiddelde wachttijd in dagen"]["PieLabelStyle"] = "Outside";
            //chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            double totalAverageWachttijd = 0.0;

            for (int i = 0; i < overzichtLijst.Count(); i++)
            {
                if (aanmeldingCount[i] != 0)
                {
                    Object b = overzichtLijst[i];
                    if(typeof(T) == typeof(Dienst))
                    {
                        Dienst dienst = (Dienst)b;
                        List<MinderjarigeAanmeldpunt> aanmeldingen = controller.GetMinderjarigenInDienst(dienst.ID);
                        totalAverageWachttijd += controller.GetAverageWachtijdMinderjarigen(aanmeldingen);
                        double averageWachttijd = controller.GetAverageWachtijdMinderjarigen(aanmeldingen);
                        chart.Series["Gemiddelde wachttijd in dagen"].Points.AddXY(dienst.Naam, Convert.ToInt32(averageWachttijd));
                    }
                    if(typeof(T) == typeof(Aanmeldpunt))
                    {
                        Aanmeldpunt aanmeldpunt = (Aanmeldpunt)b;
                        List<MinderjarigeAanmeldpunt> aanmeldingen = controller.GetMinderjarigenInAanmeldpunt(aanmeldpunt.ID);
                        totalAverageWachttijd += controller.GetAverageWachtijdMinderjarigen(aanmeldingen);
                        double averageWachttijd = controller.GetAverageWachtijdMinderjarigen(aanmeldingen);
                        chart.Series["Gemiddelde wachttijd in dagen"].Points.AddXY(aanmeldpunt.Naam, Convert.ToInt32(averageWachttijd));
                    }
                }
            }

            if(totalAverageWachttijd != 0.0)
            {
                totalAverageWachttijd /= overzichtLijst.Count();
                chart.Titles[0].Text += " - Totale gemiddelde wachttijd: " + totalAverageWachttijd.ToString("0.## dagen");
            }

            chart.Update();
        }

        private void btnToepassen_Click(object sender, EventArgs e)
        {
            datumVan = dtpVan.Value;
            datumTot = dtpTot.Value;

            if (datumVan > datumTot)
                MessageBox.Show("Gelieve een begindatum te kiezen die kleiner is dan de einddatum", "Datum selecteren");
            else if (datumVan < datumTot)
            {
                Init();
            }
        }

        private void lblAanmeldingen_Click(object sender, EventArgs e)
        {
            if(splContainerAanmeldingen.Visible)
            {
                lblAanmeldingen.Text = "Statistieken i.v.m. Aanmeldingen    +";
                splContainerAanmeldingen.Visible = false;
            }
            else
            {
                lblAanmeldingen.Text = "Statistieken i.v.m. Aanmeldingen    -";
                splContainerAanmeldingen.Visible = true;
            }
        }
    }
}
