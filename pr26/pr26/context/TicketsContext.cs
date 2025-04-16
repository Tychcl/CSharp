using pr26.Classes;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipelines;

namespace pr26.Context
{
    public class TicketsContext : Ticket
    {
        public TicketsContext() { }
        public TicketsContext(int IdTicket, string Out, string In, int Price, DateTime TimeOut, DateTime TimeIn) : base(IdTicket, Out, In, Price, TimeOut, TimeIn) { }

        public static List<TicketsContext> All()
        {
            List<TicketsContext> allTickets = new List<TicketsContext>();
            MySqlConnection sqlConnection = Common.DBConnection.OpenConnection();
            if(sqlConnection == null)
            {
                return null;
            }
            MySqlDataReader reader = Common.DBConnection.Query("SELECT * FROM pr26.Tickets", sqlConnection);
            if (reader !=null)
                while (reader.Read())
                    allTickets.Add(new TicketsContext(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        DateTime.Parse(reader.GetString(4)),
                        DateTime.Parse(reader.GetString(5))));
            Common.DBConnection.CloseConnection(sqlConnection);
            return allTickets;
        }
    }
}
