using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13
{
   public class Intern:Employee
    {
        public Intern(int id, string fullName, DateTime dOB, string email, EnumEmployeeType employeeType, List<Certificate> certificates, string major, int semester, string universityName) 
            : base(id, fullName, dOB, email, employeeType, certificates)
        {
            Major = major;
            Semester = semester;
            UniversityName = universityName;
        }

        public string Major { get; set; }
        public int Semester { get; set; }
        public string UniversityName { get; set; }

        public override void ShowMe()
        {
            Console.WriteLine("In");
        }
    }
}
