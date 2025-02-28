using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfApp1.Classes
{
    public class TV
    {
        public string path;
        private int activeChannel;
        private double activeVolume = 45;
        public double ActiveVolume
        {
            get { return activeVolume; }
            set
            {
                if (activeVolume <= 100 && activeVolume >= 0) activeVolume = value;
                else if (activeVolume > 100) activeVolume = 100;
                else if (activeVolume < 0) activeVolume = 0;
            }
        }
        public int ActiveChannel
        {
            get { return activeChannel; }
            set
            {
                if (activeChannel < Channels.Count - 1)
                    activeChannel = value;
                else
                    activeChannel = 0;
                if (activeChannel < 0)
                    activeChannel = Channels.Count - 1;

            }
        }
        public List<Channel> Channels = new List<Channel>();
        public TV()
        {
            Channels.Add(new Channel()
            {

                Name = "Тофф",
                Src = @"C:\\Users\\Administrator\\Desktop\\Ych\\PR\\0101oshepkov\\6pr\\WpfApp1\\WpfApp1\\Media\\catarahopes.mp4"
            });
            Channels.Add(new Channel()
            {

                Name = "Катара",
                Src = @"C:\\Users\\Administrator\\Desktop\\Ych\\PR\\0101oshepkov\\6pr\\WpfApp1\\WpfApp1\\Media\\catarahopes.mp4"
            });
            Channels.Add(new Channel()
            {

                Name = "Сока",
                Src = @"C:\\Users\\Administrator\\Desktop\\Ych\\PR\\0101oshepkov\\6pr\\WpfApp1\\WpfApp1\\Media\\sokamemes.mp4"
            });
        }
        //метод смены канала

        public void SwapChanell(MediaElement _MediaElement, Label _NameChannel)
        {
            DoubleAnimation StartAnimation = new DoubleAnimation();
            StartAnimation.From = 1;
            StartAnimation.To = 0;
            StartAnimation.Duration = TimeSpan.FromSeconds(0.6);
            StartAnimation.Completed += delegate
            {
                _MediaElement.Source = new Uri(this.Channels[this.ActiveChannel].Src);
                _MediaElement.Play();
                DoubleAnimation EndAnimation = new DoubleAnimation();
                EndAnimation.From = 0;
                EndAnimation.To = 1;
                EndAnimation.Duration = TimeSpan.FromSeconds(0.6);
                _MediaElement.BeginAnimation(MediaElement.OpacityProperty, EndAnimation);
            };
            _MediaElement.BeginAnimation(MediaElement.OpacityProperty, StartAnimation);
            _NameChannel.Content = this.Channels[this.ActiveChannel].Name;

        }
        //Следующий канал
        public void NextChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel++;
            SwapChanell(_MediaElement, _NameChannel);
        }
        //предыдущий канал
        public void BackChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel--;
            SwapChanell(_MediaElement, _NameChannel);
        }
        //увеличение громкости
        public void UpSound(MediaElement _MediaElement)
        {
            ActiveVolume += 10;
            _MediaElement.Volume = Math.Round((double)ActiveVolume / 100, 2);
        }
        //уменьшение громкости
        public void DownSound(MediaElement _MediaElement)
        {
            ActiveVolume -= 10;
            _MediaElement.Volume = Math.Round((double)ActiveVolume / 100, 2);
        }
    }
}
