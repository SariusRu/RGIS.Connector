using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGIS.Connector
{
    public interface IDataConnection
    {
        public bool CheckValidity(string[][] columnNames, string[][] columnTypes);

        public bool CheckConnection();
        public bool OpenConnection();
        public bool CloseConnection();
        public bool Insert();
        public bool Update();
        public bool Delete();
        public List<string[]> Select();
        public int Count();
        public bool BackUp();
        public bool Restore();
        public string JSON(string tableName);
        public string JSON(string[] tableNames);
    }
}
