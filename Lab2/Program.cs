using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.SetWindowSize(60, 60);
            Menu menu = new Menu(8);
            while (true)
            {
                Console.Clear();
                menu.print(i);
                ConsoleKeyInfo d = Console.ReadKey();
                if (d.KeyChar == 'w') if (i - 1 < 0) i = 8; else i--;
                if (d.KeyChar == 's') if (i + 1 > 8) i = 0; else i++;
                if (d.Key == ConsoleKey.Enter) 
                {
                    Console.Clear();
                    bool anyExceptions = true;
                    switch(i)
                    {
                        case 0:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter array size, min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array1D a1d = new Array1D(n, min, max);
                                        Console.WriteLine("\nAnswer: " + String.Join(" ", a1d.solve_task1()) + "\n\nFrom generated array:");
                                        a1d.print();
                                        anyExceptions = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                    }
                                    Console.WriteLine("\nPress any key to return to menu...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 1:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter min value, max value of array elements: ");
                                    try
                                    {
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array1D a1d = new Array1D(11, min, max);
                                        Console.WriteLine("\nAnswer: " + Convert.ToString(a1d.solve_task2()) + "\n\nFrom generated array: ");
                                        a1d.print();
                                        anyExceptions = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                    }
                                    Console.WriteLine("\nPress any key to return to menu...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 2:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter array size, min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array1D a1d = new Array1D(n, min, max);
                                        a1d.solve_task3();
                                        a1d.print();
                                        anyExceptions = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                    }
                                    Console.WriteLine("\nPress any key to return to menu...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 3:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter array size, min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array1D a1d = new Array1D(n, min, max);
                                        Console.WriteLine("Generated array: ");
                                        a1d.print();
                                        a1d.solve_task4();
                                        Console.WriteLine("Changed array: ");
                                        a1d.print();
                                        anyExceptions = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                    }
                                    Console.WriteLine("\nPress any key to return to menu...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 4:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter array size, min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array1D a1d = new Array1D(n, min, max);
                                        Console.WriteLine("\nGenerated array: ");
                                        a1d.print();
                                        a1d.solve_task5();
                                        Console.WriteLine("\nChanged array: ");
                                        a1d.print();
                                        anyExceptions = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                    }
                                    Console.WriteLine("\nPress any key to return to menu...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 5:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter array size, min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array1D a1d = new Array1D(n, min, max);
                                        Console.WriteLine("\nGenerated array: ");
                                        a1d.print();
                                        a1d.solve_task6();
                                        Console.WriteLine("\nChanged array: ");
                                        a1d.print();
                                        anyExceptions = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                    }
                                    Console.WriteLine("\nPress any key to return to menu...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 6:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter array size, min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array1D a1d = new Array1D(n, min, max);
                                        Console.WriteLine("\nGenerated array: ");
                                        a1d.print();
                                        a1d.solve_task7();
                                        Console.WriteLine("\nChanged array: ");
                                        a1d.print();
                                        anyExceptions = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                    }
                                    Console.WriteLine("\nPress any key to return to menu...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 7:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter array size, min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array1D a1d = new Array1D(n, min, max);
                                        Console.WriteLine("\nGenerated array: ");
                                        a1d.print();
                                        a1d.solve_task8();
                                        Console.WriteLine("\nChanged array: ");
                                        a1d.print();
                                        anyExceptions = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message + "\nPress any key to retry...");
                                    }
                                    Console.WriteLine("\nPress any key to return to menu...");
                                    Console.ReadKey();
                                }
                            }
                            break;

                        case 8:
                            Environment.Exit(0);
                            break;
                    }
                }

                if (d.Key == ConsoleKey.Escape) Environment.Exit(0);
            }
        }
    }
}
