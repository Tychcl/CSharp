using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using pr33.Classes;

namespace pr33.Pages
{
    /// <summary>
    /// Логика взаимодействия для Messanger.xaml
    /// </summary>
    public partial class Messanger : Page
    {
        public DispatcherTimer t = new DispatcherTimer() { Interval = new System.TimeSpan(0,0,3)};
        public User SelectedUser { get; set; }
        public Messanger()
        {
            InitializeComponent();
            LoadUsers();
            t.Tick += tt;
            t.Start();

        }

        public void LoadUsers()
        {
            using (var con = new Context())
            {
                foreach (var user in con.User)
                {
                    if (user.Id != MainWindow.init.user.Id)
                        users.Children.Add(new Pages.Items.User(user, this));
                }
            }
        }

        public void selectuser(Classes.User user)
        {
            SelectedUser = user;
            message.Children.Clear();
            using(var con = new Context())
            {
                var asd = con.Message.Where(x => (x.UserId == user.Id && x.ChatId == MainWindow.init.user.Id)
            || (x.UserId == MainWindow.init.user.Id && x.ChatId == user.Id)).ToList();
                foreach (var message in asd)
                {
                    this.message.Children.Add(new Pages.Items.Message(message, con.User.Where(x => x.Id == message.UserId).First()));
                }
            }
        }

        private void enter(object sender, KeyEventArgs e)
        {
            if (MainWindow.init.user != null && e.Key == Key.Enter)
            {
                using (var con = new Context())
                {
                    con.Message.Add(new Message
                    {
                        UserId = MainWindow.init.user.Id,
                        ChatId = SelectedUser.Id,
                        Text = text.Text
                    });
                    con.SaveChanges();
                    selectuser(SelectedUser);
                    text.Text = "";
                }
            }
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.SignIn());
        }

        private void tt(object sender, System.EventArgs e)
        {
            if(SelectedUser != null)
            {
                selectuser(SelectedUser);
            }
        }

    }
}
