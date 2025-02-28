using Int.Classes;
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
    /// <summary>
    /// Логика взаимодействия для Messages.xaml
    /// </summary>
    public partial class Messages : UserControl
    {
        public MessagesContext ThisMessage;
        public Messages(Classes.MessagesContext messages)
        {
            InitializeComponent();
            ThisMessage = messages;
            Message.Text = messages.Massage;
            if (messages.image != "" & messages.image != null)
            {
                iso.Height = 150;
                iso.Source = new BitmapImage(new Uri(messages.image));
            }
            else
            {
                iso.Height = 0;
            }
            Date.Text = messages.Create.ToString("dd.MM.yyyy");
        }

        private void DeleteMessage(object sender, MouseButtonEventArgs e)
        {
            ThisMessage.Delete();
            MainWindow.mainWindow.perentMessage.Children.Remove(this);
        }

        private void Ismenenie(object sender, RoutedEventArgs e)
        {
            ThisMessage.izm = !ThisMessage.izm;
        }
    }
}
