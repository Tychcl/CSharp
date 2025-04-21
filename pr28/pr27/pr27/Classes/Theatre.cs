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
        public string Adres{ get; set; }
        public string Work { get; set; }

        public Theatre(int id, string name, string adr, string work)
        {
            Id = id;
            Name = name;
            Adres = adr;
            Work = work;
        }
        public static void All()
        {
            List<Theatre> all = new List<Theatre>();
            MySqlConnection sqlConnection = Common.DBConnection.OpenConnection();
            if (sqlConnection == null)
            {
                return;
            }
            MySqlDataReader reader = Common.DBConnection.Query("SELECT * FROM pr28.Club", sqlConnection);
            if(reader != null)
                while (reader.Read())
                    all.Add(new Theatre(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)));
            Common.DBConnection.CloseConnection(sqlConnection);
            DBConnection.Theatres = all;
        }
    }
}
