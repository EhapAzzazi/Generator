using System;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write($"FirstName: ");
                var fname = Console.ReadLine();

                Console.Write($"LastName: ");
                var lname = Console.ReadLine();

                Console.Write($"HireDate (yyyy-MM-dd): ");
                DateTime? hiredate = null;
                if (DateTime.TryParse(Console.ReadLine(), out DateTime hdate)) { hiredate = hdate; }

                Console.Write($"Password Length: ");
                int Length = 0;
                if (int.TryParse(Console.ReadLine(), out int length)) { Length = length; }
                else { Length = 10; }

                Console.WriteLine("====================================");

                Console.WriteLine($"ID: {Generator.GenerateID(fname, lname, hiredate)}");
                Console.WriteLine($"Password: {Generator.GeneratePassword(Length)}");

                Console.WriteLine("====================================");
            } while (true);
        }
    }
}
