﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.SetWindowSize(50, 50);
            Menu menu = new Menu(6);
            while (true)
            {
                Console.Clear();
                menu.print(i);
                ConsoleKeyInfo d = Console.ReadKey();
                if (d.KeyChar == 'w') if (i - 1 < 0) i = 6; else i--;
                if (d.KeyChar == 's') if (i + 1 > 6) i = 0; else i++;
                if (d.Key == ConsoleKey.Enter) 
                {
                    Console.Clear();
                    bool anyExceptions = true;
                    switch (i)
                    {
                        case 0:
                            {
                                while (anyExceptions)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter 2D array dimensions (rows, cols), min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array2D a2d = new Array2D(n, m, min, max);
                                        Console.WriteLine("Generated array: ");
                                        a2d.print(a2d.n);
                                        a2d.solve_106();
                                        Console.WriteLine("Solved array:");
                                        a2d.print(a2d.n);
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
                                    Console.WriteLine("Enter 2D array dimensions (rows, cols), min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array2D a2d = new Array2D(n, m, min, max);
                                        Console.WriteLine("Generated array: ");
                                        a2d.print(a2d.n);
                                        a2d.solve_110();
                                        Console.WriteLine("Solved array:");
                                        a2d.print(a2d.n);
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
                                    Console.WriteLine("Enter 2D array dimensions (rows, cols), min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array2D a2d = new Array2D(n * 2, m, min, max);
                                        Console.WriteLine("Generated array: ");
                                        a2d.print(a2d.n / 2);
                                        Console.WriteLine("Solved array:");
                                        a2d.solve_206();
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
                                    Console.WriteLine("Enter 2D array dimensions (rows, cols), min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array2D a2d = new Array2D(n * 2, m, min, max);
                                        Console.WriteLine("Generated array: ");
                                        a2d.print(a2d.n / 2);
                                        Console.WriteLine("Solved array:");
                                        a2d.solve_210();
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
                                    Console.WriteLine("Enter 2D array dimensions (rows, cols), min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array2D a2d = new Array2D(n, m, min, max);
                                        Console.WriteLine("Generated array: ");
                                        a2d.print(a2d.n);
                                        a2d.solve_306();
                                        Console.WriteLine("Solved array:");
                                        a2d.print(a2d.n);
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
                                    Console.WriteLine("Enter 2D array dimensions (rows, cols), min value, max value: ");
                                    try
                                    {
                                        int n = Convert.ToInt32(Console.ReadLine());
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        int max = Convert.ToInt32(Console.ReadLine());

                                        Array2D a2d = new Array2D(n, m, min, max);
                                        Console.WriteLine("Generated array: ");
                                        a2d.print(a2d.n);
                                        a2d.solve_310();
                                        Console.WriteLine("Solved array:");
                                        a2d.print(a2d.n);
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
                    }
                }
                if (d.Key == ConsoleKey.Escape) Environment.Exit(0);
            }
        }
    }
}
