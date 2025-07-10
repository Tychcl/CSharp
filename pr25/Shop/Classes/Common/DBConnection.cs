using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using System.IO;

namespace Shop.Classes.Common
{
    public class DBConnection
    {
        public static readonly string Path = Directory.GetCurrentDirectory() + "\\DB.accdb";
        public static OleDbConnection Connection()
        {
            OleDbConnection oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path);
            oleDbConnection.Open();
            return oleDbConnection;
        }
        public static OleDbDataReader Query(string query, OleDbConnection oleDbConnection)
        {
            return new OleDbCommand(query, oleDbConnection).ExecuteReader();
        }
        public static void CloseConnection(OleDbConnection oleDbConnection)
        {
            oleDbConnection.Close();
        }
    }
}
