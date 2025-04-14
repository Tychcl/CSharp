using pr26.Pages;
using pr26.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr26.Context
{
    public class TicketsContext : Classes.Ticket
    {
        public TicketsContext() { }
        public TicketsContext(int IdTicket, string Out, string In, int Price, string TimeOut, string TimeIn) : base(IdTicket, Out, In, Price, TimeOut, TimeIn) { }

        public static List<TicketsContext> All()
        {
            List<TicketsContext> allTickets = new List<TicketsContext>();
            SqlConnection sqlConnection = Common.DBConnection.OpenConnection();
            SqlDataReader reader = Common.DBConnection.Query("SELECT * FROM Tickets", sqlConnection);
            if (reader.HasRows)
                while (reader.Read())
                    allTickets.Add(new TicketsContext(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetString(4),
                        reader.GetString(5)));
            Common.DBConnection.CloseConnection(sqlConnection);
            return allTickets;
        }
    }
}
