using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr32.Classes
{
    public class Manufacturer
    {
        /// <summary> Код поставщика </summary>
        public int Id { get; set; }

        /// <summary> Наименование поставщика </summary>
        public string Name { get; set; }

        /// <summary> Код страны </summary>
        public int CountryCode { get; set; }

        /// <summary> Телефон </summary>
        public string Phone { get; set; }

        /// <summary> Электронная почта </summary>
        public string Mail { get; set; }

        /// <summary> Получение всех поставщиков из базы данных </summary>
        public static IEnumerable<Manufacturer> AllManufacturers()
        {
            var manufacturers = new List<Manufacturer>();
            DataTable result = DBConnection.Connection("SELECT * FROM [dbo].[Manufacturer]");

            foreach (DataRow row in result.Rows)
            {
                manufacturers.Add(new Manufacturer()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    CountryCode = Convert.ToInt32(row["CountryCode"]),
                    Phone = row["Phone"].ToString(),
                    Mail = row["Mail"].ToString()
                });
            }
            return manufacturers;
        }

        /// <summary> Сохраняет поставщика в БД (добавление или обновление) </summary>
        public void Save(bool isUpdate = false)
        {
            if (!isUpdate)
            {
                // Добавление нового поставщика
                DBConnection.Connection(
                    "INSERT INTO [dbo].[Manufacturer] ([Name], [CountryCode], [Phone], [Mail]) " +
                    $"VALUES (N'{Name}', {CountryCode}, '{Phone}', '{Mail}')");

                // Получаем ID добавленной записи
                this.Id = AllManufacturers()
                    .First(x => x.Name == Name &&
                              x.CountryCode == CountryCode &&
                              x.Phone == Phone &&
                              x.Mail == Mail)
                    .Id;
            }
            else
            {
                // Обновление существующего поставщика
                DBConnection.Connection(
                    "UPDATE [dbo].[Manufacturer] SET " +
                    $"[Name] = N'{Name}', " +
                    $"[CountryCode] = {CountryCode}, " +
                    $"[Phone] = '{Phone}', " +
                    $"[Mail] = '{Mail}' " +
                    $"WHERE [Id] = {Id}");
            }
        }

        /// <summary> Удаляет поставщика из БД </summary>
        public void Delete()
        {
            DBConnection.Connection($"DELETE FROM [dbo].[Manufacturer] WHERE [Id] = {Id};");
        }
    }
}
