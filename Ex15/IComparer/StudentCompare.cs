using Ex15.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15.IComparer
{
    internal class StudentCompare : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
           if( x.GetType() == y.GetType())
            {
                return y.YearOfAdmission.CompareTo(x.YearOfAdmission);
            }
            if(x.GetType() == typeof(Student) && y.GetType() == typeof(StudentInService))
            {
                return -1;
            }
            if (x.GetType() == typeof(StudentInService) && y.GetType() == typeof(Student))
            {
                return 1;
            }
            return -1;
        }
    }
}
