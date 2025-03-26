using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Shop.Classes
{
    public class ChildrenContext : Models.Children, IContext
    {
        public ChildrenContext() { }
        public ChildrenContext(int Id, int IdProduct, string Name, string Img, int Discount, int Price, int Age) : base(Id, IdProduct, Name, Img, Discount, Price, Age) { }
        public List<object> All()
        {
            List<Object> allShop = new ShopContext().All();
            List<Object> allChildren = new List<object>();

            OleDbConnection oleDbConnection = Common.DBConnection.Connection();
            OleDbDataReader reader = Common.DBConnection.Query("SELECT * FROM [Детские вещи]", oleDbConnection);
            if (reader.HasRows)
                while (reader.Read())
                {
                    ShopContext shopElement = allShop.Find(x => (x as ShopContext).Id == reader.GetInt32(1)) as ShopContext;
                    ChildrenContext newChildren = new ChildrenContext(
                        shopElement.Id,
                        reader.GetInt32(1),
                        shopElement.Name,
                        shopElement.Img,
                        shopElement.Discount,
                        shopElement.Price,
                        reader.GetInt32(2));
                    allChildren.Add(newChildren);
                }
            Common.DBConnection.CloseConnection(oleDbConnection);
            return allChildren;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save(bool update = false)
        {
            throw new NotImplementedException();
        }
    }
}
