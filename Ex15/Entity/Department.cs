using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ex15.Entity
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string? ToString()
        {
            return $"DepartmentId-{Id}; DepartmentName-{Name}";
        }
    }
}
