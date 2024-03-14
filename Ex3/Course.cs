using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    public class Course
    {
     

        public int Id { get; set; }
        public string CourseName { get; set; }
        List<Subject> Subjects { get; set; }
        public Course(int id, string courseName, List<Subject> subjects)
        {
            Id = id;
            CourseName = courseName;
            Subjects = subjects;
        }
        public override string? ToString()
        {
            return $"{Id} - CouseName {CourseName}";
        }
    }
}
