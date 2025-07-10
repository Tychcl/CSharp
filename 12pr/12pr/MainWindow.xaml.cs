using _12pr.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _12pr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddAuthors();
            AddGenres();
            AddYears();
            // Создаём книги на UI
            CreateUI(AllBooks);

        }
        // Метод создания книг

        public void CreateUI(List<Classes.Book> AllBooks)
        {
            // Очищаем холст
            parent.Children.Clear();
            // Перебираем книги
            foreach (Classes.Book Book in AllBooks)
                //Добавялем элемент в StackPanel
                parent.Children.Add(new Elements.Element(Book));
        }


        // Метод добавления авторов в выпадающий список
        //< summary > Все авторы
        List<Classes.Author> AllAuthors = Classes.Author.AllAuthors();
        // Все жанры
        List<Classes.Genre> AllGenres = Classes.Genre.AllGenres();
        //Все книги
        List<Classes.Book> AllBooks = Classes.Book.AllBook();

        public void AddAuthors()
        {
            //Добавляем пункт выберите
            cbAuthors.Items.Add("Выберите ...");
            // Перебираем авторов
            foreach (Classes.Author Author in AllAuthors)
                // Добавляем пункт с автором
                cbAuthors.Items.Add(Author.FIO);
        }
        //Метод добавления жанров в выпадающий список

        public void AddGenres()
        {
            // Добавляем пункт выберите
            cbGenres.Items.Add("Выберите ... ");
            // Перебираем жанры
            foreach (Classes.Genre Genre in AllGenres)
                // Добавляем пункт с жанром
                cbGenres.Items.Add(Genre.Name);
        }
        // Метод добавления годов

        public void AddYears()
        {
            // Добавляем пункт выберите
            cbYear.Items.Add("Выберите ...");
            // Создаём коллекцию из годов
            List<int> AllYears = new List<int>();
            // Перебираем книги
            foreach (Classes.Book Book in AllBooks)
                // Если в коллекции нет нашего года
                if (AllYears.Find(x => x == Book.Year) == 0)
                {
                    // Добавляем год в коллекцию
                    AllYears.Add(Book.Year);
                    // Добавляем год в выпадающий список
                    cbYear.Items.Add(Book.Year);

                }
        }
        private void Search_Book(object sender, KeyEventArgs e) => Search();
        private void SelectAuthor(object sender, SelectionChangedEventArgs e) => Search();
        public void Search()
        {
            // Ищем книги при поиске
            List<Classes.Book> FindBook = AllBooks.FindAll(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower()));
            // Если выбран автор
            if (cbAuthors.SelectedIndex > 0)
            {
                // Ищем выбранного автора
                Classes.Author SelectAuthor = AllAuthors.Find(x => x.FIO == cbAuthors.SelectedItem.ToString());
                // Ищем выбранные книги
                FindBook = FindBook.FindAll(x => x.Authors.Find(y => y.Id == SelectAuthor.Id) != null);

            }
            //Если выбран жанр
            //
            if (cbGenres.SelectedIndex > 0)
            {
                // Ищем выбранный жанр
                Classes.Genre SelectGender = AllGenres.Find(x => x.Name == cbGenres.SelectedItem.ToString());
                // Ищем выбранные книги
                FindBook = FindBook.FindAll(x => x.Genres.Find(y => y.Id == SelectGender.Id) != null);

            }
            // Если выбран год
            if (cbYear.SelectedIndex > 0)
            {
                // Ищем выбранные книги
                FindBook = FindBook.FindAll(x => x.Year == Convert.ToInt32(cbYear.SelectedItem.ToString()));


            }
            CreateUI(FindBook);


        }
        SaveFileDialog sfd = new SaveFileDialog();
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        List<Book> books = Book.AllBook();
                        foreach (var book in books)
                        {
                            // Сериализация данных в строку
                            string genres = string.Join(";", book.Genres.ConvertAll(g => g.Name));
                            string authors = string.Join(";", book.Authors.ConvertAll(a => a.FIO));
                            string line = $"{book.Id},{book.Name},{book.Year},{genres},{authors}";
                            writer.WriteLine(line);
                        }
                    }

                    MessageBox.Show("Данные успешно сохранены в файл.", "Сохранение", MessageBoxButton.OK);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка при сохранении данных", MessageBoxButton.OK);
                }
            }
        }

        private void Save_zagryzka(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(ofd.FileName, Encoding.UTF8))
                    {
                        List<Genre> allGenres = Genre.AllGenres();  //жанры
                        List<Author> allAuthors = Author.AllAuthors(); //авторы
                        List<Book> loadedBooks = new List<Book>(); //список книг

                        string line;
                        while ((line = reader.ReadLine()) != null)//Чтение файла построчно. Каждая строка содержит данные о книге и  будет обработана по очереди.

                        {
                            string[] parts = line.Split(',');

                            if (parts.Length < 5)//Каждая строка разбивается на массив строк с использованием запятой в качестве разделителя. Если количество частей меньше 5, значит, строка неполная, и она пропускается.
                                continue;

                            int bookId = Convert.ToInt32(parts[0]);
                            string bookName = parts[1];
                            int year = Convert.ToInt32(parts[2]);
                            string[] genres = parts[3].Split(';');
                            string[] authors = parts[4].Split(';');

                            // Поиск жанров по имени
                            List<Genre> bookGenres = new List<Genre>();
                            foreach (var genreName in genres)
                            {
                                Genre genre = allGenres.FirstOrDefault(g => g.Name == genreName.Trim());
                                if (genre != null)
                                    bookGenres.Add(genre);
                            }
                            // Поиск авторов по имени
                            List<Author> bookAuthors = new List<Author>();
                            foreach (var authorName in authors)
                            {
                                Author author = allAuthors.FirstOrDefault(a => a.FIO == authorName.Trim());
                                if (author != null)
                                    bookAuthors.Add(author);
                            }
                            Book newBook = new Book(bookId, bookName, bookGenres, bookAuthors, year);
                            loadedBooks.Add(newBook);
                        }
                        CreateUI(loadedBooks);
                        MessageBox.Show("Данные успешно загружены.", "Загрузка", MessageBoxButton.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при загрузке данных", MessageBoxButton.OK);
                }
            }
        }
    }
}
