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
using static pr24.MainWindow;
using System.Xml.Linq;

namespace pr24.Pages.Redact
{
    /// <summary>
    /// Логика взаимодействия для Fond.xaml
    /// </summary>
    public partial class Refill : Page
    {
        MainWindow.pages lastpage;
        DataBase.Tabels.Refill refill;
        public Refill(DataBase.Tabels.Refill f, MainWindow.pages page)
        {
            InitializeComponent();
            lastpage = page;
            refill = f;
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Fond);
            foreach (DataBase.Tabels.Fond el in MainWindow.main.connect.Fonds)
            {
                ComboBoxItem i = new ComboBoxItem();
                i.Content = el.Name;
                i.Tag = el.Id;
                fondc.Items.Add(i);
                if (refill != null && el.Id == refill.Fond)
                {
                    fondc.SelectedItem = i;
                }
            }
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Staff);
            foreach (DataBase.Tabels.Staff el in MainWindow.main.connect.Staffs)
            {
                ComboBoxItem i = new ComboBoxItem();
                i.Content = el.FIO;
                i.Tag = el.Id;
                staf.Items.Add(i);
                if (refill != null && el.Id == refill.Fond)
                {
                    staf.SelectedItem = i;
                }
                else if(refill == null && el.Id == main.StaffId)
                {
                    staf.SelectedItem = i;
                }
            }
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Type);
            foreach (DataBase.Tabels.Type el in MainWindow.main.connect.Types)
            {
                ComboBoxItem i = new ComboBoxItem();
                i.Content = el.Name;
                i.Tag = el.Id;
                type.Items.Add(i);
                if (refill != null && el.Id == refill.Fond)
                {
                    type.SelectedItem = i;
                }
            }
            if (refill != null)
            {
                btn.Content = "Изменить";
                daterefill.Text = refill.DateRefill;
                source.Text = refill.Source;
                publisher.Text = refill.Publisher;
                datepublication.Text = refill.DatePublication;
                count.Text = $"{refill.Count}";
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if (fondc.SelectedIndex == -1 | staf.SelectedIndex == -1 | type.SelectedIndex == -1 | string.IsNullOrEmpty(daterefill.Text) | string.IsNullOrEmpty(datepublication.Text) | string.IsNullOrEmpty(source.Text) | string.IsNullOrEmpty(publisher.Text) | string.IsNullOrEmpty(count.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            if(!main.connect.CheckTime(daterefill.Text) && !main.connect.CheckTime(datepublication.Text))
            {
                MessageBox.Show("Не верный формат даты поплнения или публикации");
                return;
            }
            count.Text = main.connect.DelNotDigits(count.Text);
            if (refill != null)
            {
                int b = refill.Count;
                refill.Fond = int.Parse((fondc.SelectedItem as ComboBoxItem).Tag.ToString());
                refill.Staff = int.Parse((staf.SelectedItem as ComboBoxItem).Tag.ToString());
                refill.Type = int.Parse((type.SelectedItem as ComboBoxItem).Tag.ToString());
                refill.DateRefill = daterefill.Text;
                refill.Source = source.Text;
                refill.Publisher = publisher.Text;
                refill.DatePublication = datepublication.Text;
                refill.Count = int.Parse(count.Text);
                bool x = !MainWindow.main.connect.InsUpdDel(refill, 1, b);
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
                bool x = !MainWindow.main.connect.InsUpdDel(new DataBase.Tabels.Refill(MainWindow.main.connect.SetLastId(DataBase.Connect.tabels.Refill),
                    int.Parse((fondc.SelectedItem as ComboBoxItem).Tag.ToString()), int.Parse((staf.SelectedItem as ComboBoxItem).Tag.ToString()), int.Parse((type.SelectedItem as ComboBoxItem).Tag.ToString()), daterefill.Text, source.Text, publisher.Text, datepublication.Text, int.Parse(count.Text)));
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
