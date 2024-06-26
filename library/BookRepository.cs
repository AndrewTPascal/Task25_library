using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class BookRepository
    {
        internal static AppContext db;

        internal static void create()
        {
            Console.WriteLine("Введите название книги: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите год выпуска книги: ");
            int year = Convert.ToInt32(Console.ReadLine());

            var book = new Book { Name = name, Year = year };

            db.Books.Add(book);
            db.SaveChanges();

            Console.WriteLine("Книга добавлена");
            Console.WriteLine();
        }

        internal static void readID()
        {
            Console.WriteLine("Введите ID книги: ");

            int id = Convert.ToInt32(Console.ReadLine());

            var book = db.Books.FirstOrDefault(b => b.Id == id);


            if (book != null)
                Console.WriteLine($"{book.Name} {book.Year}");
            else Console.WriteLine("Книга не найдена!");

            Console.WriteLine();
        }

        internal static void readAll()
        {
            var allBooks = db.Books.ToList();

            foreach (var b in allBooks)
            {
                Console.WriteLine($"{b.Id} {b.Name} {b.Year}");
            }
            Console.WriteLine();

        }

        internal static void updateYear()
        {
            Console.WriteLine("Введите ID книги: ");

            int id = Convert.ToInt32(Console.ReadLine());

            var book = db.Books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                Console.WriteLine("Введите год выпуска: ");
                int year = Convert.ToInt32(Console.ReadLine());
                book.Year = year;
                db.SaveChanges();
                Console.WriteLine("Год выпуска изменён");
            }
            else Console.WriteLine("Книга не найдена");

            Console.WriteLine();

        }

        internal static void delete()
        {
            Console.WriteLine("Введите ID книги: ");

            int id = Convert.ToInt32(Console.ReadLine());

            var book = db.Books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                Console.WriteLine($"Книга {book.Name} удалена");
            }
            else Console.WriteLine("Книга не найдена");

            Console.WriteLine();
        }

        internal static void BookGengeYearQuery1() 
        {
            Console.WriteLine("Получить список книг определенного жанра и вышедших между определенными годами.");
            Console.WriteLine("Введите жанр: ");
            string genge = Console.ReadLine(); 
            Console.WriteLine("Введите начальный год: ");
            int from = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите конечный год: ");
            int to = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            var bookQuery = db.Books.Include(b => b.Genge).Where(b => b.Genge.Name == genge 
                && b.Year >= from && b.Year <= to).ToList();

            if (bookQuery.Count != 0)
            {
                foreach (var b in bookQuery)
                    Console.WriteLine(b.Name);
            }
            else Console.WriteLine("Не найдено!");
            Console.WriteLine();

        }

        internal static void SumBookAuthorQuery2()
        {
            Console.WriteLine("Получить количество книг определенного автора в библиотеке.");
            Console.WriteLine("Введите автора: ");
            string author = Console.ReadLine();
            Console.WriteLine();

            int bookCount = db.Books.Include(b => b.Author).Count(b => b.Author.Name == author);

            if (bookCount > 0)
            {
                Console.WriteLine($"Количество книг автора {author}: {bookCount}");
            }
            else Console.WriteLine($"Книг автора {author} нет в библотеке!");
            
            Console.WriteLine();
        }

        internal static void BookGengeQuery3()
        {
            Console.WriteLine("Получить количество книг определенного жанра в библиотеке.");
            Console.WriteLine("Введите жанр: ");
            string genge = Console.ReadLine();
            Console.WriteLine();

            var bookCount = db.Books.Include(b => b.Genge).Count(b => b.Genge.Name == genge);

            if (bookCount > 0)
            {
                Console.WriteLine($"Количество книг в жанре {genge}: {bookCount}");
            }
            else Console.WriteLine($"Книг в жанре {genge} нет в библотеке!");

            Console.WriteLine();
        }

        internal static void BookAuthorGengeQuery4()
        {
            Console.WriteLine("Есть ли книга определенного автора и с определенным названием в библиотеке.");
            Console.WriteLine("Введите автора: ");
            string author = Console.ReadLine();
            Console.WriteLine("Введите название книги: ");
            string name = Console.ReadLine();

            bool findBook = db.Books.Include(b => b.Author).Any(b => b.Author.Name == author && b.Name == name);

            if (findBook) 
            {
                Console.WriteLine("Такая книга есть!");
            }
            else
                Console.WriteLine("Такой книги нет!");

            Console.WriteLine();
        }

        internal static void BookOnHandQuery5()
        {
            Console.WriteLine("Есть ли книга на руках у пользователя.");
            Console.WriteLine("Введите название книги: ");
            string name = Console.ReadLine();
            bool findBook = db.Books.Any(b => b.Name == name && b.User != null);
            
            if (findBook)
            {
                Console.WriteLine("Книга на руках!");
            }
            else
                Console.WriteLine("Книга не на руках!");
            
            Console.WriteLine();
        }

        internal static void SumBookOnHandQuery6()
        {
            Console.WriteLine("Получить количество книг на руках у пользователя.");
            Console.WriteLine("Введите пользователя: ");
            string user = Console.ReadLine();
            int bookCount = db.Books.Include(b => b.User).Count(b => b.User.Name == user);

            if (bookCount > 0)
            {
                Console.WriteLine($"Количество книг на руках у пользователя: {bookCount}");
            }
            else Console.WriteLine($"У пользователя нет книг на руках!");

            Console.WriteLine();

        }

        internal static void LastBookQuery7()
        {
            int maxYear = db.Books.Max(b => b.Year);

            var book = db.Books.Where(b => b.Year == maxYear).ToList();

            if (book.Count != 0)
            {
                Console.WriteLine("Последняя вышедшая книга (книги):");
                foreach (var b in book)
                    Console.WriteLine(b.Name);
            }
            else Console.WriteLine("Не найдено!");

            Console.WriteLine();
        }

        internal static void bookListNameQuery8()
        {
            Console.WriteLine("Cписок всех книг в алфавитном порядке по названию.");

            var book = db.Books.OrderBy(b => b.Name).ToList();

            if (book.Count != 0)
            {
                 foreach (var b in book)
                    Console.WriteLine(b.Name);
            }
            else Console.WriteLine("Книг не найдено!");

            Console.WriteLine();

        }

        internal static void bookListYearQuery9()
        {
            Console.WriteLine("Cписок всех книг в порядке убывания года их выхода.");

            var book = db.Books.OrderByDescending(b => b.Year).ToList();

            if (book.Count != 0)
            {
                foreach (var b in book)
                    Console.WriteLine(b.Name);
            }
            else Console.WriteLine("Книг не найдено!");

            Console.WriteLine();
        }
    }
}
