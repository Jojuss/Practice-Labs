using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (true)
            {
                Console.Clear();
                switch (i)
                {
                    case 0:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 6            |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 10           |");
                            Console.WriteLine("----------------------------------");

                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|               Exit             |");
                            Console.WriteLine("----------------------------------");
                        }
                        break;
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 6            |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 10           |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|               Exit             |");
                            Console.WriteLine("----------------------------------");
                        }
                        break;
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 6            |");
                            Console.WriteLine("----------------------------------");

                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 10           |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|               Exit             |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                }
                ConsoleKeyInfo d = Console.ReadKey();
                if (d.KeyChar == 'w') if (i - 1 < 0) i = 2; else i--;
                if (d.KeyChar == 's') if (i + 1 > 2) i = 0; else i++;
                if (d.Key == ConsoleKey.Enter) 
                {
                    bool anyExceptions = true;
                    switch(i)
                    {
                        case 0:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter 2 numbers:");
                                    try
                                    {
                                        int a = Convert.ToInt32(Console.ReadLine());
                                        int b = Convert.ToInt32(Console.ReadLine());

                                        if ((a != 0) && b % a == 0) Console.WriteLine("Divisible.");
                                        else Console.WriteLine("Indivisible.");
                                        anyExceptions = false;
                                        Console.WriteLine("Press any key to return to menu...");
                                        Console.ReadKey();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            break;
                        case 1:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter 3 numbers:");
                                    try
                                    {
                                        int a = Convert.ToInt32(Console.ReadLine());
                                        int b = Convert.ToInt32(Console.ReadLine());
                                        int c = Convert.ToInt32(Console.ReadLine());

                                        if ((b - a) != 0 && (a + b + c) % (b - a) == 0) Console.WriteLine("Divisible.");
                                        else Console.WriteLine("Indivisible.");
                                        anyExceptions = false;
                                        Console.WriteLine("Press any key to return to menu...");
                                        Console.ReadKey();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                    }
                }
                if (d.Key == ConsoleKey.Escape) Environment.Exit(0);
            }
        }
    }
}
