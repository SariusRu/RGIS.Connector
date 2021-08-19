using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGIS.Connector
{
    public class mySQLConnector : IDataConnection
    {
        private MySqlConnection connection;

        public mySQLConnector(string connectionString, string[][] columnNames, string[][] columnTypes)
        {
            connection = new MySqlConnection(connectionString);
            Logger.Logger.Log("Connection", "New Connection-String was accepted.", "");
            if (OpenConnection())
            {
                try
                {
                    CheckValidity(columnNames, columnTypes);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public bool CheckConnection()
        {
            Logger.Logger.Debug("Connection", "Creating Command", "");
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "show status like 'Conn%';";
            Logger.Logger.Debug("Connection", "Command: ", command.CommandText);
            string result = command.ExecuteScalar().ToString();
            Logger.Logger.Log("Connection", "Command executed", "");
            CloseConnection();
            if(result=="Connection_errors_accept")
            {
                Logger.Logger.Log("Connection", "Connection successfull", ">" + result + "< was returned");
                return true;
            }
            Logger.Logger.Error("Connection", "Connection failed", "CheckConnection");
            return false;
        }

        public bool OpenConnection()
        {
            try
            {
                Logger.Logger.Log("Connection", "Establishing Connection", "");
                connection.Open();
                Logger.Logger.Log("Connection", "Connection opened", "");
                if (!CheckConnection())
                {
                    Logger.Logger.Error("Connection", "Connection failed", "OpenConnection");
                    return false;
                }
                Logger.Logger.Log("Connection", "Connection succedded", "");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Logger.Logger.Error("Connection", "Cannot connect to server. Contact administrator", "");
                        break;

                    case 1045:
                        Logger.Logger.Error("Connection", "Invalid username/password, please try again", "");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                Logger.Logger.Log("Connection", "Closing Connection", "");
                connection.Close();
                Logger.Logger.Log("Connection", "Connection closed", "");
                return true;
            }
            catch (MySqlException ex)
            {
                Logger.Logger.Error("Connection", ex.Message, "");
                return false;
            }
        }

        public bool CheckValidity(string[][] columnNames, string[][] columnTypes)
        {
            Logger.Logger.Error("Not implemented", "CheckValidity", "");
            return false;
        }

        public bool Insert()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public List<string[]> Select()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool BackUp()
        {
            throw new NotImplementedException();
        }

        public bool Restore()
        {
            throw new NotImplementedException();
        }

        public string JSON(string tableName)
        {
            throw new NotImplementedException();
        }

        public string JSON(string[] tableNames)
        {
            throw new NotImplementedException();
        }
    }
}
