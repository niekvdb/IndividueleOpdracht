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
                Connect();
                cmd.Connection = conn;
                cmd.CommandText = "BestaatGebruiker";
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.Add("p_voornaam", OracleDbType.Varchar2, voornaam, ParameterDirection.Input);
                cmd.Parameters.Add(new OracleParameter("v_result", OracleDbType.Varchar2));
                cmd.Parameters["v_result"].Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                string auth = cmd.Parameters["v_result"].Value.ToString();

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
        public bool MaakGebruiker(string voornaam, string wachtwoord)
        {
            OracleCommand cmd = new OracleCommand();
            try
            {
                Connect();
                cmd.Connection = conn;
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
                conn.Close();

            }
            return true;
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