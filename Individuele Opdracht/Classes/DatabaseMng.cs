namespace Individuele_Opdracht
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    public class DatabaseMng
    {
        private OracleConnection conn;

        public DatabaseMng()
        {
            this.conn = new OracleConnection();
        }
        /// <summary>
        /// Start verbinding met de database
        /// </summary>
        /// <returns>True: Operatie is gelukt. False: Operatie is niet gelukt.</returns>
        public bool Connect()
        {
            try
            {
                string id = "NIEK";
                string pw = "password";
                this.conn.ConnectionString = "User Id=" + id + ";Password=" + pw + ";Data Source=" + "localhost:1521" + ";";
                this.conn.Open();
            }
            catch
            {
                return false;
            }

            if (this.conn.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// sluit de connectie
        /// </summary>
        /// <returns>true als het gelukt is anders false</returns>
        public bool Disconnect()
        {
            try
            {
                this.conn.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// checkt of een gebruiker al bestaat in de database
        /// </summary>
        /// <param name="voornaam"></param>
        /// <returns>true als dat zo is anders false</returns>
        public bool BestaatGebruiker(string email)
        {
            OracleCommand cmd = new OracleCommand();
            try
            {
                this.Connect();
                cmd.Connection = this.conn;
                cmd.CommandText = "BestaatGebruiker";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("v_result", OracleDbType.Varchar2, 500));
                cmd.Parameters["v_result"].Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("p_voornaam", OracleDbType.Varchar2, email, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                string auth = cmd.Parameters["v_result"].Value.ToString();
                this.Disconnect();
                if (auth == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// maakt een nieuwe gebruiker aan
        /// </summary>
        /// <param name="voornaam"></param>
        /// <param name="wachtwoord"></param>
        /// <returns>true als het gelukt is anders false</returns>
        public bool MaakGebruiker(string email, string wachtwoord)
        {
            OracleCommand cmd = new OracleCommand();
            try
            {
                this.Connect();
                cmd.Connection = this.conn;
                cmd.CommandText = "CreateAccount";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_voornaam", OracleDbType.Varchar2, email, ParameterDirection.Input);
                cmd.Parameters.Add("p_pass", OracleDbType.Varchar2, wachtwoord, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.conn.Close();
            }

            return true;
      }
        /// <summary>
        /// Verkrijg alle producten
        /// </summary>
        /// <returns>lijst van producten</returns>
        public List<Product> GetAlleProducten()
        {
            this.Disconnect();  List<Product> results = new List<Product>();
            string sql = "SELECT * FROM Product";
            try
            {
                this.Connect();
                OracleCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Product(Convert.ToString(reader["Naam"]), Convert.ToDouble(reader["Prijs"]), Convert.ToInt32(reader["Score"])));
                }
            }
            catch
            {
                throw;
            }
            this.Disconnect();
            return results;
        }
        /// <summary>
        /// Geeft een gebruiker terug 
        /// </summary>
        /// <param name="Voornaam"></param>
        /// <returns>gebruiker</returns>
        public Gebruiker GetGebruiker(string email)
        {
            Gebruiker result = null;
            string sql = "SELECT * FROM Gebruiker WHERE Email ='" + email + "'";
            try
            {
                this.Connect();
                OracleCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                OracleDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    result = new Gebruiker(Convert.ToString(reader2["WACHTWOORD"]), Convert.ToString(reader2["EMAIL"]));
                }
            }
            catch
            {
                return null;
            }
            this.Disconnect();
            return result;
        }
        /// <summary>
        /// geeft product terug
        /// </summary>
        /// <param name="naam">naam van product</param>
        /// <returns></returns>
        public Product GetProduct(string naam)
        {
            Product result = null;
            string sql = "SELECT * FROM Product WHERE Naam ='" + naam + "'";
            try
            {
                this.Connect();
                OracleCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                OracleDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    result = new Product(Convert.ToString(reader2["Naam"]), Convert.ToDouble(reader2["Prijs"]),Convert.ToInt32(reader2["Score"]));
                }
            }
            catch
            {
                return null;
            }
            this.Disconnect();
            return result;
        }
        /// <summary>
        /// geeft lijst van reviews terug van een bepaald product
        /// </summary>
        /// <param name="naam">productnaam</param>
        /// <returns></returns>

        public List<Review> GetReview(string naam)
        {
            Review result=null;
            List<Review> results = new List<Review>();
            string sql = "SELECT * FROM Review WHERE PRODUCT_ID in (select PRODUCT_ID from PRODUCT where NAAM ='" + naam + "')";
            try
            {
                this.Connect();
                OracleCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                OracleDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    result=new Review(Convert.ToDateTime(reader2["Datum"]), Convert.ToString(reader2["REACTIE"]), Convert.ToString(reader2["TEKST"]),Convert.ToInt32(reader2["SCORE"]));
                    results.Add(result);
                }
            }
            catch
            {
                return null;
            }
            this.Disconnect();
            return results;
        }
        /// <summary>
        /// voegt review toe 
        /// </summary>
        /// <param name="gebruikerid">id van de gebruiker die de review plaatst</param>
        /// <param name="productnaam">naam van product dat bij de review hoort</param>
        /// <param name="titel">titel van de review</param>
        /// <param name="datum">datum van plaatsing van review</param>
        /// <param name="reactie">de review zelf</param>
        /// <param name="score">score van product</param>
        /// <returns>true als het gelukt is anders false</returns>
        public bool AddReview(int gebruikerid, string productnaam, string titel, DateTime datum, string reactie, int score )
        {
            OracleCommand cmd = new OracleCommand();
            try
            {
                this.Connect();
                cmd.Connection = this.conn;
                cmd.CommandText = "CreateReview";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_gebruikerid", OracleDbType.Int32, gebruikerid, ParameterDirection.Input);
                cmd.Parameters.Add("p_productnaam", OracleDbType.Varchar2, productnaam, ParameterDirection.Input);
                cmd.Parameters.Add("p_titel", OracleDbType.Varchar2, titel, ParameterDirection.Input);
                cmd.Parameters.Add("P_datum", OracleDbType.Date, datum, ParameterDirection.Input);
                cmd.Parameters.Add("p_reactie", OracleDbType.Varchar2, reactie, ParameterDirection.Input);
                cmd.Parameters.Add("p_score", OracleDbType.Varchar2, score, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;            
            }
            finally
            {
                this.conn.Close();
            }

            return true;
        }
        /// <summary>
        /// voegt vraag toe
        /// </summary>
        /// <param name="gebruikerid">id van gebruiker die vraag plaatst</param>
        /// <param name="productnaam">naam van product die bij de vraag hoort</param>
        /// <param name="tekst">de vraag zelf</param>
        /// <param name="datum">datum van plaatsing</param>
        /// <param name="titel">titel van de vraag</param>
        /// <returns>true als het gelukt is anders false</returns>
        public bool AddVraag(int gebruikerid, string productnaam, string tekst, DateTime datum, string titel)
        {
            OracleCommand cmd = new OracleCommand();
            try
            {
                this.Connect();
                cmd.Connection = this.conn;
                cmd.CommandText = "CreateVraag";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_gebruikerid", OracleDbType.Int32, gebruikerid, ParameterDirection.Input);
                cmd.Parameters.Add("p_productnaam", OracleDbType.Varchar2, productnaam, ParameterDirection.Input);
                cmd.Parameters.Add("p_titel", OracleDbType.Varchar2, titel, ParameterDirection.Input);
                cmd.Parameters.Add("P_datum", OracleDbType.Date, datum, ParameterDirection.Input);
                cmd.Parameters.Add("p_reactie", OracleDbType.Varchar2, tekst, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.conn.Close();
            }

            return true;
        }
        /// <summary>
        /// geeft lijst van vragen terug van een bepaald product
        /// </summary>
        /// <param name="naam">naam van product</param>
        /// <returns>lijst van vrage</returns>
        public List<Vraag> GetVraag(string naam)
        {
            Vraag result = null;
            List<Vraag> results = new List<Vraag>();
            string sql = "SELECT * FROM Vraag WHERE PRODUCT_ID in (select PRODUCT_ID from PRODUCT where NAAM ='" + naam + "')";
            try
            {
                this.Connect();
                OracleCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                OracleDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    result = new Vraag(Convert.ToDateTime(reader2["Datum"]), Convert.ToString(reader2["INHOUD"]), Convert.ToString(reader2["TITEL"]));
                    results.Add(result);
                }
            }
            catch
            {
                return null;
            }
            this.Disconnect();
            return results;
        }

    }
}