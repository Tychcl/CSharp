using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Tabels
{
    public class Staff
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Library {  get; set; }
        public string Profession { get; set; }
        public string Birthday { get; set; }
        public string Date { get; set; }
        public string Education { get; set; }
        public int Pay {  get; set; }

        public Staff(int id, string fio, string email, string password, int library, string profession, string birthday, string date, string education, int pay)
        {
            Id = id;
            FIO = fio;
            Email = email;
            Password = password;
            Library = library;
            Profession = profession;
            Birthday = birthday;
            Date = date;
            Education = education;
            Pay = pay;
        }
    }
}
