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
            Afisha, Theatre
        }

        public static MySqlConnection OpenConnection()
        {
            try
            {
                MySqlConnection sqlConnection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;port=3306;database=pr27");
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
                    case "Afisha":
                        Afisha.All();
                        break;
                    case "Theatre":
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
                    case "Afisha":
                        return Afishas.Count > 0 ? Afishas.Max(x => x.Id) + 1 : 0;
                    case "Theatre":
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
                var pc = Query($"DELETE FROM `{tabels.Afisha}` WHERE `Id` = {el.Id}", con);
                CloseConnection(con);
                return pc != null;
            }
            else if (exist)
            {
                var pc = Query($"UPDATE `{tabels.Afisha}` SET `Theatre` = {el.Theatre}, `Film` = '{el.Film}', `Time` = '{el.Time}', `Price` = {el.Price} WHERE Id = {el.Id}", con);
                CloseConnection(con);
                return pc != null;
            }
            else
            {
                var pc = Query($"INSERT INTO `{tabels.Afisha}`(`Id`, `Theatre`, `Film`, `Time`, `Price`) VALUES ({el.Id}, '{el.Theatre}', '{el.Film}', '{el.Time}', {el.Price})", con);
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
                var pc = Query($"DELETE FROM `{tabels.Theatre}` WHERE `Id` = {el.Id}", con);
                CloseConnection(con);
                return pc != null;
            }
            else if (exist)
            {
                var pc = Query($"UPDATE `{tabels.Theatre}` SET `Name` = '{el.Name}', `RoomCount` = {el.RoomCount}, `PlaceCount` = {el.PlaceCount} WHERE Id = {el.Id}", con);
                CloseConnection(con);
                return pc != null;
            }
            else
            {
                var pc = Query($"INSERT INTO `{tabels.Theatre}`(`Id`, `Name`, `RoomCount`, `PlaceCount`) VALUES ({el.Id}, '{el.Name}', {el.RoomCount}, {el.PlaceCount})", con);
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
