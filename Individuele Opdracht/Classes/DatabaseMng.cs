using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Individuele_Opdracht.Classes
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
            Disconnect();
            try
            {
                String id = "sme";
                String pw = "password";
                conn.ConnectionString = "User Id=" + id + ";Password=" + pw + ";Data Source=" + " //192.168.19.163:1521" + ";";
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

        public bool AuthenticateLogin(string rfid, string password)
        {
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand("CHECKLOGIN", conn);
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("RETURN", OracleDbType.Varchar2, 20, ParameterDirection.ReturnValue);
                cmd.Parameters.Add("P_RFID", OracleDbType.Varchar2, rfid, ParameterDirection.Input);
                cmd.Parameters.Add("P_PASS", OracleDbType.Varchar2, password, ParameterDirection.Input);


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




    }
}