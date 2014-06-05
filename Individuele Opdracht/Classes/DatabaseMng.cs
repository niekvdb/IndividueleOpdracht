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
        public bool BestaatGebruiker(string voornaam)
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
                cmd.Parameters.Add("p_voornaam", OracleDbType.Varchar2, voornaam, ParameterDirection.Input);
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
        public bool MaakGebruiker(string voornaam, string wachtwoord)
        {
            OracleCommand cmd = new OracleCommand();
            try
            {
                this.Connect();
                cmd.Connection = this.conn;
                cmd.CommandText = "CreateAccount";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_voornaam", OracleDbType.Varchar2, voornaam, ParameterDirection.Input);
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
            List<Product> results = new List<Product>();
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

            return results;
        }
        /// <summary>
        /// Geeft een gebruiker terug 
        /// </summary>
        /// <param name="Voornaam"></param>
        /// <returns>gebruiker</returns>
        public Gebruiker GetGebruiker(string voornaam)
        {
            Gebruiker result = null;
            string sql = "SELECT * FROM Gebruiker WHERE Voornaam ='" + voornaam + "'";
            try
            {
                this.Connect();
                OracleCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                OracleDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    result = new Gebruiker(Convert.ToString(reader2["Voornaam"]), Convert.ToString(reader2["Achternaam"]), Convert.ToString(reader2["Wachtwoord"]));
                }
            }
            catch
            {
                return null;
            }

            return result;
        }
    }
}