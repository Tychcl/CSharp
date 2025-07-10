using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Connect.Tabels;

namespace Connect
{
    public class DBConnection
    {
        public List<category> cats = new List<category>();
        public List<order> orders = new List<order>();
        public static readonly string DB = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Directory.GetCurrentDirectory() + "\\DB.accdb";
        public enum tabels
        {
            category, orders
        }
        public OleDbDataReader QueryAccess(string query)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(DB);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch
            {
                return null;
            }
        }

        public void LoadData(tabels zap)
        {
            try
            {
                OleDbDataReader itemQuery = QueryAccess("SELECT * FROM [" + zap.ToString() + "] ORDER BY [Код]");
                Console.WriteLine($"{zap} {zap.ToString()}");
                if (itemQuery == null)
                {
                    return;
                }
                if (zap.ToString() == "orders")
                {
                    orders.Clear();
                    while (itemQuery.Read())
                    {
                        order newEl = new order();
                        newEl.Id = Convert.ToInt32(itemQuery.GetValue(0));
                        newEl.FIO = Convert.ToString(itemQuery.GetValue(1));
                        newEl.Message = Convert.ToString(itemQuery.GetValue(2));
                        newEl.Adress = Convert.ToString(itemQuery.GetValue(3));
                        newEl.Date_Time = Convert.ToString(itemQuery.GetValue(4));
                        newEl.Email = Convert.ToString(itemQuery.GetValue(5));
                        newEl.Category = Convert.ToInt32(itemQuery.GetValue(6));
                        orders.Add(newEl);
                    }
                }
                if (zap.ToString() == "category")
                {
                    cats.Clear();
                    while (itemQuery.Read())
                    {
                        category newEl = new category();
                        newEl.Id = Convert.ToInt32(itemQuery.GetValue(0));
                        newEl.Cat = Convert.ToString(itemQuery.GetValue(1));
                        cats.Add(newEl);
                    }
                }
                if (itemQuery != null)
                {
                    itemQuery.Close();
                }
            }
            catch
            {
                Console.WriteLine("null");
            }
        }

        public int SetLastId(tabels tabel)
        {
            try
            {
                LoadData(tabel);
                switch (tabel.ToString())
                {
                    case "orders":
                        if (orders.Count >= 1)
                        {
                            int max = orders[0].Id;
                            max = orders.Max(x => x.Id);
                            return max + 1;
                        }
                        else return 1;
                    case "category":
                        if (cats.Count >= 1)
                        {
                            int max = cats[0].Id;
                            max = cats.Max(x => x.Id);
                            return max + 1;
                        }
                        else return 1;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }

        public bool ItsOnlyFIO(string str)
        {
            return Regex.Match(str, @"[а-яА-Я]*\s[а-яА-Я]*\s[а-яА-Я]*$").Success;
        }

        public bool ItsEmail(string str)
        {
            return Regex.Match(str, "^\\S+@\\S+\\.\\S+$").Success;
        }
    }
}
