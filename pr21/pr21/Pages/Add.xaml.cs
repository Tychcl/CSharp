using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.IO;
using Microsoft.Win32;
using pr21.Classes;
using pr21.Model;

namespace pr21.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Document Document;
        public string s_src = "";
        public Add(Document Document = null)
        {
            InitializeComponent();
            if(Document != null)
            {
                this.Document = Document;
                if (File.Exists(Document.Src))
                {
                    s_src = Document.Src;
                    img.Source = new BitmapImage(new Uri(s_src));
                }
                tb_name.Text = this.Document.Name;
                tb_user.Text = this.Document.User;
                tb_id.Text = this.Document.Id_document.ToString();
                tb_date.Text = this.Document.Date.ToString("dd.MM.yyyy");
                tb_status.SelectedIndex = this.Document.Status;
                tb_vector.Text = this.Document.Vector;
                tb_btnAdd.Content = "Изменить";
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "PNG (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName != "")
            {
                img.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                s_src = openFileDialog.FileName;
            }
        }

        private void AddDocument(object sender, RoutedEventArgs e)
        {
            if (s_src.Length == 0)
            {
                MessageBox.Show("Выберите изображение"); return;
            }
            if (tb_name.Text.Length == 0)
            {
                MessageBox.Show("Укажите наименование"); return;
            }
            if (tb_user.Text.Length == 0)
            {
                MessageBox.Show("Укажите ответственного"); return;
            }
            if (tb_id.Text.Length == 0)
            {
                MessageBox.Show("Укажите код документа"); return;
            }
            if (tb_date.Text.Length == 0)
            {
                MessageBox.Show("Укажите дату поступления"); return;
            }
            if (tb_status.Text.Length == 0)
            {
                MessageBox.Show("Укажите статус"); return;
            }
            if (tb_vector.Text.Length == 0)
            {
                MessageBox.Show("Укажите направление"); return;
            }
            if (Document == null)
            {
                DocumentContext newDocument = new DocumentContext();
                newDocument.Src = s_src;
                newDocument.Name = tb_name.Text;
                newDocument.User = tb_user.Text;
                newDocument.Id_document = Convert.ToInt32(tb_id.Text);
                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newDocument.Date = newDate;
                newDocument.Status = tb_status.SelectedIndex;
                newDocument.Vector = tb_vector.Text;
                newDocument.Save();
                MessageBox.Show("Документ добавлен.");
            }
            else
            {
                DocumentContext newDocument = new DocumentContext();
                newDocument.Src = s_src;
                newDocument.Id = Document.Id;
                newDocument.Name = tb_name.Text;
                newDocument.User = tb_user.Text;
                newDocument.Id_document = Convert.ToInt32(tb_id.Text);
                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newDocument.Date = newDate;
                newDocument.Status = tb_status.SelectedIndex;
                newDocument.Vector = tb_vector.Text;
                newDocument.Save(true);
                MessageBox.Show("Документ изменён.");
            }
            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments();
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
