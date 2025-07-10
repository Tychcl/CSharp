using Int.Interfaces;
using Int.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.Classes
{
    public class UsersContext: Users, IUsers 
    {
        public List<Users> AllUsers;

        public UsersContext() =>
            this.All(out AllUsers);

        public void All(out List<Users> Users)
        {
            Users = new List<Users>();

            AllUsers.Add(new Users(1, "Аликина Ольга"));
            AllUsers.Add(new Users(2, "Бояркин Данил"));
            AllUsers.Add(new Users(3, "Бурмантов Владислав"));
            AllUsers.Add(new Users(4, "Дылдин Максим"));
            AllUsers.Add(new Users(5, "Евдокимов Даниил"));
            AllUsers.Add(new Users(6, "Костюнин Никита"));
            AllUsers.Add(new Users(7, "Кучин Данил"));
            AllUsers.Add(new Users(8, "Мотырев Александр"));
            AllUsers.Add(new Users(9, "Мухридинов Далер"));
            AllUsers.Add(new Users(10, "Олейник Владимир"));
            AllUsers.Add(new Users(11, "Саблин Константин"));
            AllUsers.Add(new Users(12, "Субботин Валерий"));
            AllUsers.Add(new Users(13, "Сукрушев Егор"));
            AllUsers.Add(new Users(14, "Торсунов Даниил"));
            AllUsers.Add(new Users(15, "Хабибрахиманов Никита"));
            AllUsers.Add(new Users(16, "Хикматулин Григорий"));
            AllUsers.Add(new Users(17, "Черенев Сергей"));
            AllUsers.Add(new Users(18, "Чупин Дмистрий"));
            AllUsers.Add(new Users(19, "Шилов Дмитрий"));
        }
    }
}
