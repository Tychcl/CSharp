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
using pr16.Classes;

namespace pr16.Pages
{
    /// <summary>
    /// Логика взаимодействия для Statement.xaml
    /// </summary>
    public partial class Statement : Page
    {
        public Statement()
        {
            InitializeComponent();
        }
        public void NextPage(object sender, RoutedEventArgs e)
        {
            List<CheckBox> CheckBox1 = new List<CheckBox>();
            foreach (CheckBox c in formEducation1.Children)
                CheckBox1.Add(c);

            List<CheckBox> CheckBox2 = new List<CheckBox>();
            foreach (CheckBox c in formEducation2.Children)
                CheckBox2.Add(c);

            if (!CheckRegex.CheckListCheckBox(CheckBox1))
            {
                MessageBox.Show("Выберите форму обучения");
                return;
            }
            if (!CheckRegex.CheckListCheckBox(CheckBox2))
            {
                MessageBox.Show("Выберите форму обучения");
                return;
            }
            if (!CheckRegex.CheckText(organizationName.Text))
            {
                MessageBox.Show("Не правильно заполнено поле образовательной организации");
                return;
            }
            if (!CheckRegex.CheckYear(yearGraduation.Text))
            {
                MessageBox.Show("Неверный формат года.Формат:YYYY");
                return;
            }
            MainWindow.mainWindow.OpenPage(MainWindow.pages.Education);
        }
    }
}
