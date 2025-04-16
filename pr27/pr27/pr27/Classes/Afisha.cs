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
        public int Theatre { get; set; }
        public string Film { get; set; }
        public string Time { get; set; }
        public int Price { get; set; }

        public Afisha(int id, int theatre, string film, string time, int price)
        {                     
            Id = id;          
            Theatre = theatre;
            Film = film;
            Time = time;
            Price = price;
        }

        public static void All()
        {
            List<Afisha> all = new List<Afisha>();
            MySqlConnection sqlConnection = Common.DBConnection.OpenConnection();
            if (sqlConnection == null)
            {
                return;
            }
            MySqlDataReader reader = Common.DBConnection.Query("SELECT * FROM pr27.Afisha", sqlConnection);
            if (reader != null)
                while (reader.Read())
                    all.Add(new Afisha(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetInt32(4)));
            Common.DBConnection.CloseConnection(sqlConnection);
            DBConnection.Afishas = all;
        }
    }
}
