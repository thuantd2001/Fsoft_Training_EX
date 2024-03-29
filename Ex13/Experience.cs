﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex13.Enum;

namespace Ex13
{
    public class Experience : Employee
    {


        public int YearOfExperience { get; set; }
        public string ProSkill { get; set; }

        public Experience(int id, string fullName, DateTime dOB, string email, string phone, EnumEmployeeType employeeType,
            List<Certificate> certificates, int yearOfExperience, string proskill) : base(id, fullName, dOB, email, phone, employeeType, certificates)
        {
            YearOfExperience = yearOfExperience;
            ProSkill = proskill;
        }

        public override void ShowMe()
        {
            Console.WriteLine("ex");
        }
    }
}
