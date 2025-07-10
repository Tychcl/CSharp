using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Reflection.Emit;

namespace pr20.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
      
        public MainWindow mainWindow;
        FontDialog fontDialog=new FontDialog();
        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
 

        public Settings()
        {
            InitializeComponent();

           

            openFileDialog.InitialDirectory = "c:\\"; // указываем начальную директорию
            openFileDialog.Filter = "Access files (*.accdb)|*.accdb|All files (*.*)|*.*"; // указываем типы выбранных файлов
            openFileDialog.FilterIndex = 2; // указываем приоритетный тип файла
            openFileDialog.RestoreDirectory = true; // указываем, что хотим восстановить директорию

            colorDialog.AllowFullOpen = true; // включаем определение собственного цвета
            colorDialog.ShowHelp = false; // отключаем справку
        }

        /// <summary>
        /// Функция выбора базы данных
        /// </summary>
        private void OpenDataBase(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_database.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Функция изменения размера приложения
        /// </summary>
        private void SelectScreenResolution(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox comboBox = sender as System.Windows.Controls.ComboBox; // получаем ComboBox
            System.Windows.Controls.TextBlock textBlock = comboBox.SelectedValue as System.Windows.Controls.TextBlock; // получаем TextBlock
            string resolution = textBlock.Text; // получаем текст

            string[] separator = new string[1] { " x " }; // создаём сепаратор (выражение, по которому делим строку)

            MainWindow.init.Width = int.Parse(resolution.Split(separator, StringSplitOptions.None)[0]);
            MainWindow.init.Height = int.Parse(resolution.Split(separator, StringSplitOptions.None)[1]);

        }
        private void SelectColorText(object sender, RoutedEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color Color = colorDialog.Color;
                foreach (var child in gr_header.Children) {
                    if (child is System.Windows.Controls.Label label)
                    {
                        label.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));
                        back.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));
                    }
                    else if (child is System.Windows.Controls.TextBlock textBlock) {
                       textBlock.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));

                    }
                }
            }
            
        }
        
        /// <summary>
        /// Функция изменения цвета приложения
        /// </summary>
        private void SelectColorApplication(object sender, RoutedEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color Color = colorDialog.Color;
                gr_header.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));
                gr_application.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(Color.A, Color.R, Color.G, Color.B)); // применяем цвет
            }
        }              

        private void SelectFonts(object sender, RoutedEventArgs e)
        {
            if (fontDialog.ShowDialog()== DialogResult.OK)
            {
                foreach (var child in gr_header.Children)
                {
                    if (child is System.Windows.Controls.Label label)
                    {

                        label.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                        label.FontSize = fontDialog.Font.Size;
                        if (fontDialog.Font.Style == System.Drawing.FontStyle.Bold)
                        {
                            label.FontWeight = FontWeights.Bold;
                        }
                        else
                        {
                            label.FontWeight = FontWeights.Normal;
                        }
                        if (fontDialog.Font.Style == System.Drawing.FontStyle.Italic)
                        {
                            label.FontStyle = FontStyles.Italic;
                        }
                        else
                        {
                            label.FontStyle = FontStyles.Normal;
                        }
                    }
                }
            }
        }
    }
}

