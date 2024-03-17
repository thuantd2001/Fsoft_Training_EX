using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15.Entity
{
    internal class StudentInService : Student
    {
       

        public string JointPlace { get;set; }

        public StudentInService()
        {
        }

        public StudentInService(int id, string fullName, DateTime dOB, int yearOfAdmission, double entryPoint, int departmentId,string jointPlace) 
            : base(id, fullName, dOB, yearOfAdmission, entryPoint, departmentId)
        {
            JointPlace = jointPlace;
        }

        public StudentInService(Student s, string jointPlace)
        {
            Id = s.Id;
            FullName = s.FullName;
            DOB = s.DOB;
            YearOfAdmission = s.YearOfAdmission;
            EntryPoint = s.EntryPoint;
            DepartmentId = s.DepartmentId;
            JointPlace = jointPlace;

        }
     
        public override string ToString()
        {
            return $"id-{Id}; Name-{FullName}\nDob-{DOB.ToString()}; Year Of Admission-{YearOfAdmission}; Entry Point-{EntryPoint}; JointPlace-{JointPlace}";
        }
    }
}
