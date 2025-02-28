using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12pr.Classes
{
    public class Book
    {
        //<summary> Код книги
        public int Id { get; set; }
        //<summary> Наименование
        public string Name { get; set; }
        //<summary> Жанры
        public List<Genre> Genres { get; set; }
        //<summary> Авторы
        public List<Author> Authors { get; set; }
        public int Year {get; set;}
        public Book(int Id, string Name, List<Genre> Genres, List<Author> Authors, int Year)
        {
            this.Id = Id;
            this.Name = Name;
            this.Genres= Genres;
            this.Authors = Authors;
            this.Year = Year;
        }
        // <summary> Репозиторий книг
        public static List<Book> AllBook() {
            // Создаём список
            List<Book> allBook = new List<Book>();
            // Добавляем в список книги
            allBook.Add(new Book(
                1, "Путешествие в Элевсин",
                Genre.AllGenres().FindAll(x => x.Id == 1),
                Author.AllAuthors().FindAll(x => x.Id == 1), 2023));
            allBook.Add(new Book(
                2, "Чапаев и Пустота",
                Genre.AllGenres().FindAll(x => x.Id == 1),
                Author.AllAuthors().FindAll(x => x.Id == 1), 2008));
            allBook.Add(new Book(
                3, "Дебютная постановка. Том 1",
                Genre.AllGenres().FindAll(x => x.Id == 2),
                Author.AllAuthors().FindAll(x => x.Id == 2), 2023));
            allBook.Add(new Book(
                4, "Дебютная постановка. Том 2",
                Genre.AllGenres().FindAll(x => x.Id == 2),
                Author.AllAuthors().FindAll(x => x.Id == 2), 2023));
            allBook.Add(new Book(
                5, "Охота на попаданку. Бракованная жена",
                Genre.AllGenres().FindAll(x => x.Id == 2 || x.Id == 3 || x.Id == 4),
                Author.AllAuthors().FindAll(x => x.Id == 3), 2022));
            // Возвращаем всписок
            return allBook;

        }
        // <summary> Список жанров через запятую
        public string ToGenres() {
            //Выходная строка
            string toGenres = "";
            //Перебираем жанры
            for (int iGenre = 0; iGenre < this.Genres.Count; iGenre++)
            {
                // Добавляем жанры в строку
                toGenres += this.Genres[iGenre].Name;
                // Добавляем запятую
                if (iGenre < this.Genres.Count - 1)
                    toGenres += ", ";
            }
            // Возвращаем результат
            return toGenres;
        }
        //список авторов через запятую
        public string ToAuthors() {
            //Выходная строка
            string toAuthors = "";
            // Перебираем авторов
            for (int iAuthor = 0; iAuthor < this.Authors.Count; iAuthor++)
            {
                // Добавляем авторов в строку
                toAuthors += this.Authors[iAuthor].FIO;
                // Добавляем запятую
                if (iAuthor < this.Authors.Count - 1)
                    toAuthors += ", ";
            }
            // Возвращаем авторов
            return toAuthors;
        }
    }
}
