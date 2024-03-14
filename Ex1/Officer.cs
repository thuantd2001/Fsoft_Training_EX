using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Officer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public EnumGender Gender { get; set; }
        public string Adress {  get; set; }

        public Officer()
        {
        }

        public Officer(int id, string name, int age, EnumGender gender, string adress)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Adress = adress;
        }

        public override string? ToString()
        {

            return $"Id-{Id}; Name-{Name}; Age-{Age}; Gender-{Gender.ToString()}; Adress-{Adress}" ;
        }
    }
}
