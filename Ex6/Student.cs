using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    public class Student
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Adress { get;set; }
        public int ClassId { get; set; }
        public Classes Classes { get; set; }
        public Student(int id, string name, int age, string adress, int classId, Classes classes)
        {
            Id = id;
            Name = name;
            Age = age;
            Adress = adress;
            ClassId = classId;
            Classes = classes;
        }
        public override string? ToString()
        {
            return $"Id-{Id}; Name-{Name}; Age-{Age}; Adress-{Adress}; Class-{Classes.ClassName}";
        }
    }
}
