using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15.Entity
{
    internal class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public int YearOfAdmission { get; set; }
        public double EntryPoint { get; set; }
        public int DepartmentId { get; set; }

        public Student()
        {
        }

        public Student(int id, string fullName, DateTime dOB, int yearOfAdmission, double entryPoint, int departmentId)
        {
            Id = id;
            FullName = fullName;
            DOB = dOB;
            YearOfAdmission = yearOfAdmission;
            EntryPoint = entryPoint;
            DepartmentId = departmentId;
        }

        public override string ToString()
        {
            return $"id-{Id}; Name-{FullName}\nDob-{DOB.ToString()}; Year Of Admission-{YearOfAdmission}; Entry Point-{EntryPoint};";
        }
    }
}
