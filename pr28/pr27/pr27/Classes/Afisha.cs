using pr27.Common;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace pr27.Classes
{
    public class Afisha
    {
        public int Id { get; set; }
        public int Club { get; set; }
        public string FIO { get; set; }
        public string Time { get; set; }

        public Afisha(int id, int theatre, string film, string time)
        {                     
            Id = id;          
            Club = theatre;
            FIO = film;
            Time = time;
        }

        public static void All()
        {
            List<Afisha> all = new List<Afisha>();
            MySqlConnection sqlConnection = Common.DBConnection.OpenConnection();
            if (sqlConnection == null)
            {
                return;
            }
            MySqlDataReader reader = Common.DBConnection.Query("SELECT * FROM pr28.Order", sqlConnection);
            if (reader != null)
                while (reader.Read())
                    all.Add(new Afisha(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetString(2),
                        reader.GetString(3)));
            Common.DBConnection.CloseConnection(sqlConnection);
            DBConnection.Afishas = all;
        }
    }
}
