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
    /// Логика взаимодействия для Speciality.xaml
    /// </summary>
    public partial class Speciality : Page
    {
        public Speciality()
        {
            InitializeComponent();
        }
        public void NextPage(object sender, RoutedEventArgs e)
        {

            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (CheckBox checkBox in speciality.Children)
                checkBoxes.Add(checkBox);
            List<CheckBox> CheckBox1 = new List<CheckBox>();
            foreach (CheckBox c in license.Children)
                CheckBox1.Add(c);

            List<CheckBox> CheckBox2 = new List<CheckBox>();
            foreach (CheckBox c in document.Children)
                CheckBox2.Add(c);

            if (!CheckRegex.CheckListCheckBox(checkBoxes))
            {
                MessageBox.Show("Выберите минимум 1 специальность");
                return;
            }
            if (!CheckRegex.CheckListCheckBox(CheckBox1))
            {
                MessageBox.Show("Подтвердите ознакомление с документами");
                return;
            }
            if (!CheckRegex.CheckListCheckBox(CheckBox2))
            {
                MessageBox.Show("Подтвердите ознакомление с документами");
                return;
            }
            MainWindow.mainWindow.OpenPage(MainWindow.pages.Passport);
        }
    }
}
