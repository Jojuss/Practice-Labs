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

        public Array1D(int n, int min, int max)
        {
            this.array = new int[n];
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

        public int[] solve_task3()
        {
            bool mnt = true;                    // true = growing, false = declining
            int i = 0;
            int first_start = -1;
            int first_end = -1;
            int last_start = -1;
            int last_end = -1;
            bool[] nono_zone = new bool[array.Length];
            nono_zone = Enumerable.Repeat(false, nono_zone.Length).ToArray();

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

            List<int> paint = new List<int>();

            Console.WriteLine("Mnt count: " + (ext_count + 1));
            int[] temp = new int[array.Length];
            temp = Enumerable.Repeat(Int32.MinValue, temp.Length).ToArray();
            if (first_start != -1 && first_end != -1 && last_start != -1 && last_end != -1 && first_start != last_start && first_end != last_end)
            {
                int i1 = 0;
                for (i = first_start; i <= (last_end - last_start + first_start); i++)
                {
                    temp[i] = array[last_start + i1];
                    array[last_start + i1] = Int32.MinValue;
                    i1++;
                    paint.Add(i);
                }

                i1 = 0;
                for (i = last_end; i1 < (first_end - first_start + 1); i--)
                {
                    temp[i] = array[first_end - i1];
                    array[first_end - i1] = Int32.MinValue;
                    i1++;
                    paint.Add(i);
                }

                i1 = 0;
                while (temp[i1] != Int32.MinValue) i1++;
                for (i = 0; i < array.Length; i++)
                {
                    if (array[i] != Int32.MinValue)
                    {
                        temp[i1] = array[i];
                        i1++;
                    }
                }
            }
            else temp = array;
            array = temp;
            return paint.ToArray();
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

        public int[] solve_task5()
        {
            double average = 0;
            int sum = 0;
            for (int i = 0; i < array.Length; i++) sum += array[i];
            average = (double)sum / (double)array.Length;
            Console.WriteLine("Average: " + average);

            int new_length = array.Length;
            HashSet<int> indices = new HashSet<int>();
            for (int i = 0; i < array.Length; i++) if (Math.Abs(array[i]) > average)
                {
                    new_length++;
                    indices.Add(i);
                }

            int offset = 0;
            int[] temp = new int[new_length];
            foreach (var item in indices)
            {
                temp[item + offset + 1] = -1;
                offset++;
            }

            int true_j = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 0)
                {
                    temp[i] = array[true_j];
                    true_j++;
                }
                else temp[i] = 0;
            }

            array = temp;
            return array;
        }

        public int[] solve_task6()
        {
            int maxpos = 0;
            for (int i = 0; i < array.Length; i++) if (array[i] > maxpos) maxpos = array[i];
            Console.WriteLine("Max positive: " + maxpos);

            int new_length = array.Length;
            HashSet<int> indices = new HashSet<int>();
            for (int i = 0; i < array.Length; i++) if (array[i] % 2 == -1)
                {
                    new_length++;
                    indices.Add(i);
                }

            int offset = 0;
            int[] temp = new int[new_length];
            foreach (var item in indices)
            {
                temp[item + offset + 1] = -1;
                offset++;
            }

            int true_j = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 0)
                {
                    temp[i] = array[true_j];
                    true_j++;
                }
                else temp[i] = maxpos;
            }

            array = temp;
            return array;
        }

        public int[] solve_task7()
        {
            int new_length = array.Length;
            HashSet<int> indices = new HashSet<int>();
            for (int i = 0; i < array.Length - 1; i++)
                if (array[i] % array[array.Length - 1] != 0)
                {
                    indices.Add(i);
                    new_length--;
                }

            int[] temp = new int[new_length];
            int temp_i = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!indices.Contains(i))
                {
                    temp[temp_i] = array[i];
                    temp_i++;
                }
            }
            
            array = temp;
            return array;
        }

        public int[] solve_task8()
        {
            int new_length = array.Length;
            int sum = Math.Abs(array[0]) + Math.Abs(array[array.Length - 1]);
            HashSet<int> indices = new HashSet<int>();
            for (int i = 0; i < array.Length - 1; i++)
                if ((array[i] != 0 && sum % array[i] == 0) || array[i] == 0)
                {
                    indices.Add(i);
                    new_length--;
                }

            int[] temp = new int[new_length];
            int temp_i = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!indices.Contains(i))
                {
                    temp[temp_i] = array[i];
                    temp_i++;
                }
            }

            array = temp;
            return array;
        }

        public void print(int[] els = null)
        {
            els = els ?? new int[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (els.Contains(i)) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(String.Format("{0, -3 }", array[i]));
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
