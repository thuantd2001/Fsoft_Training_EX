using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13
{
    public abstract class Employee
    {
        public static int EmployeeCount;

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public EnumEmployeeType EmployeeType { get; set; }
        public List<Certificate> Certificates { get; set; }
        

        public abstract void ShowMe();
        public Employee()
        {
        }

        protected Employee(int id, string fullName, DateTime dOB, string email, EnumEmployeeType employeeType, List<Certificate> certificates)
        {
            Id = id;
            FullName = fullName;
            DOB = dOB;
            Email = email;
            EmployeeType = employeeType;
            Certificates = certificates;
        }
    }
}
