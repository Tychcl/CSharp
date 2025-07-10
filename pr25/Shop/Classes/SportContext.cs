using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Interfaces;
using Shop.Models;
using System.Windows;

namespace Shop.Classes
{
    internal class SportContext : Sport, IContext
    {
        public SportContext() { }
        public SportContext(int Id, int IdProduct, string Name, int Price, string Img, int Discount, int Size) : base(Id, Name, Price, Img, Discount, Size) { }


        public List<object> All()
        {
            List<object> allShop = new ShopContext().All();
            List<object> allSport = new List<object>();

            OleDbConnection oleDbConnection = Common.DBConnection.Connection();
            OleDbDataReader reader = Common.DBConnection.Query("SELECT * FROM [Спорт]", oleDbConnection);
            if (reader.HasRows)
                while (reader.Read())
                {
                    ShopContext shop = allShop.Find(x => (x as ShopContext).Id == reader.GetInt32(2)) as ShopContext;
                    SportContext newProduct = new SportContext(
                        shop.Id,
                        reader.GetInt32(2),
                        shop.Name,
                        shop.Price,
                        shop.Img,
                        shop.Discount,
                        reader.GetInt32(1));
                    allSport.Add(newProduct);
                }
            Common.DBConnection.CloseConnection(oleDbConnection);
            return allSport;
        }

        public void Delete()
        {
            OleDbConnection oleDbConnection = Common.DBConnection.Connection();
            OleDbDataReader reader = Common.DBConnection.Query($"DELETE FROM [Спорт] WHERE Id = {this.Id}", oleDbConnection);

        }

        public void Save(bool update = false)
        {
            OleDbConnection OleDbConnection = Common.DBConnection.Connection();
            if (update)
            {
                OleDbDataReader reader = Common.DBConnection.Query($"UPDATE [Спорт] SET Name = '{this.Name}', Price = {this.Price}", OleDbConnection);
                Common.DBConnection.CloseConnection(OleDbConnection);
            }
            else
            {
                OleDbDataReader reader = Common.DBConnection.Query($"INSERT Shop(Name,Price) VALUES('{this.Name}',{this.Price})", OleDbConnection);
                Common.DBConnection.CloseConnection(OleDbConnection);
            }
        }
    }
}
