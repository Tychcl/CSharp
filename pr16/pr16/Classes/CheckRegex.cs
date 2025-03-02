using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr16.Classes
{
    public class CheckRegex
    {
        private static bool Match(string Patern, string Input)
        {
            Match m = Regex.Match(Input, Patern);
            return m.Success;
        }

        public static bool CheckNumber(string Number)// Проверка номера телефона
        {
            bool b = true;
            if (string.IsNullOrEmpty(Number) || (!Classes.CheckRegex.Match(@"^8([0-9]{10})$", Number)))//Формат номера 80000000000 
                b = false;
            return b;
        }

        public static bool CheckMail(string Mail)
        { 
            bool b = true;
            if(string.IsNullOrEmpty(Mail) || !Classes.CheckRegex.Match(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", Mail))//  email имеет формат "имя@домен.расширение"
                b = false;
            return b;
        }

        public static bool CheckSeriesAndNumberEdu(string SeriesAndNumber)
        {
            bool b = true;
            if (string.IsNullOrEmpty(SeriesAndNumber) || !Match(@"^([0-9]{4})+\s([0-9]{6})+$", SeriesAndNumber))
                b = false;
            return b;
        }
        public static bool CheckNumberRound2(string Number)

        {
            bool b = true;
            if (string.IsNullOrEmpty(Number) || !Classes.CheckRegex.Match(@"^([0-9]+)[.,]([0-9]{2})$", Number))
            {
                b = false;
            }
            return b;
        }
        public static bool CheckPath(string Way)
        {
            bool b = true;
            if (string.IsNullOrEmpty(Way) || !Path.IsPathRooted(Way))
                b = false;
            return b;

        }

        public static bool CheckText(string Text)
        {
            bool b = true;
            if (string.IsNullOrEmpty(Text) || !Classes.CheckRegex.Match(@"^(([а-яА-я]+.\s)*[а-яА-я])+\s(([а-яА-я]+.\s)*[а-яА-я]+\s)*(([а-яА-я]+.\s)*[а-яА-я]+)$", Text))
                b = false;
            return b;
        }

        public static bool CheckDate(string Date)
        {
            bool b = true;
            if (string.IsNullOrEmpty(Date) || !Classes.CheckRegex.Match("[0-3][0-9].[0-1][0-9].[1-2][0-9]{3}", Date))
                b = false;
            return b;
        }

        public static bool CheckWord(string Text)
        {
            bool b = true;
            if (string.IsNullOrEmpty(Text) || !Classes.CheckRegex.Match(@"^[а-яА-я]*$", Text))
                b = false;
            return b;
        }

        public static bool CheckListCheckBox(List<CheckBox> CheckBoxes)
        {
            bool b = true;
            int count = 0;
            foreach (CheckBox cb in CheckBoxes)
            {
                if (cb.IsChecked == true)
                    count++;
            }
            if (count == 0)
                b = false;
            return b;
        }
        public static bool CheckSeriesAndNumberPasport(string SeriesAndNumber)
        {
            bool b = true;
            if (string.IsNullOrEmpty(SeriesAndNumber) || !Match(@"^([0-9]{2})\s[0-9]{2}\s([0-9]{6})$", SeriesAndNumber))
                b = false;
            return b;
        }

        public static bool CheckDepartamentCode(string Code)
        {
            bool b = true;
            if (string.IsNullOrEmpty(Code) || !Match("^([0-9]{3})-([0-9]{3})$", Code))
                b = false;
            return b;
        }

        public static bool CheckYear(string Date)
        {
            bool b = true;
            if (string.IsNullOrEmpty(Date) || !Classes.CheckRegex.Match("[1-2][0-9]{3}", Date))
                b = false;
            return b;
        }
    }
}
