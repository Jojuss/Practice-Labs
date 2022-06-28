using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Array2D : Array1D
    {
        int[][] array;
        public Array2D(int n, int m, bool evenRows) : base (n)
        {
            this.array = new int[n][];
            Random rand = new Random();
            if (evenRows)
            {
                for (int i = 0; i < n; i++) array[i] = new int[m];
            }
            else
            {
                for (int i = 0; i < n; i++) array[i] = new int[rand.Next(1, m + 1)];
            }

            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < array[i].Length; j++) array[i][j] = rand.Next(-10, 11);
            }
        }

        public void solve2()
        {
            int first_neg_i = -1;
            int last_pos_i = -1;

            int i = 0;
            while (first_neg_i == -1 && i < array[a.Length - 1].Length)
            {
                if (array[a.Length - 1][i] < 0) first_neg_i = i;
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
            for (i = 0; i < a.Length; i++)
            {
                int temp = array[i][first_neg_i];
                array[i][first_neg_i] = array[i][last_pos_i];
                array[i][last_pos_i] = temp;
            }
        }

        public void solve3()
        {
            int max_len_i = 0;
            int max_even = int.MinValue;
            for (int i = 0; i < a.Length; i++) if (array[i].Length > array[max_len_i].Length) max_len_i = i;

            a = array[max_len_i];
            solve1();

            if (max_even == int.MinValue) Console.WriteLine("No even numbers found in row {0}.", max_len_i);
            else Console.WriteLine("Max even in row {0}: {1}", max_len_i, max_even);
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++) s += String.Format("{0, 4}", array[i][j]);
                s += "\n";
            }
            return s;
        }
    }
}
