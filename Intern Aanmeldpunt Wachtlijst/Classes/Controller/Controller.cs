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
                if (mja.AanmeldingActief)
                    totalDays += GetWachttijdInDagen(mja);
            }

            return totalDays / minderjarigenLijst.Count();
        }

        public double GetWachttijdInDagen(MinderjarigeAanmeldpunt mja)
        {
            double wachttijd = 0.0;
            if (mja.AanmeldingActief)
            {
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
            }
            return wachttijd;
        }

        public int GetWachttijdCount(List<MinderjarigeAanmeldpunt> minderjarigenLijst)
        {
            int wachtijdCount = 0;

            foreach (MinderjarigeAanmeldpunt mja in minderjarigenLijst)
            {
                if (mja.DatumOpneming < new DateTime(1970, 1, 1))
                    if (mja.AanmeldingActief)
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

        private void NotifyObserverDeletedAanmelding()
        {
            foreach (Observer o in observerList)
                o.UpdateDeletedAanmelding();
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

        public void AddNewAanmeldpunt(Aanmeldpunt newAanmeldpunt)
        {
            dbQueries.AddNewAanmeldpunt(newAanmeldpunt);
            NotifyObserverDeletedAanmelding();
        }

        public void InsertNewAanmelding(MinderjarigeAanmeldpunt newAanmelding)
        {
            dbQueries.InsertNewAanmelding(newAanmelding);
            NotifyObserverDeletedAanmelding();
        }

        public void DeleteAanmelding(MinderjarigeAanmeldpunt mja)
        {
            dbQueries.DeleteAanmelding(mja);
            NotifyObserverDeletedAanmelding();
        }

        public void SetAanmeldingActief(MinderjarigeAanmeldpunt mja, bool actief)
        {
            dbQueries.SetAanmeldingActief(mja, actief);
            NotifyObserverDeletedAanmelding();
        }

        public List<MinderjarigeAanmeldpunt> SorteerOp(string property, bool Ascending, List<MinderjarigeAanmeldpunt> mjaList)
        {
            List<MinderjarigeAanmeldpunt> sortedMjaList = mjaList;

            switch(property)
            {
                case "clmMinderjarige":
                    if (Ascending)
                        sortedMjaList = sortedMjaList.OrderBy(x => x.Minderjarige.Naam).ThenBy(x => x.Minderjarige.Voornaam).ToList();
                    else
                        sortedMjaList = sortedMjaList.OrderByDescending(x => x.Minderjarige.Naam).ThenByDescending(x => x.Minderjarige.Voornaam).ToList();
                    break;
                case "clmVoorziening":
                    if(Ascending)
                        sortedMjaList = sortedMjaList.OrderBy(x => x.Aanmeldpunt.Naam).ToList();
                    else
                        sortedMjaList = sortedMjaList.OrderByDescending(x => x.Aanmeldpunt.Naam).ToList();
                    break;
                case "clmConsulent":
                    if(Ascending)
                        sortedMjaList = sortedMjaList.OrderBy(x => x.Consulent.Naam).ThenBy(x => x.Consulent.Voornaam).ToList();
                    else
                        sortedMjaList = sortedMjaList.OrderByDescending(x => x.Minderjarige.Naam).ThenByDescending(x => x.Minderjarige.Voornaam).ToList();
                    break;
                case "clmAanmelding":
                    if(Ascending)
                        sortedMjaList = sortedMjaList.OrderBy(x => x.DatumAanmelding).ToList();
                    else
                        sortedMjaList = sortedMjaList.OrderByDescending(x => x.DatumAanmelding).ToList();
                    break;
                case "clmOpneming":
                    if(Ascending)
                        sortedMjaList = sortedMjaList.OrderBy(x => x.DatumOpneming).ToList();
                    else
                        sortedMjaList = sortedMjaList.OrderByDescending(x => x.DatumOpneming).ToList();
                    break;
                case "clmWachttijd":
                    if (Ascending)
                        sortedMjaList = sortedMjaList.OrderBy(x => x.Wachttijd).ToList();
                    else
                        sortedMjaList = sortedMjaList.OrderByDescending(x => x.Wachttijd).ToList();
                    break;
            }
            
            return sortedMjaList;

        }
    }
}
