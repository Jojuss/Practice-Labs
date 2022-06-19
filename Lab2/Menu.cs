using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Menu
    {
        int task_count;
        public Menu(int i)
        {
            this.task_count = i;
        }
        public void print(int cur_i)
        {
            for (int k = 0; k < task_count; k++)
            {
                if (k == cur_i) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("----------------------------------");
                Console.WriteLine("|              Task {0}            |", k);
                Console.WriteLine("----------------------------------");
            }
            if (cur_i == task_count) Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("----------------------------------");
            Console.WriteLine("|               Exit             |");
            Console.WriteLine("----------------------------------");
        }
    }
}
