using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
using Microsoft.Win32;
using pr16.Classes;

namespace pr16.Pages
{
    /// <summary>
    /// Логика взаимодействия для Education.xaml
    /// </summary>
    public partial class Education : Page
    {
        public Education()
        {
            InitializeComponent();
        }
        private void NextPage(object sender, RoutedEventArgs e)
        {

            if (!CheckRegex.CheckSeriesAndNumberEdu(serialAndNumber.Text))
            {
                MessageBox.Show("Серия и номер заполнены не правильно.Формат: XXXX XXXXXX");
                return;
            }

            if (!CheckRegex.CheckNumberRound2(avgMark.Text))
            {
                MessageBox.Show("Средний балл указан в неверном формате. Формат: X,XX");
                return;
            }

            if (!CheckRegex.CheckPath(pathPhoto.Text))
            {
                MessageBox.Show("Неверный путь к фото.Формат");
                return;
            }
            MainWindow.mainWindow.OpenPage(MainWindow.pages.Status);
        }

        private void chooseofd(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.png;*.jpeg;*.pdf";
            if (openFileDialog.ShowDialog() == true)
            {
                pathPhoto.Text = new FileInfo(openFileDialog.FileName).Length < 5242880 ? openFileDialog.FileName : "Файл слишком большой";
            }
        }
    }
}
