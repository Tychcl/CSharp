using pr21.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace pr21.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        DocumentContext Document;

        public Item(DocumentContext Document)
        {
            InitializeComponent();
            img.Source = new BitmapImage(new Uri(Document.Src));
            lName.Content = Document.Name;
            lUser.Content = $"Ответственный: {Document.User}";
            lCode.Content = $"Код документа: {Document.Id_document}";
            lDate.Content = $"Дата поступления {Document.Date.ToString("dd.MM.yyyy")}";
            lStatus.Content = Document.Status == 0 ? $"Статьс: входящий" : $"Статус: исходящий";
            lDirect.Content = $"Направлениe: {Document.Vector}";
            // Сохраняем документ для изменения или удаления
            this.Document = Document;

        }
        private void EditDocument(object sender, RoutedEventArgs e)
        {
            // Открываем страницу изменения передавая документ
            MainWindow.init.frame.Navigate(new Pages.Add(Document));

        }
        private void DeleteDocument(object sender, RoutedEventArgs e)
        {
            // Удаляем документ
            Document.Delete();
            // Обновляем документы из БД
            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments();
            // Открываем страницу Main
            MainWindow.init.OpenPages(MainWindow.pages.main);

        }

    }
}
