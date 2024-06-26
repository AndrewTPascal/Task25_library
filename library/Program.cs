namespace library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                //Добавление данных
                var book1 = new Book { Name = "1984", Year = 1984 };
                var book2 = new Book { Name = "Конституция РФ", Year = 1990 };
                var book3 = new Book { Name = "Колобок", Year = 2000 };
                var book4 = new Book { Name = "Репка", Year = 2000 };
                var book5 = new Book { Name = "Вредные советы", Year = 1995 };
                var book6 = new Book { Name = "Вредные советы 2", Year = 2000 };
                var book7 = new Book { Name = "Как бросить курить", Year = 2010 };
                var book8 = new Book { Name = "Букварь", Year = 1991 };
                var book9 = new Book { Name = "Скотный двор", Year = 1980 };

                var user1 = new User { Name = "Олег Тиньков", Email = "tbank@tn.ok" };
                var user2 = new User { Name = "Юрий Хой", Email = "sgaza@sg.hoi" };
                var user3 = new User { Name = "Валерий Кипелов", Email = "aria@metall.com" };
                var user4 = new User { Name = "Ольга Арбузова", Email = "arbuz@pop.com" };
                var user5 = new User { Name = "Данила Багров", Email = "brat@brat.ru" };
                var user6 = new User { Name = "Вячеслав Бутусов", Email = "naulilus@na.com" };
                var user7 = new User { Name = "Артур Пирожков", Email = "reva@kvn.ru" };

                var author1 = new Author { Name = "Дж. Оруэл" };
                var author2 = new Author { Name = "Г. Остер" };
                var author3 = new Author { Name = "В. Языковедов" };
                var author4 = new Author { Name = "А. Зожников" };
                var author5 = new Author { Name = "М. Горбачёв" };

                var genge1 = new Genge { Name = "антиутопия" };
                var genge2 = new Genge { Name = "сказки" };
                var genge3 = new Genge { Name = "разное" };
                var genge4 = new Genge { Name = "юмор" };

                book1.User = user1;
                book1.Author = author1;
                book1.Genge = genge1;

                book2.User = user1;
                book2.Author = author5;
                book2.Genge = genge3;

                book3.Genge = genge2;

                book4.Genge = genge2;

                book5.Author = author2;
                book5.Genge = genge4;

                book6.Author = author2;
                book6.Genge = genge4;

                book7.User = user4;
                book7.Author = author4;
                book7.Genge = genge3;

                book8.Genge = genge3;

                book9.User = user5;
                book9.Author = author1;
                book9.Genge = genge1;

                db.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9);
                db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7);
                db.Authors.AddRange(author1, author2, author3, author4, author5);
                db.Genges.AddRange(genge1, genge2, genge3, genge4);

                db.SaveChanges();

                BookRepository.db = db;
                BookRepository.BookGengeYearQuery1();
                BookRepository.SumBookAuthorQuery2();
                BookRepository.BookGengeQuery3();
                BookRepository.BookAuthorGengeQuery4();
                BookRepository.BookOnHandQuery5();
                BookRepository.SumBookOnHandQuery6();
                BookRepository.LastBookQuery7();
                BookRepository.bookListNameQuery8();
                BookRepository.bookListYearQuery9();
            }
        }
    }
}
