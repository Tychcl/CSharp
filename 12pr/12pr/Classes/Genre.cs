using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12pr.Classes
{
    public class Genre
    {
        // <summary> Код жанра

        public int Id { get; set; }
        //<summary> Наименование жанра

        public string Name { get; set; }
        //<summary> Конструктор для жанров

        public Genre(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
               // <summary> Репозиторий данных
      
        public static List<Genre> AllGenres() {
            // Создаём список
            List<Genre> allGenres = new List<Genre>();
            // Заполняем список
            allGenres.Add(new Genre(1,"Современная русская литература"));
            allGenres.Add(new Genre(2,"Современные детективы"));
            allGenres.Add(new Genre(3,"Любовное фэнтези"));
            allGenres.Add(new Genre(4,"Попаданцы"));
            allGenres.Add(new Genre(5,"Юмористическое фэнтези"));
             // Возвращаем список
            return allGenres;

        } 
    }
}
