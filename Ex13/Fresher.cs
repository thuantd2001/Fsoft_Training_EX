using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13
{
    public class Fresher : Employee
    {
        public Fresher(int id, string fullName, DateTime dOB, string email, string phone, EnumEmployeeType employeeType,
            List<Certificate> certificates, DateTime graduateDate, int granduationRank) 
            : base(id, fullName, dOB, email, phone, employeeType, certificates)
        {
            GraduateDate =graduateDate;
            GraduationRank = granduationRank;
        }

        public DateTime GraduateDate { get; set; }
        public int GraduationRank { get; set; }

        public override void ShowMe()
        {
            Console.WriteLine("fr");
        }
    }
}
