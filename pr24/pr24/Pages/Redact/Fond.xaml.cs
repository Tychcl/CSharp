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

namespace pr24.Pages.Redact
{
    /// <summary>
    /// Логика взаимодействия для Fond.xaml
    /// </summary>
    public partial class Fond : Page
    {
        MainWindow.pages lastpage;
        DataBase.Tabels.Fond fond;
        public Fond(DataBase.Tabels.Fond f, MainWindow.pages page)
        {
            InitializeComponent();
            lastpage = page;
            fond = f;
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Library);
            foreach (DataBase.Tabels.Library el in MainWindow.main.connect.Librares)
            {
                ComboBoxItem i = new ComboBoxItem();
                i.Content = el.Name;
                i.Tag = el.Id;
                lib.Items.Add(i);
                if(fond != null && el.Id == fond.Library)
                {
                    lib.SelectedItem = i;
                }
            }
            if (fond != null)
            {
                btn.Content = "Изменить";
                name.Text = fond.Name;
                books.Text = fond.Books.ToString();
                papers.Text = fond.Paper.ToString();
                magazines.Text = fond.Magazine.ToString();
                collections.Text = fond.Collection.ToString();
                dissertations.Text = fond.Dissertation.ToString();
                reports.Text = fond.Report.ToString();
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(name.Text) | string.IsNullOrEmpty(books.Text) | string.IsNullOrEmpty(papers.Text) | string.IsNullOrEmpty(magazines.Text) | string.IsNullOrEmpty(collections.Text) | string.IsNullOrEmpty(dissertations.Text) | string.IsNullOrEmpty(reports.Text) | lib.SelectedIndex == -1)
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            if (fond != null)
            {
                fond.Name = name.Text;
                fond.Library = int.Parse((lib.SelectedItem as ComboBoxItem).Tag.ToString());
                fond.Books = int.Parse(books.Text);
                fond.Paper = int.Parse(papers.Text);
                fond.Magazine = int.Parse(magazines.Text);
                fond.Collection = int.Parse(collections.Text);
                fond.Dissertation = int.Parse(dissertations.Text);
                fond.Report = int.Parse(reports.Text);
                bool x = !MainWindow.main.connect.InsUpdDel(fond, 1);
                if (x)
                {
                    MessageBox.Show("Что-то не так");
                }
                else
                {
                    MessageBox.Show("Все так");
                }
                MainWindow.main.OpenPage(lastpage);
            }
            else
            {
                bool x = !MainWindow.main.connect.InsUpdDel(new DataBase.Tabels.Fond(MainWindow.main.connect.SetLastId(DataBase.Connect.tabels.Staff),
                    name.Text, int.Parse((lib.SelectedItem as ComboBoxItem).Tag.ToString()), int.Parse(books.Text), int.Parse(papers.Text), int.Parse(magazines.Text), int.Parse(collections.Text), int.Parse(dissertations.Text), int.Parse(reports.Text)));
                if (x)                                
                {
                    MessageBox.Show("Что-то не так");
                }
                else
                {
                    MessageBox.Show("Все так");
                }
                MainWindow.main.OpenPage(lastpage);
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow.main.OpenPage(lastpage);
        }

        private void check(object sender, KeyEventArgs e)
        {
            (sender as TextBox).Text = MainWindow.main.connect.DelNotDigits((sender as TextBox).Text);
        }
    }
}
