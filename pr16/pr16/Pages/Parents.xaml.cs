using pr16.Classes;
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

namespace pr16.Pages
{
    /// <summary>
    /// Логика взаимодействия для Parents.xaml
    /// </summary>
    public partial class Parents : Page
    {
        public Parents()
        {
            InitializeComponent();
        }
        private void NextPage(object sender, RoutedEventArgs e)
        {
            List<CheckBox> CheckBoxes = new List<CheckBox>();
            for (int i = 0; i < parent.Children.Count; i++)
                if (parent.Children[i] is CheckBox cb)
                    CheckBoxes.Add(cb);

            if (!CheckRegex.CheckText(fioFemale.Text))
            {
                MessageBox.Show("Поле ФИО заполнено неверно");
                return;
            }

            if (!CheckRegex.CheckDate(birthdayFemale.Text))
            {
                MessageBox.Show("Поле даты рожения заполнено неверно.Формат:DD.MM.YYYY где  DD — это день (двузначное число от 01 до 31);MM — это месяц (двузначное число от 01 до 12);YYYY — это год (четырехзначное число)");
                return;
            }
            if (!CheckRegex.CheckText(placeWorkFemale.Text))
            {
                MessageBox.Show("Поле место работы заполнено неверно");
                return;
            }

            if (!CheckRegex.CheckWord(postFemale.Text))
            {
                MessageBox.Show("Поле должность заполнено неверно");
                return;
            }

            if (!CheckRegex.CheckText(placeLifeFemale1.Text))
            {
                MessageBox.Show("Поле место жительства заполнено неверно");
                return;
            }

            if (!CheckRegex.CheckListCheckBox(CheckBoxes))
            {
                MessageBox.Show("Подтвердите, что данные на 3-их лиц заполнены верно");
                return;
            }

            if (!CheckRegex.CheckNumber(homeNumberFemale.Text))
            {
                MessageBox.Show("Не правильно введен домашний номер телефона.Формат: +70000000000");
                return;
            }

            if (!CheckRegex.CheckNumber(mobileNumberFemale.Text))
            {
                MessageBox.Show("Не правильно введен мобильный номер телефона.Формат: +70000000000");
                return;
            }

            if (!CheckRegex.CheckText(placeLifeFemale2.Text))
            {
                MessageBox.Show("Поле место жительства заполнено неверно");
                return;
            }

            if (!CheckRegex.CheckNumber(homeNumberFemale2.Text))
            {
                MessageBox.Show("Не правильно введен домашний номер телефона.Формат: +70000000000");
                return;
            }

            if (!CheckRegex.CheckNumber(mobileNumberFemale2.Text))
            {
                MessageBox.Show("Не правильно введен мобильный номер телефона.Формат: +70000000000");
                return;
            }

            if (!CheckRegex.CheckText(fioMale.Text))
            {
                MessageBox.Show("Поле ФИО заполнено неверно");
                return;
            }

            if (!CheckRegex.CheckDate(birthdayMale.Text))
            {
                MessageBox.Show("Поле даты рожения заполнено неверно.Формат:DD.MM.YYYY где  DD — это день(двузначное число от 01 до 31); MM — это месяц(двузначное число от 01 до 12); YYYY — это год(четырехзначное число)");
                return;
            }

            if (!CheckRegex.CheckText(placeWorkMale.Text))
            {
                MessageBox.Show("Поле место работы заполнено неверно");
                return;
            }

            if (!CheckRegex.CheckWord(postMale.Text))
            {
                MessageBox.Show("Поле должность заполнено неверно");
                return;
            }
            if (!CheckRegex.CheckText(placeLifeMale1.Text))
            {
                MessageBox.Show("Поле место жительства заполнено неверно");
                return;
            }
            if (!CheckRegex.CheckNumber(homeNumberMale1.Text))
            {
                MessageBox.Show("Не правильно введен домашний номер телефона.Формат: +70000000000");
                return;
            }
            if (!CheckRegex.CheckNumber(mobileNumberMale1.Text))
            {
                MessageBox.Show("Не правильно введен мобильный номер телефона.Формат: +70000000000");
                return;
            }
            if (!CheckRegex.CheckNumber(homeNumberMale2.Text))
            {
                MessageBox.Show("Не правильно введен домашний номер телефона.Формат: +70000000000");
                return;
            }
            if (!CheckRegex.CheckNumber(mobileNumberMale2.Text))
            {
                MessageBox.Show("Не правильно введен мобильный номер телефона.Формат: +70000000000");
                return;
            }
            if (!CheckRegex.CheckText(placeLifeMale2.Text))
            {
                MessageBox.Show("Поле место жительства заполнено неверно");
                return;
            }

           
        }
    }
}
