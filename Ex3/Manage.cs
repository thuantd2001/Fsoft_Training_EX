using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    internal class Manage : BaseClass<Student>
    {
        List<Student> listStudent = new List<Student>();
        List<Subject> listSubject = new List<Subject>();
        List<Course> listCourse = new List<Course>();
        public Manage()
        {
            _singletonInputData = SingletonInputData.GetInstance();
        }
        public void InnitData()
        {
            listSubject.Add(new Subject(1, "toan"));
            listSubject.Add(new Subject(2, "ly"));
            listSubject.Add(new Subject(3, "hoa"));
            listSubject.Add(new Subject(4, "sinh"));
            listSubject.Add(new Subject(5, "van"));
            listSubject.Add(new Subject(6, "su"));
            listSubject.Add(new Subject(7, "dia"));

            

            listCourse.Add(new Course(1, "A", new List<Subject>() { listSubject[0], listSubject[1], listSubject[2] }));
            listCourse.Add(new Course(2, "B", new List<Subject>() { listSubject[0], listSubject[2], listSubject[3] }));
            listCourse.Add(new Course(3, "C", new List<Subject>() { listSubject[4], listSubject[5], listSubject[6] }));


            listStudent.Add(new Student(1, "thuan", "Ha Noi", 2, 1, listCourse[0]));
            listStudent.Add(new Student(2, "thanh", "Ha Noi", 1, 3, listCourse[2]));
            listStudent.Add(new Student(3, "hung", "Ha Noi", 2, 2, listCourse[1]));
            listStudent.Add(new Student(4, "tung", "Ha Noi", 3, 2, listCourse[2]));
        }

        public void Menu()
        {
            while (true)
            {
                var value = _singletonInputData.InputInt(1, 4, "1 - Add more Student", "2 - display", "3 -  Search by Id", "4 - exit");
                switch (value)
                {
                    case 1:
                        AddData();
                        break;
                    case 2:
                        Display(listStudent);
                     
                        break;
                    case 3:
                        var text = _singletonInputData.InputInt("Enter the text id");
                        Display(listStudent, l => l.Id == text);
                        break;
                    case 4:
                        return;

                }
            }
        }
        public void AddData()
        {
            try
            {
                var id = _singletonInputData.InputInt("Enter the ID: ");
                var name = _singletonInputData.InputString("Enter the name: ");
                var age = _singletonInputData.InputInt("Enter the Age: ", 0, 99);
        
                var prioty= _singletonInputData.InputInt("Enter prioty", 1, 3);
                var adress = _singletonInputData.InputString("Enter the adress");

                DisplayGenderic<Course>(listCourse);
                Console.WriteLine("1-A, 2-B, 3-C");

                var courseId = _singletonInputData.InputInt("Enter course", 1, listCourse.Count());
                var course = listCourse.Where(c => c.Id == courseId).FirstOrDefault();
                Student s = new Student(id, name, adress, prioty,courseId, course);
                listStudent.Add(s);
                Console.WriteLine(s);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
