using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Array1D
    {
        protected int[] array;
        public int n;

        public Array1D(int n, int min, int max)
        {
            this.array = new int[n];
            this.n = n;
            Random rand = new Random();
            for (int i = 0; i < n; i++) this.array[i] = rand.Next(min, max + 1);
        }

        public int[] solve_task1()
        {
            int max_case1 = 1;
            int max_case2 = 1;

            int[] max_nums_1 = new int[3];
            int[] max_nums_2 = new int[3];
            bool[] flags = Enumerable.Repeat(false, array.Length).ToArray();
            bool flag = false;
            int max_j = -1;
            
            int cur;
            bool has_zero = false;

            //Solve for case 1 (3 positives, should work with 3 negatives)
            for (int i = 0; i < 3; i++)
            {
                flag = false;
                cur = Int32.MinValue;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] >= cur && !flags[j])
                    {
                        cur = array[j];
                        max_j = j;
                        flag = true;
                    }
                }
                flags[max_j] = true;
                if (flag)
                {
                    max_nums_1[i] = cur;
                    max_case1 *= cur;
                }
            }

            //Solve for case 2 (2 negatives 1 positive)
            flags = Enumerable.Repeat(false, array.Length).ToArray();
            for (int i = 0; i < 2; i++)
            {
                flag = false;
                cur = -1;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] <= cur && !flags[j])
                    {
                        cur = array[j];
                        max_j = j;
                        flag = true;
                    }
                }
                flags[max_j] = true;
                if (flag)
                {
                    max_case2 *= cur;
                    max_nums_2[i] = cur;
                }
            }
            cur = 0;
            max_j = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] == 0) has_zero = true;
                if (array[j] > cur && !max_nums_2.Contains(array[j]))
                {
                    cur = array[j];
                }
            }
            max_nums_2[2] = cur;
            max_case2 *= cur;

            if (has_zero)
            {
                if (max_case1 > max_case2) return max_nums_1;
                else return max_nums_2;
            }
            else if (max_case1 == 0 || max_case1 > max_case2) return max_nums_1;
            else return max_nums_2;
        }

        public int solve_task2()
        {
            int i = 0;
            while (i < 11)
            {
                if (array[i] > array[1] && array[i] < array[10]) return i;
                i++;
            }
            return 0;
        }

        public void solve_task3()
        {
            bool mnt = true;                    // true = growing, false = declining
            int i = 0;
            int first_start = -1;
            int first_end = -1;
            int last_start = -1;
            int last_end = -1;

            try
            {
                //Finding the 1st mnt zone
                while (array[i] == array[i + 1] && i < array.Length - 1) i++;
                if (i < array.Length - 1 && array[i] > array[i + 1]) mnt = false;
                first_start = i;
                if (mnt) while (i < array.Length - 1 && array[i] < array[i + 1]) i++;
                else while (i < array.Length - 1 && array[i] > array[i + 1]) i++;
                first_end = i;

                //Finding the 2nd mnt zone
                i = array.Length - 1;
                while (array[i] == array[i - 1] && i > 0) i--;
                if (i > 0 && array[i] > array[i - 1]) mnt = true;
                else mnt = false;
                last_end = i;
                if (mnt) while (i > 0 && array[i] > array[i - 1]) i--;
                else while (i > 0 && array[i] < array[i - 1]) i--;
                last_start = i;
            }
            catch (Exception ex) {}

            List<int> firstext = new List<int>();
            List<int> lastext = new List<int>();
            for (i = first_start; i <= first_end; i++)
            {
                firstext.Add(array[i]);
                array[i] = Int32.MinValue;
            }
            for (i = last_start; i <= last_end; i++)
            {
                lastext.Add(array[i]);
                array[i] = Int32.MinValue;
            }

            int ext_count = 0; 
            i = 0;
            while (i < array.Length - 1 && array[i] == array[i + 1]) i++;
            if (i != array.Length - 1)
            {
                if (array[i] > array[i + 1]) mnt = false;
                else mnt = true;

                for (i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] == array[i + 1]) continue;
                    if (array[i] > array[i + 1] && mnt)
                    {
                        ext_count++;
                        mnt = !mnt;
                    }
                    if (array[i] < array[i + 1] && !mnt)
                    {
                        ext_count++;
                        mnt = !mnt;
                    }
                }
            }
            else ext_count = -1;
            Console.Write("Mnt count: " + (ext_count + 1));

            int offset = (last_end - last_start + 1) - (first_end - first_start + 1);
            if (offset != 0 && first_start != -1 && first_end != -1 && last_start != -1 && last_end != -1)
            {
                if (offset > 0)
                {
                    i = array.Length - 1;
                    while (array[i] != Int32.MinValue) i--;
                    while (array[i] == Int32.MinValue) i--;
                    while (array[i] != Int32.MinValue)
                    {
                        array[i + 1] = array[i];
                        array[i] = Int32.MinValue;
                        i--;
                    }
                }
                if (offset < 0)
                {
                    i = 0;
                    while (array[i] != Int32.MinValue) i++;
                    while (array[i] == Int32.MinValue) i++;
                    while (array[i] != Int32.MinValue)
                    {
                        array[i - 1] = array[i];
                        array[i] = Int32.MinValue;
                        i++;
                    }
                }
                i = 0;
                while (array[i] != Int32.MinValue) i++;
                for (int j = 0; j < lastext.Count; j++)
                {
                    array[i] = lastext[j];
                    i++;
                }
                i = array.Length - 1;
                while (array[i] != Int32.MinValue) i--;
                for (int j = 0; j < firstext.Count; j++)
                {
                    array[i] = firstext[firstext.Count - j - 1];
                    i--;
                }
            }
            else
            {
                for (i = 0; i < firstext.Count; i++)
                {
                    array[first_start] = lastext[i];
                    array[last_start] = firstext[i];
                    first_start++;
                    last_start++;
                }
            }
        }

        public void solve_task4()
        {
            int sum = 0;
            int i = 0;
            bool flag_perfect = false;
            for (i = 0; i < array.Length; i++)
            {
                sum = 0;
                for (int j = 1; j < Math.Truncate(Math.Sqrt(array[i])) + 1; j++)
                {
                    if (array[i] % j == 0) sum += j + (array[i] / j);
                }
                if (array[i] == (sum - array[i]) && Math.Abs(array[i]) >= 6)
                {
                    flag_perfect = true;
                    break;
                }
            }

            int count = 0;
            int k = 0;
            bool flag_prime = false;
            for (k = 0; k < array.Length; k++)
            {
                count = 0;
                for (int j = 1; j < Math.Truncate(Math.Sqrt(array[k])) + 1; j++)
                {
                    if ((array[k] % j) == 0) count++;
                }
                if (count == 1)
                {
                    flag_prime = true;
                    break;
                }
            }

            if (flag_perfect) Console.WriteLine("\nPerfect number index: " + i);
            else Console.WriteLine("\nNo perfect number found.");
            if (flag_prime) Console.WriteLine("Prime number index: " + k + '\n');
            else Console.WriteLine("No prime number found." + '\n');
            if (flag_perfect && flag_prime)
            {
                int temp = array[i];
                array[i] = array[k];
                array[k] = temp;
            }
        }

        public void solve_task5()
        {
            double average = -1;
            int sum = 0;
            int count = 0;
            int new_len = array.Length / 2;
            for (int i = 0; i < new_len; i++) 
            {
                if (array[i] > 0)
                {
                    sum += array[i];
                    count++;
                }
            }

            if (count != 0) average = (double)sum / (double)count;

            for (int i = 0; i < new_len; i++)
            {
                if (Math.Abs(array[i]) > average)
                {
                    for (int j = array.Length - 1; j > i; j--)
                    {
                        array[j] = array[j - 1];
                    }
                    array[i + 1] = 0;
                    i++;
                    new_len++;
                }
            }
            Console.WriteLine("Average: " + average);
            for (int i = 0; i < new_len; i++) Console.Write("" + array[i] + " ");
        }

        public void solve_task6()
        {
            int new_len = array.Length / 2;
            int maxpos = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxpos) maxpos = array[i];
            }
            Console.WriteLine("Max positive: " + maxpos);
            if (maxpos == -1)
            {
                Console.WriteLine("No positive numbers found.");
                return;
            }

            for (int i = 0; i < new_len; i++)
            {
                if (array[i] % 2 == -1)
                {
                    for (int j = array.Length - 1; j > i; j--)
                    {
                        array[j] = array[j - 1];
                    }
                    array[i + 1] = maxpos;
                    i++;
                    new_len++;
                }
            }
            for (int i = 0; i < new_len; i++) Console.Write("" + array[i] + " ");
        }

        public void solve_task7()
        {
            if (array[array.Length - 1] == 0)
            {
                Console.WriteLine("Last element is 0.");
                return;
            }

            int last = array[array.Length - 1];
            int new_len = array.Length;

            int k = array.Length - 2;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % last != 0)
                {
                    for (int j = i; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    new_len--;
                    i--;
                }
            }

            for (int i = 0; i < new_len; i++)
            {
                Console.Write("" + array[i] + " ");
            }
        }

        public void solve_task8()
        {
            if (array[0] + array[array.Length - 1] == 0)
            {
                Console.WriteLine("Sum is 0.");
                Console.Write(String.Join(" ", array));
                return;
            }

            int sum = array[0] + array[array.Length - 1];
            int new_len = array.Length;

            int k = array.Length - 2;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0 && sum % array[i] == 0)
                {
                    for (int j = i; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    new_len--;
                    i--;
                }
            }

            for (int i = 0; i < new_len; i++)
            {
                Console.Write("" + array[i] + " ");
            }
        }

        public void print(int len)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write(String.Format("{0, -4}", array[i]));
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
