using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12pr.Classes
{
    public class Author
    {
        //<summary> Код автора

        public int Id { get; set; }
        //<summary> фио автора

        public string FIO { get; set; }
        //<summary> Конструктор автора

        public Author(int Id, string FIO) {
            this.Id = Id;
            this.FIO = FIO;

        }
        // <summary> Репозиторий авторов 
        public static List<Author> AllAuthors() {
            // Создаём список авторов
            List<Author> allAuthors = new List<Author>();
            // Заполняем список
            allAuthors.Add(new Author(1, "Виктор Пелевин"));
            allAuthors.Add(new Author(2, "Александра Маринина"));
            allAuthors.Add(new Author(3, "Ольга Герр"));
            // Возвращам список
            return allAuthors;

        } 
    }
}
