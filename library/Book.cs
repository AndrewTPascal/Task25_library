using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace library
{
    internal class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        // Внешний ключ
        public int? UserId { get; set; }
        public User User { get; set; }

        // Внешний ключ
        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        // Внешний ключ
        public int GengeId { get; set; }
        public Genge Genge { get; set; }



    }
}
