using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    public class Classes
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public Classes(int classId, string className)
        {
            ClassId = classId;
            ClassName = className;
        }
    }
}
