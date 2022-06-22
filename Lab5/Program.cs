using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
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
                            Console.WriteLine("|              Task 1            |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 2           |");
                            Console.WriteLine("----------------------------------");

                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 3           |");
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
                            Console.WriteLine("|              Task 1            |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 2           |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 3           |");
                            Console.WriteLine("----------------------------------");

                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|               Exit             |");
                            Console.WriteLine("----------------------------------");
                        }
                        break;
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 1            |");
                            Console.WriteLine("----------------------------------");

                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 2           |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 3           |");
                            Console.WriteLine("----------------------------------");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|               Exit             |");
                            Console.WriteLine("----------------------------------");
                        }
                        break;
                    case 3:
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 1            |");
                            Console.WriteLine("----------------------------------");

                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 2           |");
                            Console.WriteLine("----------------------------------");

                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("|              Task 3           |");
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
                if (d.KeyChar == 'w') if (i - 1 < 0) i = 3; else i--;
                if (d.KeyChar == 's') if (i + 1 > 3) i = 0; else i++;
                if (d.Key == ConsoleKey.Enter) 
                {
                    bool anyExceptions = true;
                    switch (i)
                    {
                        case 0:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter array size:");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        Array1D array = new Array1D(n);
                                        Console.WriteLine("\nArray:\n" + array.ToString());
                                        array.solve1();
                                        Console.WriteLine("\nPress any key to return...");
                                        Console.ReadKey();
                                        anyExceptions = false;
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
                                    Console.WriteLine("Enter array dimensions:");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        Array2D array = new Array2D(n, m, true);
                                        Console.WriteLine("\nArray:\n" + array.ToString());
                                        array.solve2();
                                        Console.WriteLine("\nSolved array:\n" + array.ToString());
                                        Console.WriteLine("\nPress any key to return...");
                                        Console.ReadKey();
                                        anyExceptions = false;
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
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter array dimensions:");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        Array2D array = new Array2D(n, m, false);
                                        Console.WriteLine("\nArray:\n" + array.ToString());
                                        array.solve3();
                                        Console.WriteLine("\nPress any key to return...");
                                        Console.ReadKey();
                                        anyExceptions = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                }
                if (d.Key == ConsoleKey.Escape) Environment.Exit(0);
            }
        }
    }
}
