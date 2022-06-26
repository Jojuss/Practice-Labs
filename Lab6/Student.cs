using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Student
    {
        public int age;
        public string name;
        public double median;

        public Student(int age, string name, double median)
        {
            this.age = age;
            this.name = name;
            this.median = median;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1} y.o., median: {2}", name, age, median);
        }
    }
}
