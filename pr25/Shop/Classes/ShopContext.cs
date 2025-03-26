using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Classes
{
    public class ShopContext: Models.Shop, IContext
    {
        public ShopContext() { }
        public ShopContext(int Id, string Name, int Price, string Img, int Discount) : base(Id, Name, Price, Img, Discount) { }
        public List<Object> All()
        {
            List<object> allShop = new List<object>();

            OleDbConnection oleDbConnection = Common.DBConnection.Connection();
            OleDbDataReader reader = Common.DBConnection.Query("SELECT * FROM [Товар]", oleDbConnection);
            if (reader.HasRows)
                while (reader.Read())
                {
                    ShopContext newShop = new ShopContext(
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetInt32(2),
                        Img = reader.GetString(3),
                        Discount = reader.GetInt32(4));
                    allShop.Add(newShop);
                }
            Common.DBConnection.CloseConnection(oleDbConnection);
            return allShop;
        }

        public void Delete()
        {
            OleDbConnection OleDbConnection = Common.DBConnection.Connection();
            OleDbDataReader reader = Common.DBConnection.Query($"DELETE FROM [Товар] WHERE Id = {this.Id}", OleDbConnection);

        }

        public void Save(bool update = false)
        {
            OleDbConnection oleDbConnection = Common.DBConnection.Connection();
            if (update)
            {
                OleDbDataReader reader = Common.DBConnection.Query($"UPDATE [Товар] SET Name = '{this.Name}', Price = {this.Price}", oleDbConnection);
                Common.DBConnection.CloseConnection(oleDbConnection);
            }
            else
            {
                OleDbDataReader reader = Common.DBConnection.Query($"INSERT [Товар](Name,Price) VALUES('{this.Name}',{this.Price})", oleDbConnection);
                Common.DBConnection.CloseConnection(oleDbConnection);
            }
        }
    }
}
