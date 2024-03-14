using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15.Entity
{
    internal class InServiceStudent : Student
    {
       

        public string JointPlace { get;set; }

        public InServiceStudent()
        {
        }

        public InServiceStudent(string id, string fullName, DateTime dOB, int yearOfAdmission, double entryPoint, int departmentId,string jointPlace) 
            : base(id, fullName, dOB, yearOfAdmission, entryPoint, departmentId)
        {
            JointPlace = jointPlace;
        }

     
        public override string ToString()
        {
            return $"id-{Id}; Name-{FullName}\nDob-{DOB.ToString()}; Year Of Admission-{YearOfAdmission}; Entry Point-{EntryPoint}; JointPlace-{JointPlace}";
        }
    }
}
