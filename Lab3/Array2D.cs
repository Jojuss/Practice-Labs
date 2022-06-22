using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Array2D
    {
        protected int[][] array;
        
        public Array2D(int n, int m, int min, int max)
        {
            this.array = new int[n][];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                this.array[i] = new int[m];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rand.Next(min, max + 1);
                }
            }
        }

        public void solve_106()
        {
            int first_neg_i = -1;
            int last_pos_i = -1;

            int i = 0;
            while (first_neg_i == -1 && i < array[array.Length - 1].Length)
            {
                if (array[array.Length - 1][i] < 0) first_neg_i = i;
                i++;
            }
            i = array[0].Length - 1;
            while (last_pos_i == -1 && i >= 0)
            {
                if (array[0][i] > 0) last_pos_i = i;
                i--;
            }

            if (first_neg_i == -1 || last_pos_i == -1)
            {
                Console.WriteLine("Could not find one of the two numbers.");
                return;
            }

            i = 0;
            for (i = 0; i < array.Length; i++)
            {
                int temp = array[i][first_neg_i];
                array[i][first_neg_i] = array[i][last_pos_i];
                array[i][last_pos_i] = temp;
            }
        }

        public void solve_110()
        {
            int fh = 0, sh = 0, boundary = array.Length / 2 + array.Length % 2;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (i < boundary) fh += array[i][j];
                    else sh += array[i][j];
                }
            }

            Console.WriteLine("First half: " + fh);
            Console.WriteLine("Second half: " + sh);

            if (fh > sh)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i][0] = 0;
                }
            }
            else
            {
                for (int i = 0; i < array[0].Length; i++)
                {
                    array[0][i] = 0;
                }
            }
        }

        public void solve_206()
        {
            int sum = Math.Abs(array[0][0]) + Math.Abs(array[array.Length - 1][array[0].Length - 1]);

            int max = Int32.MinValue;
            int max_i = -1;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++) if (array[i][j] > max)
                    {
                        max = array[i][j];
                        max_i = i;
                    }
            }

            Console.WriteLine("Max: " + max + " Sum: " + sum);
            int[][] array2 = new int[array.Length * 2][];
            int new_row_length = array.Length;
            for (int i = 0; i < array2.Length; i++) array2[i] = new int[array[0].Length];

            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int j = 0;
                while (j < array[i].Length) 
                {
                    if (array[i][j] == 0)
                    {
                        j++;
                        continue;
                    }
                    if (sum % array[i][j] == 0) break;
                    j++;
                }
                if (j < array.Length)
                {
                    array2[k] = array[i];
                    array2[k + 1] = array[max_i];
                    k++;
                    new_row_length++;
                }
                else array2[k] = array[i];
                k++;
            }


            for (int i = 0; i < new_row_length; i++)
            {
                for (int j = 0; j < array2[i].Length; j++)
                {
                    Console.Write(String.Format("{0, 3} ", array2[i][j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public void solve_210()
        {
            int sum = Math.Abs(array[0][0]) + Math.Abs(array[0][1]) + Math.Abs(array[array.Length - 1][array[0].Length - 1]);

            Console.WriteLine("Sum: " + sum);
            int[][] array2 = new int[array.Length * 2][];
            int new_row_length = array.Length;
            for (int i = 0; i < array2.Length; i++) array2[i] = new int[array[0].Length];

            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int j = 0;
                while (j < array[i].Length)
                {
                    if (array[i][j] == 0)
                    {
                        j++;
                        continue;
                    }
                    if (sum % array[i][j] == 0) break;
                    j++;
                }
                if (j < array.Length)
                {
                    array2[k] = array[i];
                    for (int m = 0; m < array2[k + 1].Length; m++) array2[k + 1][m] = 0;
                    k++;
                    new_row_length++;
                }
                else array2[k] = array[i];
                k++;
            }

            for (int i = 0; i < new_row_length; i++)
            {
                for (int j = 0; j < array2[i].Length; j++)
                {
                    Console.Write(String.Format("{0, 3} ", array2[i][j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public void solve_306()
        {
            int[] array1d = new int[array.Length * array[0].Length];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[0].Length; j++)
                {
                    array1d[k] = array[i][j];
                    k++;
                }
            }

            //Bubble sorting
            int temp = 0;
            for (int write = 0; write < array1d.Length; write++)
            {
                for (int sort = 0; sort < array1d.Length - 1; sort++)
                {
                    if (array1d[sort] > array1d[sort + 1])
                    {
                        temp = array1d[sort + 1];
                        array1d[sort + 1] = array1d[sort];
                        array1d[sort] = temp;
                    }
                }
            }

            k = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = array[0].Length - 1; j >= 0; j--)
                {
                    array[i][j] = array1d[k];
                    k++;
                }
            }
        }

        public void solve_310()
        {
            int[] array1d = new int[array.Length * array[0].Length];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[0].Length; j++)
                {
                    array1d[k] = array[i][j];
                    k++;
                }
            }

            //Bubble sorting
            int temp = 0;
            for (int write = 0; write < array1d.Length; write++)
            {
                for (int sort = 0; sort < array1d.Length - 1; sort++)
                {
                    if (array1d[sort] > array1d[sort + 1])
                    {
                        temp = array1d[sort + 1];
                        array1d[sort + 1] = array1d[sort];
                        array1d[sort] = temp;
                    }
                }
            }

            k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[0].Length; j++)
                {
                    array[i][j] = array1d[k];
                    k++;
                }
            }
        }

        public void print(int[] rows = null, int[] cols = null)
        {
            rows = rows ?? new int[0];
            cols = cols ?? new int[0];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (rows.Contains(i) || cols.Contains(j)) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(string.Format("{0, 3} ", array[i][j]));
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
