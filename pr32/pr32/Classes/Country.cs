using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr32.Classes
{
    public class Country
    {
        /// <summary> Код страны </summary>
        public int Id { get; set; }

        /// <summary> Название страны </summary>
        public string Name { get; set; }

        /// <summary> Получение всех стран </summary>
        public static IEnumerable<Country> AllCountries()
        {
            // Создаём список стран
            List<Country> countries = new List<Country>();

            // Получаем страны из БД
            DataTable requestCountrys = DBConnection.Connection("SELECT * FROM [dbo].[Country]");

            // Перебираем строки и вносим их в список
            foreach (DataRow row in requestCountrys.Rows)
            {
                countries.Add(new Country()
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = row[1].ToString()
                });
            }

            // Возвращаем список
            return countries;
        }
    }
}
