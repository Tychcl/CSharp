using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr32.Classes
{
    public class Supply
    {
        /// <summary> Код поставщика </summary>
        public int Id { get; set; }

        /// <summary> Наименование поставщика </summary>
        public int IdManufacturer { get; set; }

        /// <summary> Код страны </summary>
        public int IdRecord { get; set; }

        /// <summary> Телефон </summary>
        public string DateDelivery { get; set; }

        /// <summary> Электронная почта </summary>
        public int Count { get; set; }

        /// <summary> Получение всех поставщиков из базы данных </summary>
        public static IEnumerable<Supply> AllSupply()
        {
            List<Supply> supples = new List<Supply>();
            DataTable recordQuery = DBConnection.Connection("SELECT * FROM [dbo].[Supple]");

            foreach (DataRow row in recordQuery.Rows)
            {
                DateTime dt = new DateTime();
                DateTime.TryParse(row[3].ToString(), out dt);
                string CorrectDate = dt.Year + "-" + dt.Month + "-" + dt.Day;
                supples.Add(new Supply()
                {
                    Id = Convert.ToInt32(row[0]),
                    IdManufacturer = Convert.ToInt32(row[1]),
                    IdRecord = Convert.ToInt32(row[2]),
                    DateDelivery = CorrectDate,
                    Count = Convert.ToInt32(row[4])
                });
            }
            return supples;
        }

        /// <summary> Сохраняет поставщика в БД (добавление или обновление) </summary>
        public void Save(bool isUpdate = false)
        {
            if (!isUpdate)
            {
                // Добавление нового поставщика
                DBConnection.Connection(
                    "INSERT INTO [dbo].[Supple] ([IdManufacturer], [IdRecord], [DateDelivery], [Count]) " +
                    $"VALUES ('{this.IdManufacturer}', {this.IdRecord}, '{this.DateDelivery}', '{this.Count}');");

                // Получаем ID добавленной записи
                this.Id = Supply.AllSupply().Where(
                    x => x.IdManufacturer == this.IdManufacturer &&
                              x.IdRecord == this.IdRecord &&
                              x.DateDelivery == this.DateDelivery &&
                              x.Count == this.Count).First().Id;
            }
            else
            {
                // Обновление существующего поставщика
                DBConnection.Connection(
                    "UPDATE [dbo].[Supple] SET " +
                    $"[IdManufacturer] = '{this.IdManufacturer}', " +
                    $"[IdRecord] = {this.IdRecord}, " +
                    $"[DateDelivery] = '{this.DateDelivery}', " +
                    $"[Count] = '{this.Count}' " +
                    $"WHERE [Id] = {this.Id};");
            }
        }

        /// <summary> Удаляет поставщика из БД </summary>
        public void Delete()
        {
            DBConnection.Connection($"DELETE FROM [dbo].[Supple] WHERE [Id] = {this.Id};");
        }
    }
}
