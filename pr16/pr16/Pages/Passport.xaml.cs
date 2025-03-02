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
    /// Логика взаимодействия для Passport.xaml
    /// </summary>
    public partial class Passport : Page
    {
        public Passport()
        {
            InitializeComponent();
        }
        public void NextPage(object sender, RoutedEventArgs e)
        {
           

            if (!CheckRegex.CheckWord(surname.Text))
            {
                MessageBox.Show("Не правильно указана фамилия ");
                return;
            }
            if (!CheckRegex.CheckWord(name.Text))
            {
                MessageBox.Show("Неправильно указано имя");
                return;
            }
            if (!CheckRegex.CheckWord(patronymic.Text))
            {
                MessageBox.Show("Неправильно указано отчество");
                return;
            }
            if (!CheckRegex.CheckDate(birthday.Text))
            {
                MessageBox.Show("Неправильно указана дата рождения.Формат:DD.MM.YYYY где  DD — это день (двузначное число от 01 до 31);MM — это месяц (двузначное число от 01 до 12);YYYY — это год (четырехзначное число)");
                return;
            }
            if (!CheckRegex.CheckText(nationality.Text))
            {
                MessageBox.Show("Неправильно указано гражданство");
                return;
            }
            if (!CheckRegex.CheckText(bornPlace.Text))
            {
                MessageBox.Show("Неправильно указано место рождения");
                return;
            }
            if (!CheckRegex.CheckSeriesAndNumberPasport(SerialAndNumber.Text))
            {
                MessageBox.Show("Неправильно указана серия и номер паспорта.Формат XX XX XXXXXX");
                return;
            }
            if (!CheckRegex.CheckDate(dateIssue.Text))
            {
                MessageBox.Show("Неправильно указана дата выдачи.Формат: DD.MM.YYYY ");
                return;
            }
            if (!CheckRegex.CheckDepartamentCode(departamentCode.Text))
            {
                MessageBox.Show("Неправильно указан код подразделения.Формат: ХХХ-ХХХ");
                return;
            }
            if (!CheckRegex.CheckText(issued.Text))
            {
                MessageBox.Show("Неправильно заполнено поле кем выдан");
                return;
            }
            if (!CheckRegex.CheckText(registratedAdress.Text))
            {
                MessageBox.Show("Неправильно указан адрес по прописке");
                return;
            }
            if (!CheckRegex.CheckText(district.Text))
            {
                MessageBox.Show("Неправильно указан район по прописке");
                return;
            }
            if (!CheckRegex.CheckText(realAdress.Text))
            {
                MessageBox.Show("Неправильно указан фактический адрес");
                return;
            }
            if (!CheckRegex.CheckText(realDistrict.Text))
            {
                MessageBox.Show("Неправильно указан фактический район");
                return;
            }
            if (!CheckRegex.CheckPath(educationPhoto.Text))
            {
                MessageBox.Show("Неправильно указан путь к фото.Формат: D:/Data/Image.png");
                return;
            }

            MainWindow.mainWindow.OpenPage(MainWindow.pages.Contacts);
        }
    }
}
