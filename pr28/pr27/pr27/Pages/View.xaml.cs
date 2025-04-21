using pr27.Classes;
using pr27.Common;
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

namespace pr27.Pages
{
    public partial class View : Page
    {
        public View(MainWindow.pages p)
        {
            InitializeComponent();
            if (p == MainWindow.pages.Afisha)
            {
                Afisha.All();
                foreach(object i in DBConnection.Afishas)
                {
                    parent.Children.Add(new Items.Item(i));
                }
            }
            if (p == MainWindow.pages.Theatre)
            {
                Theatre.All();
                foreach (object i in DBConnection.Theatres)
                {
                    parent.Children.Add(new Items.Item(i));
                }
            }
            parent.Children.Add(new Items.add());
        }
    }
}
