using DataBase.Tabels;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataBase
{
    public class Connect
    {
        public static readonly string DB = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\DB.accdb";
        public enum tabels
        {
            Fond, Library, Refill, Staff, Type
        }
        public List<Fond> Fonds = new List<Fond>();
        public List<Library> Librares = new List<Library>();
        public List<Refill> Refills = new List<Refill>();
        public List<Staff> Staffs = new List<Staff>();
        public List<Tabels.Type> Types = new List<Tabels.Type>();

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
                OleDbDataReader itemQuery = QueryAccess("SELECT * FROM [" + zap.ToString() + "] ORDER BY [Id]");
                if (itemQuery == null)
                {
                    return;
                }
                if (zap.ToString() == "Fond")
                {
                    Fonds.Clear();
                    while (itemQuery.Read())
                    {
                        Fonds.Add(new Fond(Convert.ToInt32(itemQuery.GetValue(0)),
                            Convert.ToString(itemQuery.GetValue(1)),
                            Convert.ToInt32(itemQuery.GetValue(2)),
                            Convert.ToInt32(itemQuery.GetValue(3)),
                            Convert.ToInt32(itemQuery.GetValue(4)),
                            Convert.ToInt32(itemQuery.GetValue(5)),
                            Convert.ToInt32(itemQuery.GetValue(6)),
                            Convert.ToInt32(itemQuery.GetValue(7)),
                            Convert.ToInt32(itemQuery.GetValue(8))));
                    }
                }
                if (zap.ToString() == "Library")
                {
                    Librares.Clear();
                    while (itemQuery.Read())
                    {
                        Librares.Add(new Library(Convert.ToInt32(itemQuery.GetValue(0)),
                            Convert.ToString(itemQuery.GetValue(1)),
                            Convert.ToString(itemQuery.GetValue(2)),
                            Convert.ToString(itemQuery.GetValue(3))));
                    }
                }
                if (zap.ToString() == "Refill")
                {
                    Refills.Clear();
                    while (itemQuery.Read())
                    {
                        Refills.Add(new Refill(Convert.ToInt32(itemQuery.GetValue(0)),
                            Convert.ToInt32(itemQuery.GetValue(1)),
                            Convert.ToInt32(itemQuery.GetValue(2)),
                            Convert.ToInt32(itemQuery.GetValue(3)),
                            Convert.ToString(itemQuery.GetValue(4)),
                            Convert.ToString(itemQuery.GetValue(5)),
                            Convert.ToString(itemQuery.GetValue(6)),
                            Convert.ToString(itemQuery.GetValue(7)),
                            Convert.ToInt32(itemQuery.GetValue(8))));
                    }
                }
                if (zap.ToString() == "Staff")
                {
                    Staffs.Clear();
                    while (itemQuery.Read())
                    {
                        Staffs.Add(new Staff(Convert.ToInt32(itemQuery.GetValue(0)),
                            Convert.ToString(itemQuery.GetValue(1)),
                            Convert.ToString(itemQuery.GetValue(2)),
                            Convert.ToString(itemQuery.GetValue(3)),
                            Convert.ToInt32(itemQuery.GetValue(4)),
                            Convert.ToString(itemQuery.GetValue(5)),
                            Convert.ToString(itemQuery.GetValue(6)),
                            Convert.ToString(itemQuery.GetValue(7)),
                            Convert.ToString(itemQuery.GetValue(8)),
                            Convert.ToInt32(itemQuery.GetValue(9))));
                    }
                }
                if (zap.ToString() == "Type")
                {
                    Types.Clear();
                    while (itemQuery.Read())
                    {
                        Types.Add(new Tabels.Type(Convert.ToInt32(itemQuery.GetValue(0)),
                            Convert.ToString(itemQuery.GetValue(1))));
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
                    case "Fond":
                        if (Fonds.Count >= 1)
                        {
                            int max = Fonds[0].Id;
                            max = Fonds.Max(x => x.Id);
                            return max + 1;
                        }
                        else return 1;
                    case "Library":
                        if (Librares.Count >= 1)
                        {
                            int max = Librares[0].Id;
                            max = Librares.Max(x => x.Id);
                            return max + 1;
                        }
                        else return 1;
                    case "Refill":
                        if (Refills.Count >= 1)
                        {
                            int max = Refills[0].Id;
                            max = Refills.Max(x => x.Id);
                            return max + 1;
                        }
                        else return 1;
                    case "Staff":
                        if (Staffs.Count >= 1)
                        {
                            int max = Staffs[0].Id;
                            max = Staffs.Max(x => x.Id);
                            return max + 1;
                        }
                        else return 1;
                    case "Type":
                        if (Types.Count >= 1)
                        {
                            int max = Types[0].Id;
                            max = Types.Max(x => x.Id);
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

        public bool InsUpdDel(Fond el, int x = 0)
        {
            if (x == 0)
            {
                var pc = QueryAccess($"INSERT INTO [{tabels.Fond}]([Id], [Name], [Library], [Books], [Paper], [Magazine], [Collection], [Dissertation], [Report]) VALUES ({el.Id.ToString()}, '{el.Name}', {el.Library.ToString()}, {el.Books.ToString()}, {el.Paper.ToString()}, {el.Magazine.ToString()}, {el.Collection.ToString()}, {el.Dissertation.ToString()}, {el.Report.ToString()})");
                pc.Close();
                return pc != null;
            }
            else if (x == 1)
            {
                var pc = QueryAccess($"UPDATE [{tabels.Fond}] SET [Name] = '{el.Name}', [Library] = {el.Library.ToString()}, [Books] = {el.Books.ToString()}, [Paper] = {el.Paper.ToString()}, [Magazine] = {el.Magazine.ToString()}, [Collection] = {el.Collection.ToString()}, [Dissertation] = {el.Dissertation.ToString()}, [Report] = {el.Report.ToString()}  WHERE Id = {el.Id}");
                pc.Close();
                return pc != null;
            }
            else
            {
                var pc = QueryAccess($"DELETE FROM [{tabels.Fond}] WHERE [Id] = {el.Id.ToString()}");
                pc.Close();
                return pc != null;
            }
        }
        public bool InsUpdDel(Library el, int x = 0)
        {
            if (x == 0)
            {
                var pc = QueryAccess($"INSERT INTO [{tabels.Library}]([Id], [Name], [Adress], [City]) VALUES ({el.Id.ToString()}, '{el.Name}', '{el.Adress}', '{el.City}')");
                pc.Close();
                return pc != null;
            }
            else if (x == 1)
            {
                var pc = QueryAccess($"UPDATE [{tabels.Library}] SET [Name] = '{el.Name}', [Adress] = '{el.Adress}', [City] = '{el.City}' WHERE Id = {el.Id}");
                pc.Close();
                return pc != null;
            }
            else
            {
                var pc = QueryAccess($"DELETE FROM [{tabels.Library}] WHERE [Id] = {el.Id.ToString()}");
                pc.Close();
                return pc != null;
            }
        }
        public bool InsUpdDel(Refill el, int x = 0, int b = 0)
        {
            if (x == 0)
            {
                var pc = QueryAccess($"INSERT INTO [{tabels.Refill}]([Id], [Fond], [Staff], [Type], [DateRefill], [Source], [Publisher], [DatePublication], [Count]) VALUES ({el.Id.ToString()}, {el.Fond}, {el.Staff}, {el.Type}, '{el.DateRefill}', '{el.Source}', '{el.Publisher}', '{el.DatePublication}', {el.Count.ToString()})");
                pc.Close();
                Fond f = Fonds.Find(z => z.Id == el.Fond);
                switch (el.Type)
                {
                    case 1:
                        f.Books += el.Count;
                        break;
                    case 2:
                        f.Paper += el.Count;
                        break;
                    case 3:
                        f.Magazine += el.Count;
                        break;
                    case 4:
                        f.Collection += el.Count;
                        break;
                    case 5:
                        f.Dissertation += el.Count;
                        break;
                    case 6:
                        f.Report += el.Count;
                        break;
                }
                InsUpdDel(f, 1);
                return pc != null;
            }
            else if (x == 1)
            {
                var pc = QueryAccess($"UPDATE [{tabels.Refill}] SET [Fond] = {el.Fond}, [Staff] = {el.Staff}, [Type] = {el.Type}, [DateRefill] = '{el.DateRefill}', [Source] = '{el.Source}', [Publisher] = '{el.Publisher}', [DatePublication] = '{el.DatePublication}', [Count] = {el.Count.ToString()} WHERE Id = {el.Id}");
                pc.Close();
                Fond f = Fonds.Find(z => z.Id == el.Fond);
                switch (el.Type)
                {
                    case 1:
                        f.Books += b - el.Count;
                        break;
                    case 2:
                        f.Paper += b - el.Count;
                        break;
                    case 3:
                        f.Magazine += b - el.Count;
                        break;
                    case 4:
                        f.Collection += b - el.Count;
                        break;
                    case 5:
                        f.Dissertation += b - el.Count;
                        break;
                    case 6:
                        f.Report += b - el.Count;
                        break;
                }
                InsUpdDel(f, 1);
                return pc != null;
            }
            else
            {
                var pc = QueryAccess($"DELETE FROM [{tabels.Refill}] WHERE [Id] = {el.Id.ToString()}");
                pc.Close();
                Fond f = Fonds.Find(z => z.Id == el.Fond);
                switch (el.Type)
                {
                    case 1:
                        f.Books -= el.Count;
                        break;
                    case 2:
                        f.Paper -= el.Count;
                        break;
                    case 3:
                        f.Magazine -= el.Count;
                        break;
                    case 4:
                        f.Collection -= el.Count;
                        break;
                    case 5:
                        f.Dissertation -= el.Count;
                        break;
                    case 6:
                        f.Report -= el.Count;
                        break;
                }
                InsUpdDel(f, 2);
                return pc != null;
            }
        }
        public bool InsUpdDel(Staff el, int x = 0)
        {
            if (x == 0)
            {
                var pc = QueryAccess($"INSERT INTO [{tabels.Staff}]([Id], [FIO], [Email], [Password], [Library], [Profession], [Birthday], [Date], [Education], [Pay]) VALUES ({el.Id.ToString()}, '{el.FIO}', '{el.Email}', '{el.Password}', {el.Library.ToString()}, '{el.Profession}', '{el.Birthday}', '{el.Date}', '{el.Education}', {el.Pay})");
                pc.Close();
                return pc != null;
            }
            else if (x == 1)
            {
                var pc = QueryAccess($"UPDATE [{tabels.Staff}] SET [FIO] = '{el.FIO}', [Email] = '{el.Email}', [Password] = '{el.Password}', [Library] = '{el.Library}', [Profession] = '{el.Profession}',[Birthday] = '{el.Birthday}', [Date] = '{el.Date}', [Education] = '{el.Education}', [Pay] = {el.Pay}  WHERE Id = {el.Id}");
                pc.Close();
                return pc != null;
            }
            else
            {
                var pc = QueryAccess($"DELETE FROM [{tabels.Staff}] WHERE [Id] = {el.Id.ToString()}");
                pc.Close();
                return pc != null;
            }
        }

        public bool ItsOnlyFIO(string str)
        {
            return Regex.Match(str, @"[а-яА-Я]*\s[а-яА-Я]*\s[а-яА-Я]*$").Success;
        }

        public bool CheckTime(string str)
        {
            return DateTime.TryParse(str, out DateTime t);
        }
        
        public string DelNotDigits(string str)
        {
            return Regex.Replace(str, @"[^\d]", "");
        }

        public bool ItsEmail(string str)
        {
            return Regex.Match(str, "^\\S+@\\S+\\.\\S+$").Success;
        }
    }
}
