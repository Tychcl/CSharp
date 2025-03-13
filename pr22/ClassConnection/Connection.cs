using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClassModule;

namespace ClassConnection
{
    public class Connection
    {
        public List<User> users = new List<User>();
        public List<call> calls = new List<call>();
        public List<Search_filter> search_filter = new List<Search_filter>();
        public enum tabels
        {
            users, calls, search_filter
        }
        public string localPath = Directory.GetCurrentDirectory();

        public OleDbDataReader QueryAccess(string query)
        {
            try
            {
                OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + localPath + "/DB.accdb");
                connect.Open();
                OleDbCommand cmd = new OleDbCommand(query, connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch
            {
                return null;
            }
        }

        
        public int SetLastId(tabels tabel)
        {
            try
            {
                LoadData(tabel);
                switch (tabel.ToString())
                {
                    case "users":
                        if (users.Count >= 1)
                        {
                            int max = users[0].id;
                            max = users.Max(x => x.id);
                            return max + 1;
                        }
                        else return 1;
                    case "calls":
                        if (calls.Count >= 1)
                        {
                            int max = calls[0].id;
                            max = calls.Max(x => x.id);
                            return max + 1;
                        }
                        else return 1;
                    case "search_filter":
                        if (search_filter.Count >= 1)
                        {
                            int max_status = search_filter[0].id;
                            max_status = search_filter.Max(x => x.id);
                            return max_status + 1;
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
                if(zap.ToString() == "users")
                {
                    users.Clear();
                    while (itemQuery.Read())
                    {
                        User newEl = new User();
                        newEl.id = Convert.ToInt32(itemQuery.GetValue(0));
                        newEl.phone_num = Convert.ToString(itemQuery.GetValue(1));
                        newEl.fio_user = Convert.ToString(itemQuery.GetValue(2));
                        newEl.pasport_data = Convert.ToString(itemQuery.GetValue(3));
                        users.Add(newEl);
                    }
                }
                if(zap.ToString() == "calls")
                {
                    calls.Clear();
                    while (itemQuery.Read())
                    {
                        call newEl = new call();
                        newEl.id = Convert.ToInt32(itemQuery.GetValue(0));
                        newEl.user_id = Convert.ToInt32(itemQuery.GetValue(1));
                        newEl.category_call = Convert.ToInt32(itemQuery.GetValue(2));
                        newEl.date = Convert.ToString(itemQuery.GetValue(3));
                        newEl.time_start = Convert.ToString(itemQuery.GetValue(4));
                        newEl.time_end = Convert.ToString(itemQuery.GetValue(5));
                        calls.Add(newEl);
                    }
                }
                if (zap.ToString() == "search_filter")
                {
                    search_filter.Clear();
                    while (itemQuery.Read())
                    {
                        Search_filter newEl = new Search_filter();
                        newEl.id = Convert.ToInt32(itemQuery.GetValue(0));
                        newEl.time_start = Convert.ToString(itemQuery.GetValue(1));
                        newEl.time_end = Convert.ToString(itemQuery.GetValue(2));
                        newEl.phone_number = Convert.ToString(itemQuery.GetValue(3));
                        newEl.category_call = Convert.ToString(itemQuery.GetValue(4));
                        search_filter.Add(newEl);
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

        public bool ItsNumber(string str)
        {
            return Regex.Match(str, "\\+7[0-9]{10}").Success | Regex.Match(str, "8[0-9]{10}").Success;
        }

        public bool ItsOnlyFIO(string str)
        {
            return Regex.Match(str, @"[а-яА-Я]*\s[а-яА-Я]*\s[а-яА-Я]*$").Success;
        }
    }
}
