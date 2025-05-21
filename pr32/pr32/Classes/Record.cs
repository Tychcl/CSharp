using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr32.Classes
{
    public class Record
    {
        /// <summary> ID пластинки </summary>
        public int Id { get; set; }

        /// <summary> Наименование пластинки </summary>
        public string Name { get; set; }

        /// <summary> Год выпуска пластинки </summary>
        public int Year { get; set; }

        /// <summary> Формат записи пластинки (0 - моно, 1 - стерео) </summary>
        public int Format { get; set; }

        /// <summary> Размер пластинки (0:7", 1:10", 2:12") </summary>
        public int Size { get; set; }

        /// <summary> Код производителя </summary>
        public int IdManufacturer { get; set; }

        /// <summary> Стоимость </summary>
        public float Price { get; set; }

        /// <summary> Состояние пластинки (шкала от 0 до 10) </summary>
        public int idState { get; set; }

        /// <summary> Описание </summary>
        public string Description { get; set; }

        /// <summary> Получение всех записей из БД </summary>
        public static IEnumerable<Record> AllRecords()
        {
            var records = new List<Record>();
            DataTable result = DBConnection.Connection("SELECT * FROM [dbo].[Record]");

            foreach (DataRow row in result.Rows)
            {
                records.Add(new Record()
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    Year = Convert.ToInt32(row[2]),
                    Format = Convert.ToInt32(row[3]),
                    Size = Convert.ToInt32(row[4]),
                    IdManufacturer = Convert.ToInt32(row[5]),
                    Price = float.Parse(row[6].ToString()),
                    idState = Convert.ToInt32(row[7]),
                    Description = row[8].ToString()
                });
            }
            return records;
        }

        /// <summary> Сохраняет запись пластинки (добавление или обновление) </summary>
        public void Save(bool isUpdate = false)
        {
            string priceString = this.Price.ToString().Replace(",", ".");

            if (!isUpdate)
            {
                // Добавление новой записи
                DBConnection.Connection(
                    "INSERT INTO [dbo].[Record] " +
                    "([Name], [Year], [Format], [Size], [IdManufacturer], [Price], [Condition], [Description]) " +
                    $"VALUES (N'{Name}', {Year}, {Format}, {Size}, {IdManufacturer}, {priceString}, {idState}, N'{Description}')");

                // Получаем ID добавленной записи
                this.Id = AllRecords()
                    .Where(x => x.Name == Name &&
                               x.Year == Year &&
                               x.Format == Format &&
                               x.Size == Size &&
                               x.IdManufacturer == IdManufacturer &&
                               x.idState == idState &&
                               x.Description == Description).First()
                    .Id;
            }
            else
            {
                // Обновление существующей записи
                DBConnection.Connection(
                    "UPDATE [dbo].[Record] SET " +
                    $"[Name] = N'{Name}', " +
                    $"[Year] = {Year}, " +
                    $"[Format] = {Format}, " +
                    $"[Size] = {Size}, " +
                    $"[IdManufacturer] = {IdManufacturer}, " +
                    $"[Price] = {priceString}, " +
                    $"[Condition] = {idState}, " +
                    $"[Description] = N'{Description}' " +
                    $"WHERE [Id] = {Id}");
            }
        }

        /// <summary> Удаляет запись о пластинке </summary>
        public void Delete()
        {
            DBConnection.Connection($"DELETE FROM [dbo].[Record] WHERE [Id] = {Id};");
        }
    }
}
