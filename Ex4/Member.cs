using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    public class Member
    {
        public Member()
        {
        }

        public Member(int id, string fullName, int age, string job)
        {
            Id = id;
            FullName = fullName;
            Age = age;
            Job = job;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }

        public override string? ToString()
        {
            return $"Id-{Id}; FullName-{FullName}; Age-{Age}; Job-{Job}";
        }
    }
}
