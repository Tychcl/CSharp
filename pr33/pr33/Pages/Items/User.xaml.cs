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

namespace pr33.Pages.Items
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public Classes.User user;
        private Messanger messanger;
        public User(Classes.User u, Messanger m)
        {
            InitializeComponent();
            user = u;
            login.Content = user.Name;
            imgSource.Source = u.Byte2Img();
            messanger = m;
        }

        private void choose(object sender, MouseButtonEventArgs e)
        {
            messanger.selectuser(user);
        }
    }
}
