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

namespace Int.Elements
{
    public partial class Users : UserControl
    {
        public Models.Users ThisUser;

        public Users(Models.Users User)
        {
            InitializeComponent();
            ThisUser = User;
            FIO.Text = User.FIO;
        }

        private void SelectUser(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.SelectUser(ThisUser);

        }
    }
}
