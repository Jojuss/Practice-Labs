using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Array1D
    {
        protected int[] a;
        public Array1D(int n)
        {
            this.a = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++) a[i] = rand.Next(-10, 11);
        }

        public void solve1()
        {
            int max_even = int.MinValue;
            for (int i = 0; i < a.Length; i++) if (a[i] % 2 == 0 && a[i] > max_even) max_even = a[i];
            if (max_even != int.MinValue) Console.WriteLine("Max even: " + max_even);
            else Console.WriteLine("No even numbers found.");
        }

        public override string ToString()
        {
            return String.Join(" ", a);
        }
    }
}
