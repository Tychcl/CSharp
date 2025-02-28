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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace _14pr2.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Classes.Passport EditPassports;
        public Add(Classes.Passport EditPassports)
        {
            InitializeComponent();
            if (EditPassports != null)
            {
                Name.Text = EditPassports.Name;
                FirstName.Text = EditPassports.FirstName;
                LastName.Text = EditPassports.LastName;
                Issued.Text = EditPassports.Issued; 
                DateOfIssued.Text = EditPassports.DateOfIssued; 
                DepartmentCode.Text = EditPassports.DepartmentCode; 
                SeriesAndNumber.Text = EditPassports.SeriesAndNumber; 
                DateOfBirth.Text = EditPassports.DateOfBirth; 
                PlaceOfBirth.Text = EditPassports.PlaceOfBirth;
                BthImage.Tag = EditPassports.Image;
                BthImage.Content = "Фото ✔";
                this.EditPassports = EditPassports;
                BthAdd.Content = "Изменить";
            }
        }

        private void AddPassport(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", Name.Text))
            {
                MessageBox.Show("Не правильно указано имя пользователя");
                return;
            }
            if (string.IsNullOrEmpty(FirstName.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", FirstName.Text))
            {
                MessageBox.Show("Не правильно указана фамилия пользователя");
                return;
            }
            if (string.IsNullOrEmpty(LastName.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", LastName.Text))
            {
                MessageBox.Show("Не правильно указано отчество пользователя");
                return;
            }
            if (string.IsNullOrEmpty(Issued.Text) || !Classes.Common.CheckRegex.Match(@"^[а-яА-я]+\s([а-яА-я]+\s)*([а-яА-я]+)$", Issued.Text))
            {
                MessageBox.Show("Не правильно заполнено поле паспорт выдан");
                return;
            }
            if (string.IsNullOrEmpty(DateOfIssued.Text) || !Classes.Common.CheckRegex.Match("[0-3][0-9]\\.[0-1][0-9]\\.[1-2][0-9]{3}", DateOfIssued.Text))
            {
                MessageBox.Show("Не правильно заполенно поле дата выдачи");
                return;
            }
            if (string.IsNullOrEmpty(DepartmentCode.Text) || !Classes.Common.CheckRegex.Match("^([0-9]{3})-([0-9]{3})$", DepartmentCode.Text))
            {
                MessageBox.Show("Не правильно заполнено поле код подразделения");
                return;
            }
            if (string.IsNullOrEmpty(SeriesAndNumber.Text) || !Classes.Common.CheckRegex.Match(@"^([0-9]{2})\s[0-9]{2}\s([0-9]{6})$", SeriesAndNumber.Text))
            {
                MessageBox.Show("Не правильно заполнено поле серия и номер");
                return;
            }
            if (string.IsNullOrEmpty(DateOfBirth.Text) || !Classes.Common.CheckRegex.Match("[0-3][0-9]\\.[0-1][0-9]\\.[1-2][0-9]{3}", DateOfBirth.Text))
            {
                MessageBox.Show("Не правильно заполнено поле дата рождения");
                return;
            }
            if (string.IsNullOrEmpty(PlaceOfBirth.Text) || !Classes.Common.CheckRegex.Match(@"(([а-яА-я]*\\.\s)*[а-яА-я]+@)*([а-яА-я]+)$", PlaceOfBirth.Text))
            {
                MessageBox.Show("Не правильно заполнено поле место рождения");
                return;
            }
            if (string.IsNullOrEmpty(BthImage.Tag as string))
            {
                MessageBox.Show("Нет фото");
                return;
            }
            if (EditPassports == null)
            {
                EditPassports = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassports);
            }
            EditPassports.Name = Name.Text;
            EditPassports.FirstName = FirstName.Text;
            EditPassports.LastName = LastName.Text;
            EditPassports.Issued = Issued.Text;
            EditPassports.DateOfIssued = DateOfIssued.Text;
            EditPassports.DepartmentCode = DepartmentCode.Text;
            EditPassports.SeriesAndNumber = SeriesAndNumber.Text;
            EditPassports.DateOfBirth = DateOfBirth.Text;
            EditPassports.PlaceOfBirth = PlaceOfBirth.Text;
            EditPassports.Image = BthImage.Tag as string;
            MainWindow.init.LoadPassport();
            this.Close();
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.jpg;*.png";
            if(ofd.ShowDialog() == true)
            {
                BthImage.Content = "Фото ✔";
                BthImage.Tag = ofd.FileName;
            }
        }
    }
}
