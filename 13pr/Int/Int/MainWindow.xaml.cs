using Int.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Int
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UsersContext usersContext=new Classes.UsersContext();
        public MessagesContext messagesContext=new Classes.MessagesContext();
        public string iso { get; set; }
        public int IdSelectUser = -1;
        public static MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            LoadUser();
        }
        public void LoadUser()
        {
            foreach(Models.Users User in usersContext.AllUsers)
                ParentUser.Children.Add(new Elements.Users(User));
        }

        public void SelectUser(Models.Users User) 
        {
            if (User != null)
                IdSelectUser = usersContext.AllUsers.FindIndex(x => x == User);
            perentMessage.Children.Clear();
            foreach(MessagesContext Messages in MessagesContext.AllMessages.FindAll(x=>x.IdUser==IdSelectUser))
                perentMessage.Children.Add(new Elements.Messages(Messages));
            BlockMessage.IsEnabled = true;
        }

        private void SendMessages(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                // Если пользователь не выбран, останавливаем выполенение 
                if (IdSelectUser == -1) return;
                MessagesContext curmsg = MessagesContext.AllMessages.Find(x => x.izm == true & x.IdUser == IdSelectUser) as MessagesContext;
                if (curmsg != null)
                {
                    curmsg.Save(curmsg.Id, IdSelectUser, Message.Text);
                    Message.Text = "";
                    // Пересоздаём сообщения 
                    SelectUser(null);
                }
                else
                {
                    usersContext.AllUsers[IdSelectUser].LastMsgId += 1;

                    MessagesContext newMessages = new MessagesContext(Message.Text, DateTime.Now, IdSelectUser, iso);
                    // Сохраняем сообщение 
                    newMessages.Id = usersContext.AllUsers[IdSelectUser].LastMsgId;
                    newMessages.Save();
                    // Чистим ввод
                    Message.Text = "";
                    // Пересоздаём сообщения 
                    SelectUser(null);
                }
            }
        }

        private void SendImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdSelectUser == -1) return;
            // Создаём сообщение
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == true)
            {
                iso = opd.FileName;
            }
            MessagesContext newMessages =
                new MessagesContext(Message.Text, DateTime.Now, IdSelectUser, iso); // Сохраняем сообщение
            newMessages.image = iso;
            usersContext.AllUsers[IdSelectUser].LastMsgId += 1;
            newMessages.Id = usersContext.AllUsers[IdSelectUser].LastMsgId;
            iso = "";
            newMessages.Save();
            // Чистим ввод
            Message.Text = "";
            // Пересоздаём сообщения
            SelectUser(null);
        }
    }
}
