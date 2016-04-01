using Intern_Aanmeldpunt_Wachtlijst.Classes.Database;
using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.Controller
{
    public class Controller
    {
        private List<Observer> observerList = new List<Observer>();
        private DbQueries dbQueries = new DbQueries();

        public Dienst GetDienst(int idDienst)
        {
            return dbQueries.GetDienst(idDienst);
        }

        public List<Dienst> GetAllDiensten()
        {
            return dbQueries.GetAllDiensten();
        }

        public Consulent GetConsulent(int idConsulent)
        {
            return dbQueries.GetConsulent(idConsulent);
        }

        public Dienst GetDienstVanConsulent(int idConsulent)
        {
            return dbQueries.GetDienstVanConsulent(idConsulent);
        }

        public List<Consulent> GetConsulentInDienst(int idDienst)
        {
            return dbQueries.GetConsulentInDienst(idDienst);
        }

        public List<Consulent> GetAllConsulenten()
        {
            return dbQueries.GetAllConsulenten();
        }

        public List<Aanmeldpunt> GetAllAanmeldpunten()
        {
            return dbQueries.GetAllAanmeldpunten();
        }

        public double GetAverageWachtijdMinderjarigen(List<MinderjarigeAanmeldpunt> minderjarigenLijst)
        {
            double totalDays = 0.0;

            foreach (MinderjarigeAanmeldpunt mja in minderjarigenLijst)
            {
                totalDays += GetWachttijdInDagen(mja);
            }

            return totalDays;
        }

        public double GetWachttijdInDagen(MinderjarigeAanmeldpunt mja)
        {
            double wachttijd = 0.0;

            if (mja.DatumOpneming < new DateTime(1970, 1, 1))
            {
                DateTime end = DateTime.Now;
                DateTime start = mja.DatumAanmelding;
                wachttijd += (end - start).TotalDays;
            }
            else
            {
                DateTime end = mja.DatumOpneming;
                DateTime start = mja.DatumAanmelding;
                wachttijd += (end - start).TotalDays;
            }

            return wachttijd;
        }

        public int GetWachttijdCount(List<MinderjarigeAanmeldpunt> minderjarigenLijst)
        {
            int wachtijdCount = 0;

            foreach (MinderjarigeAanmeldpunt mja in minderjarigenLijst)
            {
                if (mja.DatumOpneming < new DateTime(1970, 1, 1))
                    wachtijdCount++;
            }

            return wachtijdCount;
        }

        public List<Minderjarige> GetAllMinderjarige()
        {
            return dbQueries.GetAllMinderjarige();
        }

        public List<MinderjarigeAanmeldpunt> GetMinderjarigenInDienst(int idDienst)
        {
            return dbQueries.GetMinderjarigenInDienst(idDienst);
        }

        public int GetMinderjarigenCountPerDienst(int idDienst)
        {
            return dbQueries.GetMinderjarigeCountInDienst(idDienst);
        }

        public List<MinderjarigeAanmeldpunt> GetMinderjarigeInAanmeldpunten(int idMinderjarige)
        {
            return dbQueries.GetMinderjarigeInAanmeldpunten(idMinderjarige);
        }

        public List<MinderjarigeAanmeldpunt> GetMinderjarigenAangemeldDoor(int idConsulent)
        {
            return dbQueries.GetMinderjarigenAangemeldDoor(idConsulent);
        }

        public List<MinderjarigeAanmeldpunt> GetMinderjarigenInAanmeldpunt(int idAanmeldpunt)
        {
            return dbQueries.GetMinderjarigenInAanmeldpunt(idAanmeldpunt);
        }

        public void EditAanmeldpunt(Aanmeldpunt oldAanmeldpunt, Aanmeldpunt newAaameldpunt)
        {
            dbQueries.EditAanmeldpunt(oldAanmeldpunt, newAaameldpunt);
        }

        public void SetAanmeldpuntActief(Aanmeldpunt aanmeldpunt, bool actief)
        {
            dbQueries.SetAanmeldpuntActief(aanmeldpunt, actief);
        }

        public void Init()
        {
            NotifyObserverDBConnected(dbQueries.TestDBConnection());
        }

        public void RegisterObserver(Observer observer)
        {
            observerList.Add(observer);
        }

        public void UnregisterObserver(Observer observer)
        {
            observerList.Remove(observer);
        }

        private void NotifyObserverDBConnected(bool connected)
        {
            foreach (Observer o in observerList)
                o.UpdateDBConnected(connected);
        }

        public Minderjarige GetMinderjarigeByNaam(string naam, string voornaam)
        {
            return dbQueries.GetMinderjarigeByNaam(naam, voornaam);
        }

        public void InsertNewMinderjarige(string naam, string voornaam)
        {
            int ID = GetAllMinderjarige().Count + 1;
            Minderjarige minderjarige = new Minderjarige(ID, naam, voornaam);

            dbQueries.InsertNewMinderjarige(minderjarige);
        }

        public void InsertNewAanmelding(MinderjarigeAanmeldpunt newAanmelding)
        {
            dbQueries.InsertNewAanmelding(newAanmelding);
        }
    }
}
