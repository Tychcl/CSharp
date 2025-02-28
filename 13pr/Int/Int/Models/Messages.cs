using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.Models
{
    public class Messages
    {
        public bool izm = false;
        public int Id { get; set;}
        public string Massage { get; set;}
        public DateTime Create { get; set; }
        public int IdUser { get; set; }
        public string  image { get; set; }
        public Messages() { }

        public Messages(string Massage, DateTime Create, int IdUser, string image)
        {
            this.Massage = Massage;
            this.Create = Create;
            this.IdUser = IdUser;
            this.image = image;
        }

        public Messages(string massage, DateTime create, int idUser)
        {
            Massage = massage;
            Create = create;
            IdUser = idUser;
        }
    }
}
