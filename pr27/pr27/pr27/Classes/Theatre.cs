using pr27.Common;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipelines;

namespace pr27.Classes
{
    public class Theatre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomCount{ get; set; }
        public int PlaceCount { get; set; }

        public Theatre(int id, string name, int RC, int PC)
        {
            Id = id;
            Name = name;
            RoomCount = RC;
            PlaceCount = PC;
        }
        public static void All()
        {
            List<Theatre> all = new List<Theatre>();
            MySqlConnection sqlConnection = Common.DBConnection.OpenConnection();
            if (sqlConnection == null)
            {
                return;
            }
            MySqlDataReader reader = Common.DBConnection.Query("SELECT * FROM pr27.Theatre", sqlConnection);
            if(reader != null)
                while (reader.Read())
                    all.Add(new Theatre(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3)));
            Common.DBConnection.CloseConnection(sqlConnection);
            DBConnection.Theatres = all;
        }
    }
}
