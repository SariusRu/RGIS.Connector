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
            OpenConnection();
            CheckValidity(columnNames, columnTypes);
        }

        public bool CheckConnection()
        {
            throw new NotImplementedException();
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                if (!CheckConnection())
                {
                    return false;
                }
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool CheckValidity(string[][] columnNames, string[][] columnTypes)
        {
            throw new NotImplementedException();
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
