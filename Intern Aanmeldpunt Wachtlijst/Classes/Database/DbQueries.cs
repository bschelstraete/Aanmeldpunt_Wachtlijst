using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_Aanmeldpunt_Wachtlijst.Classes.Model;

namespace Intern_Aanmeldpunt_Wachtlijst.Classes.Database
{
    public class DbQueries
    {
        public SqlConnectionStringBuilder Builder { get; private set; }
        private Consulent dummyConsulent = new Consulent(0, "", "");

        public DbQueries()
        {
            Builder = new SqlConnectionStringBuilder()
            {
                DataSource = "S198198\\SQLEXPRESS",
                InitialCatalog = "dbWachtlijst",
                UserID = "sa",
                Password = "wachtlijst"
            };
        }

        public bool TestDBConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        if (connection.State == System.Data.ConnectionState.Open)
                            return true;
                        else
                            return false;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex) && reader.HasRows)
                return reader[colIndex].ToString().TrimEnd();
            else
                return string.Empty;
        }

        private static bool SafeGetBool(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex) && reader.HasRows)
                return reader.GetBoolean(colIndex);
            else
                return true;
        }


        private static int SafeGetInt(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex) && reader.HasRows)
            {
                int dataNumber = 0;
                int.TryParse(reader[colIndex].ToString(), out dataNumber);
                return dataNumber;
            }
            else
                return 0;
        }

        private static DateTime SafeGetDate(SqlDataReader reader, int colIndex)
        {
            object sqlDatetime = reader[colIndex];
            DateTime? dt = (sqlDatetime == System.DBNull.Value)
                ? DateTime.MinValue
                : Convert.ToDateTime(sqlDatetime);

            return dt.Value;
        }

        public Aanmeldpunt GetAanmeldpunt(int id)
        {
            string commandText = "SELECT * FROM Aanmeldpunt WHERE aanmeldpuntID = " + id;
            return GetList<Aanmeldpunt>(GetAanmeldpunten, commandText).FirstOrDefault();
        }

        public List<Aanmeldpunt> GetAllAanmeldpunten()
        {
            string commandText = "SELECT * FROM Aanmeldpunt";
            return GetList<Aanmeldpunt>(GetAanmeldpunten, commandText);
        }

        public void EditAanmelding(MinderjarigeAanmeldpunt mja, MinderjarigeAanmeldpunt newAanmelding)
        {
            string commandText = "";

            if(newAanmelding.DatumOpneming > new DateTime(1970, 1, 1))
                commandText = "UPDATE MinderjarigeAanmeldpunt"
                                + " SET aanmeldpuntID = @aanmeldpunt, consulentID = @consulentID, datumAanmelding = @datumAanmelding, datumOpneming = @datumOpneming"
                                + " WHERE minderjarigeID = @minderjarigeID";
            else
                commandText = "UPDATE MinderjarigeAanmeldpunt"
                                + " SET aanmeldpuntID = @aanmeldpunt, consulentID = @consulentID, datumAanmelding = @datumAanmelding"
                                + " WHERE minderjarigeID = @minderjarigeID";

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("aanmeldpunt", newAanmelding.Aanmeldpunt.ID));
                    command.Parameters.Add(new SqlParameter("consulentID", newAanmelding.Consulent.ID));
                    command.Parameters.Add(new SqlParameter("datumAanmelding", newAanmelding.DatumAanmelding));
                    command.Parameters.Add(new SqlParameter("datumOpneming", newAanmelding.DatumOpneming));
                    command.Parameters.Add(new SqlParameter("minderjarigeID", mja.Minderjarige.ID));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Consulent GetConsulent(int id)
        {
            string commandText = "SELECT * FROM Consulent WHERE consulentID = " + id;
            return GetList<Consulent>(GetConsulenten, commandText).FirstOrDefault();
        }

        public Dienst GetDienstVanConsulent(int idConsulent)
        {
            string commandText = "SELECT * FROM ConsulentDienst WHERE consulentID = " + idConsulent;
            ConsulentDienst consulentInDienst = GetList<ConsulentDienst>(GetConsulentInDienst, commandText).FirstOrDefault();

            return consulentInDienst.Dienst;
        }

        public List<Consulent> GetConsulentInDienst(int idDienst)
        {
            string commandText = "SELECT * FROM ConsulentDienst WHERE dienstID = " + idDienst;
            List<ConsulentDienst> consulentenInDienst = GetList<ConsulentDienst>(GetConsulentInDienst, commandText);
            List<Consulent> consulentlijst = new List<Consulent>();

            foreach (ConsulentDienst cd in consulentenInDienst)
            {
                consulentlijst.Add(cd.Consult);
            }

            return consulentlijst;
        }

        public List<Consulent> GetAllConsulenten()
        {
            string commandText = "SELECT * FROM Consulent";
            return GetList<Consulent>(GetConsulenten, commandText);
        }

        public Dienst GetDienst(int id)
        {
            string commandText = "SELECT * FROM Dienst WHERE dienstID = " + id;
            return GetList<Dienst>(GetDiensten, commandText).FirstOrDefault();
        }

        public List<Dienst> GetAllDiensten()
        {
            string commandText = "SELECT * FROM Dienst";
            return GetList<Dienst>(GetDiensten, commandText);
        }

        public Minderjarige GetMinderjarige(int id)
        {
            string commandText = "SELECT * FROM Minderjarige WHERE minderjarigeID = " + id + " AND minderjarigeZichtbaar = 1";
            return GetList<Minderjarige>(GetMinderjarigen, commandText).FirstOrDefault();
        }

        public Minderjarige GetMinderjarigeByNaam(string naam, string voornaam)
        {
            string commandText = "SELECT * FROM Minderjarige WHERE minderjarigeNaam = '" + naam + "' AND minderjarigeVoornaam = '" + voornaam + "' AND minderjarigeZichtbaar = 1";
            return GetList<Minderjarige>(GetMinderjarigen, commandText).FirstOrDefault();
        }

        public List<Minderjarige> GetAllMinderjarige()
        {
            string commandText = "SELECT * FROM Minderjarige WHERE minderjarigeZichtbaar = 1";
            return GetList<Minderjarige>(GetMinderjarigen, commandText);
        }


        public List<MinderjarigeAanmeldpunt> GetMinderjarigeInAanmeldpunten(int idMinderjarige)
        {
            string commandText = "SELECT * FROM MinderjarigeAanmeldpunt WHERE minderjarigeID = " + idMinderjarige;
            return GetList<MinderjarigeAanmeldpunt>(GetMinderjarigenInAanmeldpunten, commandText);
        }

        public List<MinderjarigeAanmeldpunt> GetMinderjarigenAangemeldDoor(int idConsulent)
        {
            string commandText = "SELECT * FROM MinderjarigeAanmeldpunt WHERE consulentID = " + idConsulent;
            return GetList<MinderjarigeAanmeldpunt>(GetMinderjarigenInAanmeldpunten, commandText);
        }

        public List<MinderjarigeAanmeldpunt> GetMinderjarigenInAanmeldpunt(int idAanmeldpunt)
        {
            string commandText = "SELECT * FROM MinderjarigeAanmeldpunt WHERE aanmeldpuntID = " + idAanmeldpunt;
            return GetList<MinderjarigeAanmeldpunt>(GetMinderjarigenInAanmeldpunten, commandText);
        }

        public List<MinderjarigeAanmeldpunt> GetAllMinderjarigeInAanmeldpuntenVanAanmelder(int idConsulent)
        {
            string commandText = "SELECT * FROM MinderjarigeAanmeldpunt WHERE consulentID = " + idConsulent;
            return GetList<MinderjarigeAanmeldpunt>(GetMinderjarigenInAanmeldpunten, commandText);
        }

        public List<MinderjarigeAanmeldpunt> GetAllMinderjarigeInAanmeldpunten()
        {
            string commandText = "SELECT * FROM MinderjarigeAanmeldpunt";
            return GetList<MinderjarigeAanmeldpunt>(GetMinderjarigenInAanmeldpunten, commandText);
        }

        public List<MinderjarigeAanmeldpunt> GetMinderjarigenInDienst(int idDienst)
        {
            string commandText = "SELECT ma.minderjarigeID, ma.aanmeldpuntID, ma.consulentID, ma.datumAanmelding, ma.datumOpneming, ma.aanmeldingActief "
                                  + "FROM MinderjarigeAanmeldpunt ma "
                                  + "JOIN ConsulentDienst cd "
                                  + "ON ma.consulentID = cd.consulentID "
                                  + "WHERE cd.dienstID = " + idDienst;
            return GetList<MinderjarigeAanmeldpunt>(GetMinderjarigenInAanmeldpunten, commandText);
        }

        public int GetMinderjarigeCountInDienst(int idDienst)
        {
            string commandText = "SELECT COUNT(*) FROM MinderjarigeAanmeldpunt ma "
                                  + "JOIN ConsulentDienst cd "
                                  + "ON ma.consulentID = cd.consulentID "
                                  + "WHERE cd.dienstID = " + idDienst;

            return GetCount(commandText);
        }

        public List<MinderjarigeAanmeldpunt> GetMinderjarigeBetweenDatesInDienst(Dienst dienst, DateTime van, DateTime tot)
        {
            string vanString = van.Date.ToString("yyyyMMdd");
            string totString = tot.Date.ToString("yyyyMMdd");

            string commandText = "SELECT* FROM MinderjarigeAanmeldpunt ma "
                                + "JOIN ConsulentDienst cd ON ma.consulentID = cd.consulentID "
                                + "WHERE cd.dienstID = " + dienst.ID + " "
                                + "AND ((datumAanmelding > '" + vanString + "' "
                                + "AND datumOpneming < '" + totString + "') "
                                + "OR (datumAanmelding > '" + vanString + "' "
                                + "AND datumOpneming IS NULL)) ";

            return GetList<MinderjarigeAanmeldpunt>(GetMinderjarigenInAanmeldpunten, commandText);
        }


        public List<MinderjarigeAanmeldpunt> GetMinderjarigeBetweenDatesInAanmeldpunt(Aanmeldpunt aanmeldpunt, DateTime van, DateTime tot)
        {
            string vanString = van.Date.ToString("yyyyMMdd");
            string totString = tot.Date.ToString("yyyyMMdd");

            string commandText = "SELECT* FROM MinderjarigeAanmeldpunt "
                                + "WHERE aanmeldpuntID = " + aanmeldpunt.ID + " "
                                + "AND ((datumAanmelding > '" + vanString + "' "
                                + "AND datumOpneming < '" + totString + "') "
                                + "OR (datumAanmelding > '" + vanString + "' "
                                + "AND datumOpneming IS NULL)) ";

            return GetList<MinderjarigeAanmeldpunt>(GetMinderjarigenInAanmeldpunten, commandText);
        }

        private int GetCount(string commandText)
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        connection.Open();
                        command.CommandText = commandText;
                        count = (int)command.ExecuteScalar();
                    }
                    catch (NullReferenceException)
                    {
                        return 0;
                    }
                }
            }

            return count;
        }

        public int GetLastIdMinderjarige()
        {
            string commandText = "SELECT TOP 1 * FROM Minderjarige "
                                + "ORDER BY Minderjarige.minderjarigeID DESC";
            return GetList<Minderjarige>(GetMinderjarigen, commandText).FirstOrDefault().ID;
        }

        public List<MinderjarigeAanmeldpunt> FindMinderjarigeAanmelding(string naamZoeken)
        {
            string commandText = "SELECT * FROM Minderjarige WHERE minderjarigeVoornaam "
                    + "LIKE '%" + naamZoeken + "%' "
                    + "OR minderjarigeNaam LIKE '%" + naamZoeken + "%'";
            List<Minderjarige> mjResult = GetList<Minderjarige>(GetMinderjarigen, commandText);
            List<MinderjarigeAanmeldpunt> aanmeldingen = new List<MinderjarigeAanmeldpunt>();
            foreach(Minderjarige mj in mjResult)
            {
                aanmeldingen.AddRange(GetMinderjarigeInAanmeldpunten(mj.ID));
            }

            return aanmeldingen;
        }

        private List<T> GetList<T>(Func<SqlCommand, List<T>> GetResults, string commandText)
        {
            List<T> resultList = new List<T>();
            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = commandText;
                    command.CommandType = System.Data.CommandType.Text;

                    resultList = GetResults(command);
                }
            }
      
            return resultList;
        }

        private List<Aanmeldpunt> GetAanmeldpunten(SqlCommand command)
        {
            List<Aanmeldpunt> aanmeldpuntLijst = new List<Aanmeldpunt>();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    int id = SafeGetInt(dr, 0);
                    string naam = SafeGetString(dr, 1);
                    string adres = SafeGetString(dr, 2);
                    int telefoonnummer = SafeGetInt(dr, 3);
                    string email = SafeGetString(dr, 4);
                    string contactpersoon = SafeGetString(dr, 5);
                    bool actief = SafeGetBool(dr, 6);
                    Aanmeldpunt aanmeldpunt = new Aanmeldpunt(id, naam, adres, telefoonnummer, email, contactpersoon, actief);
                    aanmeldpuntLijst.Add(aanmeldpunt);
                }
            }

            return aanmeldpuntLijst;
        }

   
        private List<Consulent> GetConsulenten(SqlCommand command)
        {
            List<Consulent> consulentLijst = new List<Consulent>();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    int id = SafeGetInt(dr, 0);
                    string naam = SafeGetString(dr, 1);
                    string voornaam = SafeGetString(dr, 2);

                    Consulent consulent = new Consulent(id, naam, voornaam);
                    consulentLijst.Add(consulent);
                }
            }

                return consulentLijst;
        }

        public void AddNewConsulent(string voornaam, string familienaam, Dienst dienst)
        {
            int ID = GetAllConsulenten().Last().ID + 1;
            string commandText = "INSERT INTO Consulent "
                                + "VALUES(@ID, @naam, @voornaam)";

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("ID", ID));
                    command.Parameters.Add(new SqlParameter("naam", familienaam));
                    command.Parameters.Add(new SqlParameter("voornaam", voornaam));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            InsertConsulentIntoDienst(ID, dienst.ID);
        }

        public void InsertConsulentIntoDienst(int consulentID, int dienstID)
        {
            string commandText = "INSERT INTO ConsulentDienst "
                    + "VALUES(@consulentID, @dienstID)";
            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("consulentID", consulentID));
                    command.Parameters.Add(new SqlParameter("dienstID", dienstID));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SetConsulentActief(Consulent consulent, bool actief)
        {
            //
        }

        public void EditConsulent(Consulent oldConsulent, Consulent newConsulent)
        {
            string commandText = "UPDATE Consulent "
                         + "SET consulentNaam = @naam, consulentVoornaam = @voornaam "
                         +"WHERE consulentID = @ID";

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("naam", newConsulent.Naam));
                    command.Parameters.Add(new SqlParameter("voornaam", newConsulent.Voornaam));
                    command.Parameters.Add(new SqlParameter("ID", oldConsulent.ID));
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<Dienst> GetDiensten(SqlCommand command)
        {
            List<Dienst> dienstLijst = new List<Dienst>();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    int id = SafeGetInt(dr, 0);
                    string naam = SafeGetString(dr, 1);
                    string adres = SafeGetString(dr, 2);
                    int telefoonnummer = SafeGetInt(dr, 3);

                    Dienst dienst = new Dienst(id, naam, adres, telefoonnummer);
                    dienstLijst.Add(dienst);
                }
            }

                return dienstLijst;
        }

        private List<Minderjarige> GetMinderjarigen(SqlCommand command)
        {
            List<Minderjarige> minderjarigeLijst = new List<Minderjarige>();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    int id = SafeGetInt(dr, 0);
                    string naam = SafeGetString(dr, 1);
                    string voornaam = SafeGetString(dr, 2);

                    Minderjarige minderjarige = new Minderjarige(id, naam, voornaam);
                    minderjarigeLijst.Add(minderjarige);
                }
            }

            return minderjarigeLijst;
        }

        private List<ConsulentDienst> GetConsulentInDienst(SqlCommand command)
        {
            List<ConsulentDienst> ConsulentInDienstLijst = new List<ConsulentDienst>();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    int idConsulent = SafeGetInt(dr, 0);
                    int idDienst = SafeGetInt(dr, 1);

                    Consulent consulent = GetConsulent(idConsulent);
                    Dienst dienst = GetDienst(idDienst);

                    ConsulentDienst consulentDienst = new ConsulentDienst(consulent, dienst);
                    ConsulentInDienstLijst.Add(consulentDienst);
                }
            }

            return ConsulentInDienstLijst;
        }



        private List<MinderjarigeAanmeldpunt> GetMinderjarigenInAanmeldpunten(SqlCommand command)
        {
            List<MinderjarigeAanmeldpunt> MinderjarigeInAanmeldpuntLijst = new List<MinderjarigeAanmeldpunt>();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                while(dr.Read())
                {
                    int idMinderjarige = SafeGetInt(dr, 0);
                    int idAanmeldpunt = SafeGetInt(dr, 1);
                    int idConsulent = SafeGetInt(dr, 2);
                    DateTime datumAanmelding = SafeGetDate(dr, 3);
                    DateTime datumOpneming = SafeGetDate(dr, 4);
                    bool aanmeldingActief = SafeGetBool(dr, 5);

                    Minderjarige minderjarige = GetMinderjarige(idMinderjarige);
                    Aanmeldpunt aanmeldpunt = GetAanmeldpunt(idAanmeldpunt);
                    Consulent consulent = GetConsulent(idConsulent);

                    if (consulent == null)
                        consulent = dummyConsulent;

                    MinderjarigeAanmeldpunt minderjarigeInAanmeldpunt = new MinderjarigeAanmeldpunt(minderjarige, aanmeldpunt, consulent, datumAanmelding, datumOpneming, aanmeldingActief);
                    MinderjarigeInAanmeldpuntLijst.Add(minderjarigeInAanmeldpunt);
                }
            }

            return MinderjarigeInAanmeldpuntLijst;
        }

        public void EditAanmeldpunt(Aanmeldpunt oldAanmeldpunt, Aanmeldpunt newAanmeldpunt)
        {
            string commandText = "UPDATE Aanmeldpunt "
               + "SET aanmeldpuntNaam = @naam, aanmeldpuntAdres = @adres, aanmeldpuntTelefoonnummer = @telefoonnummer, aanmeldpuntEmail = @email, aanmeldpuntContactpersoon = @contact "
               + "WHERE aanmeldpuntID = @ID ";

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("naam", newAanmeldpunt.Naam));
                    command.Parameters.Add(new SqlParameter("adres", newAanmeldpunt.Adres));
                    command.Parameters.Add(new SqlParameter("telefoonnummer", newAanmeldpunt.Telefoonnummer));
                    command.Parameters.Add(new SqlParameter("email", newAanmeldpunt.Email));
                    command.Parameters.Add(new SqlParameter("contact", newAanmeldpunt.Contactpersoon));
                    command.Parameters.Add(new SqlParameter("ID", oldAanmeldpunt.ID));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SetAanmeldpuntActief(Aanmeldpunt aanmeldpunt, bool actief)
        {
            string commandText = "UPDATE Aanmeldpunt "
                        + "SET aanmeldpuntVisisble = @actief "
                        + "WHERE aanmeldpuntID = @ID";
            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("actief", actief));
                    command.Parameters.Add(new SqlParameter("ID", aanmeldpunt.ID));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertNewMinderjarige(Minderjarige minderjarige)
        {
            string commandText = "INSERT INTO Minderjarige(minderjarigeID, minderjarigeNaam, minderjarigeVoornaam) "
                + "VALUES(@minderjarigeID, @minderjarigeNaam, @minderjarigeVoornaam)";

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("minderjarigeID", minderjarige.ID));
                    command.Parameters.Add(new SqlParameter("minderjarigeNaam", minderjarige.Naam));
                    command.Parameters.Add(new SqlParameter("minderjarigeVoornaam", minderjarige.Voornaam));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        } 


        public void AddNewAanmeldpunt(Aanmeldpunt ap)
        {
            int ID = GetAllAanmeldpunten().Last().ID + 1;
            string commandText = "INSERT INTO Aanmeldpunt "
                + "VALUES(@APID, @APNAAM, @APADRES, @APNR, @APMAIL, @APPERSOON, @APACT)";

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("APID", ID));
                    command.Parameters.Add(new SqlParameter("APNAAM", ap.Naam));
                    command.Parameters.Add(new SqlParameter("APADRES", ap.Adres));
                    command.Parameters.Add(new SqlParameter("APNR", ap.Telefoonnummer));
                    command.Parameters.Add(new SqlParameter("APMAIL", ap.Email));
                    command.Parameters.Add(new SqlParameter("APPERSOON", ap.Contactpersoon));
                    command.Parameters.Add(new SqlParameter("APACT", ap.Actief));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertNewAanmelding(MinderjarigeAanmeldpunt nieuweAanmelding)
        {
            string commandText = "";

            if(nieuweAanmelding.Consulent == null)
            {
                commandText = "INSERT INTO MinderjarigeAanmeldpunt(minderjarigeID, aanmeldpuntID, datumAanmelding) "
                    + "VALUES(@MJID, @APID, @DATAANMELDING)";
            }
            else
            {
                commandText = "INSERT INTO MinderjarigeAanmeldpunt(minderjarigeID, aanmeldpuntID, consulentID, datumAanmelding) "
                    + "VALUES(@MJID, @APID, @CONID, @DATAANMELDING)";
            }


            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("MJID", nieuweAanmelding.Minderjarige.ID));
                    command.Parameters.Add(new SqlParameter("APID", nieuweAanmelding.Aanmeldpunt.ID));
                    if(nieuweAanmelding.Consulent != null)
                        command.Parameters.Add(new SqlParameter("CONID", nieuweAanmelding.Consulent.ID));
                    command.Parameters.Add(new SqlParameter("DATAANMELDING", nieuweAanmelding.DatumAanmelding));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAanmelding(MinderjarigeAanmeldpunt mja)
        {
            string commandText = "";

            if (mja.Consulent == null)
            {
                commandText = "DELETE FROM MinderjarigeAanmeldpunt "
                    + "WHERE minderjarigeID = @MJID "
                    + "AND aanmeldpuntID = @APID "
                    + "AND datumAanmelding = @DATAANMELDING ";
            }
            else
            {
                commandText = "DELETE FROM MinderjarigeAanmeldpunt "
                    + "WHERE minderjarigeID = @MJID "
                    + "AND aanmeldpuntID = @APID "
                    + "AND consulentID = @CONID "
                    + "AND datumAanmelding = @DATAANMELDING ";
            }

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("MJID", mja.Minderjarige.ID));
                    command.Parameters.Add(new SqlParameter("APID", mja.Aanmeldpunt.ID));
                    if (mja.Consulent != null)
                        command.Parameters.Add(new SqlParameter("CONID", mja.Consulent.ID));
                    command.Parameters.Add(new SqlParameter("DATAANMELDING", mja.DatumAanmelding));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void SetAanmeldingActief(MinderjarigeAanmeldpunt mja, bool actief)
        {
            string commandText = "";

            if (mja.Consulent == null)
            {
                commandText = "UPDATE MinderjarigeAanmeldpunt "
                    + "SET aanmeldingActief = @ACTIEF "
                    + "WHERE minderjarigeID = @MJID "
                    + "AND aanmeldpuntID = @APID "
                    + "AND datumAanmelding = @DATAANMELDING ";
            }
            else
            {
                commandText = "UPDATE MinderjarigeAanmeldpunt "
                    + "SET aanmeldingActief = @ACTIEF "
                    + "WHERE minderjarigeID = @MJID "
                    + "AND aanmeldpuntID = @APID "
                    + "AND consulentID = @CONID "
                    + "AND datumAanmelding = @DATAANMELDING ";
            }

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("ACTIEF", actief));
                    command.Parameters.Add(new SqlParameter("MJID", mja.Minderjarige.ID));
                    command.Parameters.Add(new SqlParameter("APID", mja.Aanmeldpunt.ID));
                    if (mja.Consulent != null)
                        command.Parameters.Add(new SqlParameter("CONID", mja.Consulent.ID));
                    command.Parameters.Add(new SqlParameter("DATAANMELDING", mja.DatumAanmelding));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditMinderjarige(Minderjarige oudMinderjarige, Minderjarige newMinderjarige)
        {
            string commandText = "UPDATE Minderjarige "
                                + "SET minderjarigeNaam = @naam, minderjarigeVoornaam = @voornaam "
                                + "WHERE minderjarigeID = @ID";

            using (SqlConnection connection = new SqlConnection(Builder.ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqlParameter("naam", newMinderjarige.Naam));
                    command.Parameters.Add(new SqlParameter("voornaam", newMinderjarige.Voornaam));
                    command.Parameters.Add(new SqlParameter("ID", oudMinderjarige.ID));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }



    }
}
