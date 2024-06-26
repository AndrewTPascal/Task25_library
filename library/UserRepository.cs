using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    
    
    static internal class UserRepository
    {
        internal static AppContext db;

        internal static void create() 
        {
            Console.WriteLine("Введите имя пользователя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите e-mail пользователя: ");
            string email = Console.ReadLine();

            var user = new User { Name = name, Email = email };

            db.Users.Add(user);
            db.SaveChanges();

            Console.WriteLine("Пользователь добавлен");
            Console.WriteLine();
        }

        internal static void readID() 
        {
            Console.WriteLine("Введите ID пользователя: ");
            
            int id = Convert.ToInt32(Console.ReadLine());

            var user = db.Users.FirstOrDefault(u => u.Id == id);


            if (user != null)
                Console.WriteLine($"{user.Name} {user.Email}");
            else Console.WriteLine("Пользователь не найден!");

            Console.WriteLine();
        }

        internal static void readAll()
        {
            var allUsers = db.Users.ToList();

            foreach (var u in allUsers) 
            {
                Console.WriteLine($"{u.Id} {u.Name} {u.Email}");
            }
            Console.WriteLine();

        }



        internal static void updateName()
        {
            Console.WriteLine("Введите ID пользователя: ");

            int id = Convert.ToInt32(Console.ReadLine());

            var user = db.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                Console.WriteLine("Введите новое имя пользователя: ");
                string name = Console.ReadLine();
                user.Name = name;
                db.SaveChanges();
                Console.WriteLine("Пользователь изменён");
            }
            else Console.WriteLine("Пользователь не найден");

            Console.WriteLine();

        }

        internal static void delete()
        {
            Console.WriteLine("Введите ID пользователя: ");

            int id = Convert.ToInt32(Console.ReadLine());

            var user = db.Users.FirstOrDefault(u => u.Id == id);


            if (user != null)
            { 
                db.Users.Remove(user);
                db.SaveChanges();
                Console.WriteLine($"Пользователь {user.Name} удалён");
            }
            else Console.WriteLine("Пользователь не найден");

            Console.WriteLine();
        }



    }
}
