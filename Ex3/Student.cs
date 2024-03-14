using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    public class Student
    {
      

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Priority { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Student(int id, string name, string address, int priority, int courseId, Course course)
        {
            Id = id;
            Name = name;
            Address = address;
            Priority = priority;
            CourseId = courseId;
            Course = course;
        }

        public override string ToString()
        {
            return $"Id-{Id}; Name-{Name}; Address-{Address}; Priority-{Priority}; Course-{Course.CourseName}";
        }
    }
}
