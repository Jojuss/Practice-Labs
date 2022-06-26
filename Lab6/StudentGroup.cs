using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class StudentGroup
    {
        public List<Student> students = new List<Student>();

        public List<Student> StreamSort(int filter)
        {
            switch(filter)
            {
                case 1:
                    return students.OrderBy(student => student.age).ToList();
                case 2:
                    return students.OrderBy(student => student.name).ToList();
                case 3:
                    return students.OrderBy(student => student.median).ToList();
                default:
                    return students;
            }
        }

        public List<Student> StreamFilter(int filter, string text)
        {
            switch (filter)
            {
                case 1:
                    return students.Where(student => student.name.StartsWith(text)).ToList();
                case 2:
                    return students.Where(student => student.age > Convert.ToInt32(text)).ToList();
                case 3:
                    return students.Where(student => student.median > Convert.ToDouble(text)).ToList();
                default:
                    return students;
            }
        }
    }
}
