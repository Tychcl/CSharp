using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для Library.xaml
    /// </summary>
    public partial class Staff : Page
    {
        MainWindow.pages lastpage;
        DataBase.Tabels.Staff staf;
        public Staff(DataBase.Tabels.Staff l, MainWindow.pages page)
        {
            InitializeComponent();
            lastpage = page;
            staf = l;
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Library);
            foreach (DataBase.Tabels.Library el in MainWindow.main.connect.Librares)
            {
                ComboBoxItem i = new ComboBoxItem();
                i.Content = el.Name;
                i.Tag = el.Id;
                lib.Items.Add(i);
                if (staf != null && el.Id == staf.Library)
                {
                    lib.SelectedItem = i;
                }
            }
            if (staf != null)
            {
                btn.Content = "Изменить";
                fio.Text = staf.FIO;
                email.Text = staf.Email;
                pas.Text = staf.Password;
                pro.Text = staf.Profession;
                bd.Text = staf.Birthday;
                date.Text = staf.Date;
                edu.Text = staf.Education;
                pay.Text = staf.Pay.ToString();
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if (lib.SelectedIndex == -1 | string.IsNullOrEmpty(fio.Text) | string.IsNullOrEmpty(email.Text) | string.IsNullOrEmpty(pas.Text) | string.IsNullOrEmpty(pro.Text) | string.IsNullOrEmpty(bd.Text) | string.IsNullOrEmpty(date.Text) | string.IsNullOrEmpty(edu.Text) | string.IsNullOrEmpty(pay.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            if (!MainWindow.main.connect.ItsEmail(email.Text))
            {
                MessageBox.Show("Не верный формат почты");
                return;
            }
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Staff);
            if(MainWindow.main.connect.Staffs.Find(x=> x.Email.Split('@')[0] == email.Text.Split('@')[0]) != null)
            {
                MessageBox.Show("Сотрудник с такой почтой уже существует");
                return;
            }
            if (!MainWindow.main.connect.CheckTime(bd.Text) && !MainWindow.main.connect.CheckTime(date.Text))
            {
                MessageBox.Show("Не верный формат даты дня рождения или начала работы");
                return;
            }
            pay.Text = MainWindow.main.connect.DelNotDigits(pay.Text);
            if (staf != null)
            {
                staf.FIO = fio.Text;
                staf.Email = email.Text;
                staf.Password = pas.Text;
                staf.Library = int.Parse((lib.SelectedItem as ComboBoxItem).Tag.ToString());
                staf.Profession = pro.Text;
                staf.Birthday = bd.Text;
                staf.Date = date.Text;
                staf.Education = edu.Text;
                staf.Pay = int.Parse(pay.Text);
                bool x = !MainWindow.main.connect.InsUpdDel(staf,1);
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
                bool x = !MainWindow.main.connect.InsUpdDel(new DataBase.Tabels.Staff(MainWindow.main.connect.SetLastId(DataBase.Connect.tabels.Staff),
                    fio.Text, email.Text, pas.Text,int.Parse((lib.SelectedItem as ComboBoxItem).Tag.ToString()), pro.Text, bd.Text, date.Text, edu.Text, int.Parse(pay.Text)));
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
