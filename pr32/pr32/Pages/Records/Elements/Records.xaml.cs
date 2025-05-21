using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace pr32.Pages.Records.Elements
{
    /// <summary>
    /// Логика взаимодействия для Records.xaml
    /// </summary>
    public partial class Records : UserControl
    {
        private IEnumerable<Classes.State> AllState = Classes.State.AllState();
        private Classes.Record record;
        private Pages.Records.Main main;
        public Records(Classes.Record record, Pages.Records.Main main)
        {
            InitializeComponent();
            IEnumerable<Classes.Manufacturer> AllManufacturer = Classes.Manufacturer.AllManufacturers();
            this.record = record;
            // Запоминаем данные о Маин
            this.main = main;
            // Быводим имя
            tbName.Text = record.Name;

            tbYear.Text = record.Year.ToString();
            // Выводим формат
            tbFormat.Text = record.Format == 0 ? "Моно" : "Стерео";
            // Выводим размер
            switch (record.Size)
            {
                case 0:
                    tbSize.Text = "7 диймов";
                    break;
                case 1:
                    tbSize.Text = "10 деймов";
                    break;
                case 2:
                    tbSize.Text = "12 дюймов";
                    break;
                case 3:
                    tbSize.Text = "Иной";
                    break;
            }

            // Выводим поставщика
            tbManufacturer.Text = AllManufacturer.Where(x => x.Id == record.IdManufacturer).First().Name;
            // Выподим стоиность
            tbPrice.Text = record.Price.ToString();
            // Выбираем состояние
            tbState.Text = AllState.Where(x => x.Id == record.idState).First().Name;
            // Выводим описание
            tbDescription.Text = record.Description;
        }
        private void EditRecord(object sender, RoutedEventArgs e) =>
            MainWindow.mainWindow.OpenPage(new Add(this.record));

        private void DeleteRecord(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Удалить виниловую пластинку: {this.record.Name}", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Получаем поставки
                IEnumerable<Classes.Supply> AllSupply = Classes.Supply.AllSupply();
                if (AllSupply.Where(x => x.IdRecord == record.Id).Count() > 0)
                    // Выводим уведомление о том что нельзя удалить
                    MessageBox.Show($"Виниловую пластинку (this.record.Name) невозножно удалить. Для начала удалите зависимости.", "Уведомление");
                else
                {
                    this.record.Delete();
                    //. Удаляем эленент с интерфейса
                    main.recordsContainer.Children.Remove(this);
                    // Выводим сообщение
                    MessageBox.Show($"Пластинка {this.record.Name} успешно удалена.", "Уведомление");
                }

            }

        }
    }
}
