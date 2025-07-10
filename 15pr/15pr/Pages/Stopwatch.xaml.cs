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
using System.Windows.Threading;

namespace _15pr.Pages
{
    public partial class Stopwatch : Page
    {
        public Interval LastInt = new Interval(0, "0");
        public DispatcherTimer Timer = new DispatcherTimer();
        public float full_second = 0;
        public bool start_stopwatch = false;

        public Stopwatch()
        {
            InitializeComponent();

            Timer.Tick += TimerSecond;
            Timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void TimerSecond(object sender, EventArgs e)
        {
            full_second++;
            float hours = (int)(full_second / 60 / 60);
            float minutes = (int)(full_second / 60) - (hours * 60);
            float seconds = full_second - (hours * 60 * 60) - (minutes * 60);
            string s_sec = seconds.ToString();
            if (seconds < 10) s_sec = "0" + seconds.ToString();
            string s_min = minutes.ToString();
            if (minutes < 10) s_min = "0" + minutes.ToString();
            string s_hours = hours.ToString();
            if (hours < 10) s_hours = "0" + hours.ToString();
            time.Content = $"{s_hours}:{s_min}:{s_sec}";    
        }

        private void StartStopwatch(object sender, RoutedEventArgs e)
        {
            if (!start_stopwatch)
            {
                full_second = 0;
                Timer.Start();
                start_stopwatch = true;
                start.Content = "Стоп";
            }
            else
            {
                Timer.Stop();
                start_stopwatch = false;
                start.Content = "Начать";
            }
        }

        private void Interval(object sender, RoutedEventArgs e)
        {
            LastInt = new Interval(LastInt.Id + 1, time.Content as string);
            list.Items.Add(LastInt);
        }
    }
}
