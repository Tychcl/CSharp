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

namespace _11pr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] mas = new string[] { "Булатов Данил", "Вебер Василиса", "Винокуров Илья" };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Join()
        {
            list.Items.Add(string.Join(", ", mas));
        }

        private void Join(string x)
        {
            list.Items.Add(string.Join(x, mas));
        }

        private void go(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(sep.Text))
                {
                    Join();
                }
                else
                {
                    Join(sep.Text);
                }
            }
        }
    }
}
