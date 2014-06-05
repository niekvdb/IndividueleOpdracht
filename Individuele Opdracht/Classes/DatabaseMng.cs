using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Individuele_Opdracht
{
    public class DatabaseMng
    {
        private OracleConnection conn;

        public DatabaseMng()
        {
            conn = new OracleConnection();
        }
        /// <summary>
        /// Start verbinding met de database
        /// </summary>
        /// <returns>True: Operatie is gelukt. False: Operatie is niet gelukt.</returns>
        public bool Connect()
        {
            try
            {
                String id = "NIEK";
                String pw = "password";
                conn.ConnectionString = "User Id=" + id + ";Password=" + pw + ";Data Source=" + "localhost:1521" + ";";
                conn.Open();
            }
            catch
            {
                return false;
            }
            if (conn.State == ConnectionState.Open)
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
                conn.Close();
                conn.Dispose();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// controleert of dit de juiste login gegevens zijn
        /// </summary>
        /// <param name="rfid"></param>
        /// <param name="password"></param>
        /// <returns>true als het klopt anders false</returns>
        public bool AuthenticateLogin(string voornaam, string wachtwoord)
        {
            try
            {
                Connect();

                OracleCommand cmd = new OracleCommand("CHECKLOGIN", conn);
             
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("RETURN", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("p_voornaam", OracleDbType.Varchar2, voornaam, ParameterDirection.Input);
                cmd.Parameters.Add("p_pass", OracleDbType.Varchar2, wachtwoord, ParameterDirection.Input);

                
                cmd.ExecuteNonQuery();

                string auth = cmd.Parameters["RETURN"].Value.ToString();

                Disconnect();
                if (auth == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { throw; }
        }
        /// <summary>
        /// checkt of een gebruiker al bestaat in de database
        /// </summary>
        /// <param name="voornaam"></param>
        /// <returns>true als dat zo is anders false</returns>
        public bool BestaatGebruiker(string voornaam)
        {
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand("BestaatGebruiker", conn);
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("RETURN", OracleDbType.Varchar2, 10, ParameterDirection.ReturnValue);
                cmd.Parameters.Add("p_voornaam", OracleDbType.Varchar2, voornaam, ParameterDirection.Input);


                cmd.ExecuteNonQuery();

                string auth = cmd.Parameters["RETURN"].Value.ToString();

                Disconnect();
                if (auth == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// maakt een nieuwe gebruiker aan
        /// </summary>
        /// <param name="voornaam"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public bool MaakGebruiker(string voornaam,string wachtwoord)
        {
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand("CreateAccount", conn);
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("p_voornaam", OracleDbType.Varchar2, voornaam, ParameterDirection.Input);
                cmd.Parameters.Add("p_pass", OracleDbType.Varchar2, wachtwoord, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                Disconnect();
                return true;
            }
            catch
            {
               
                throw;
            }
        }
        /// <summary>
        /// Verkrijg alle producten
        /// </summary>
        /// <param name="voornaam"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public List<Product> GetAlleProducten()
        {
            List<Product> results = new List<Product>();
            string sql = "SELECT * FROM Product";
            try
            {
                Connect();
                OracleCommand command = conn.CreateCommand();
                command.CommandText = sql;
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Product(Convert.ToString(reader["Naam"]),
                        Convert.ToDouble(reader["Prijs"]), Convert.ToInt32(reader["Score"])));
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
        /// <returns></returns>
        public Gebruiker GetGebruiker(string voornaam)
        {
            Gebruiker result = null;
            string sql = "SELECT * FROM Gebruiker WHERE Voornaam ='" + voornaam + "'";
            try
            {
                Connect();
                OracleCommand command = conn.CreateCommand();
                command.CommandText = sql;
                 OracleDataReader reader2 = command.ExecuteReader();
                 while (reader2.Read())
                 {
                     result = new Gebruiker(Convert.ToString(reader2["Voornaam"]),
                                                         Convert.ToString(reader2["Achternaam"]),
                                                         Convert.ToString(reader2["Wachtwoord"]));
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