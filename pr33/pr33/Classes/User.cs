using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace pr33.Classes
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneMail { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }

        public User(string name, string phoneMail, string password, byte[] image)
        {
            Name = name;
            PhoneMail = phoneMail;
            Password = password;
            Image = image;
        }

        public BitmapImage Byte2Img()
        {
            BitmapImage image = new BitmapImage();
            using (var Stream = new MemoryStream(Image))
            {
                Stream.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = Stream;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

    }
}
