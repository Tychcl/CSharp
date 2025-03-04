using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr21.Classes.Common
{
    public class DBConnection
    {
        public static readonly string Path = @"D:\prak\pr21\pr21\abobs.accdb";

        public static OleDbConnection Connection()
        {
            // Создаём соединение
            OleDbConnection oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path);
            //Открываем соединение
            oleDbConnection.Open();
            return oleDbConnection;

        }
        public static OleDbDataReader Query(string SQL, OleDbConnection Connection)
        {
            // Создаём команду и выполняем её
            return new OleDbCommand(SQL, Connection).ExecuteReader();
        }
        public static void CloseConnection(OleDbConnection Connection) {
            // Закрываем подключение к БД
           
            Connection.Close();

        }
    }
}
