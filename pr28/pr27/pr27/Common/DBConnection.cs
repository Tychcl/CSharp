using pr27.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pr27.Common
{
    public class DBConnection
    {
        public static List<Theatre> Theatres = new List<Theatre>();
        public static List<Afisha> Afishas = new List<Afisha>();

        public enum tabels
        {
            Order, Club
        }

        public static MySqlConnection OpenConnection()
        {
            try
            {
                MySqlConnection sqlConnection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;port=3306;database=pr28");
                sqlConnection.Open();
                return sqlConnection;
            }
            catch
            {
                return null;
            }
        }
        public static MySqlDataReader Query(string query, MySqlConnection sqlConnection)
        {
            try
            {
                return new MySqlCommand(query, sqlConnection).ExecuteReader();
            }
            catch { return null; }
        }
        public static void CloseConnection(MySqlConnection sqlConnection)
        {
            sqlConnection.Close();
            //MySqlConnection.ClearPool(sqlConnection);
        }

        public static void GetData(tabels tabel)
        {
            try 
            {
                switch (tabel.ToString())
                {
                    case "Order":
                        Afisha.All();
                        break;
                    case "Club":
                        Theatre.All();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("null");
            }
        }

        public static int GetNewId(tabels tabel)
        {
            try
            {
                GetData(tabel);
                switch (tabel.ToString())
                {
                    case "Order":
                        return Afishas.Count > 0 ? Afishas.Max(x => x.Id) + 1 : 0;
                    case "Club":
                        return Theatres.Count > 0 ? Theatres.Max(x => x.Id) + 1 : 0;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }

        public static bool IUD(Afisha el, bool del = false)
        {
            bool exist = Afishas.Exists(x => x.Id == el.Id);
            MySqlConnection con = OpenConnection();
            if (del && exist)
            {
                var pc = Query($"DELETE FROM `{tabels.Order}` WHERE `Id` = {el.Id}", con);
                CloseConnection(con);
                return pc != null;
            }
            else if (exist)
            {
                var pc = Query($"UPDATE `{tabels.Order}` SET `Club` = {el.Club}, `FIO` = '{el.FIO}', `Time` = '{el.Time}' WHERE Id = {el.Id}", con);
                CloseConnection(con);
                return pc != null;
            }
            else
            {
                var pc = Query($"INSERT INTO `{tabels.Order}`(`Id`, `Club`, `FIO`, `Time`) VALUES ({el.Id}, {el.Club}, '{el.FIO}', '{el.Time}')", con);
                CloseConnection(con);
                return pc != null;
            }
        }
        public static bool IUD(Theatre el, bool del = false)
        {
            bool exist = Theatres.Exists(x => x.Id == el.Id);
            MySqlConnection con = OpenConnection();
            if (del && exist)
            {
                var pc = Query($"DELETE FROM `{tabels.Club}` WHERE `Id` = {el.Id}", con);
                CloseConnection(con);
                return pc != null;
            }
            else if (exist)
            {
                var pc = Query($"UPDATE `{tabels.Club}` SET `Name` = '{el.Name}', `Adres` = '{el.Adres}', `Work` = '{el.Work}' WHERE Id = {el.Id}", con);
                CloseConnection(con);
                return pc != null;
            }
            else
            {
                var pc = Query($"INSERT INTO `{tabels.Club}`(`Id`, `Name`, `Adres`, `Work`) VALUES ({el.Id}, '{el.Name}', '{el.Adres}', '{el.Work}')", con);
                CloseConnection(con);
                return pc != null;
            }
        }
    }
    public class Check
    {
        public static bool FIO(string str)
        {
            return Regex.Match(str, @"[а-яА-Я]*\s[а-яА-Я]*\s[а-яА-Я]*$").Success;
        }

        public static bool Date(string str)
        {
            return DateTime.TryParse(str, out DateTime t);
        }

        public static bool Digits(string str)
        {
            return int.TryParse(str, out int v);
        }

        public static bool Email(string str)
        {
            return Regex.Match(str, "^\\S+@\\S+\\.\\S+$").Success;
        }

        public static bool Number(string str)
        {
            return Regex.Match(str, "\\+7[0-9]{10}").Success | Regex.Match(str, "8[0-9]{10}").Success;
        }
    }
}
