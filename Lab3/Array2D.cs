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
        public int n;
        public Array2D(int n, int m, int min, int max)
        {
            this.array = new int[n][];
            this.n = n;
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
            int fh = 0, sh = 0;
            int c = array.Length / 2 + array.Length % 2;
            for (int i = 0; i < array[0].Length / 2; i++)
            {
                Console.WriteLine("c = " + c + " i = " + i);
                for (int j = 0; j < array.Length; j++)
                {
                    fh += array[j][i];
                    sh += array[j][c];
                }
                c++;
            }
            if (array[0].Length % 2 != 0)
            {
                for (int i = 0; i < array.Length; i++) sh += array[i][array.Length / 2];
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
            int new_len = array.Length / 2;

            for (int i = 0; i < new_len; i++)
            {
                for (int j = 0; j < array[i].Length; j++) if (array[i][j] > max)
                    {
                        max = array[i][j];
                        max_i = i;
                    }
            }

            Console.WriteLine("Max: " + max + " Sum: " + sum);

            for (int i = 0; i < new_len; i++)
            {

                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != 0 && sum % array[i][j] == 0)
                    {
                        Console.WriteLine("Found at row " + i);
                        for (int k = array.Length - 1; k > i; k--) array[k] = array[k - 1];
                        if (i < max_i) max_i++;
                        array[i + 1] = array[max_i];
                        i++;
                        new_len++;
                        break;
                    }
                }
            }

            Console.WriteLine("New len: " + new_len);
            for (int i = 0; i < new_len; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(String.Format("{0, 3} ", array[i][j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public void solve_210()
        {
            int sum = Math.Abs(array[0][0]) + Math.Abs(array[0][1]) + Math.Abs(array[array.Length - 1][array[0].Length - 1]);
            int new_len = array.Length / 2;

            Console.WriteLine("Sum: " + sum);

            for (int i = 0; i < new_len; i++)
            {

                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] != 0 && sum % array[i][j] == 0)
                    {
                        Console.WriteLine("Found at row " + i);
                        for (int k = array.Length - 1; k > i; k--) array[k] = array[k - 1];
                        for (int m = 0; m < array[i + 1].Length; m++) array[i + 1][m] = 0;
                        i++;
                        new_len++;
                        break;
                    }
                }
            }

            for (int i = 0; i < new_len; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(String.Format("{0, 3} ", array[i][j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public void solve_306()
        {
            int i = 0;
            int size = array.Length * array[1].Length;
            while (i < size)
            {
                int cur_row = i / array.Length;
                int cur_col = i % array.Length;
                int max = array[cur_row][cur_col];
                int max_i = -1;
                int max_j = -1;

                for (int j = cur_row; j < array.Length; j++)
                {
                    int k;
                    if (j == cur_row) k = cur_col;
                    else k = 0;
                    for (; k < array[j].Length; k++)
                    {
                        if (array[j][k] > max)
                        {
                            max = array[j][k];
                            max_i = j;
                            max_j = k;
                        }
                    }
                }
                if (max_i != -1)
                {
                    int temp = array[cur_row][cur_col];
                    array[cur_row][cur_col] = array[max_i][max_j];
                    array[max_i][max_j] = temp;
                }
                i++;
            }
        }

        public void solve_310()
        {
            int i = 0;
            int size = array.Length * array[1].Length;
            while (i < size)
            {
                int cur_row = i / array.Length;
                int cur_col = i % array.Length;
                int min = array[cur_row][cur_col];
                int min_i = -1;
                int min_j = -1;
                for (int j = cur_row; j < array.Length; j++)
                {
                    int k;
                    if (j == cur_row) k = cur_col;
                    else k = 0;
                    for (; k < array[j].Length; k++)
                    {
                        if (array[j][k] < min)
                        {
                            min = array[j][k];
                            min_i = j;
                            min_j = k;
                        }
                    }
                }
                if (min_i != -1)
                {
                    int temp = array[cur_row][cur_col];
                    array[cur_row][cur_col] = array[min_i][min_j];
                    array[min_i][min_j] = temp;
                }
                i++;
            }
        }

        public void print(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(string.Format("{0, 3} ", array[i][j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
