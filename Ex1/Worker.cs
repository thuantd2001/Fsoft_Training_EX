using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Worker : Officer
    {
        public Worker(int id, string name, int age, EnumGender gender, string adress) : base(id, name, age, gender, adress)
        {
        }

        public int Level { get; set; }

    }
}
