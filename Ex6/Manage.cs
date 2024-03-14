using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    internal class Manage : BaseClass<Student>
    {
        List<Student> students = new List<Student>();
        List<Classes> classes = new List<Classes>();
        public Manage()
        {
            _singletonInputData = SingletonInputData.GetInstance();
        }
        public void InnitData()
        {
            classes.Add(new Classes(1, "10a1"));
            classes.Add(new Classes(2, "11a1"));
            classes.Add(new Classes(3, "12a1"));
            classes.Add(new Classes(4, "12B"));
        }

        public void Menu()
        {
            while (true)
            {
                var value = _singletonInputData.InputInt(1, 4, "1 - Add more officer", "2 - Display ", "3 - Search by Adress and age = 23", "4 - exit");
                switch (value)
                {
                    case 1:
                        AddData();
                        break;
                    case 2:
                        Display(students);

                        break;
                    case 3:
                        var text = _singletonInputData.InputString("Enter the adress to search");
                        Display(students, s => s.Adress.Contains(text) && s.Age == 23);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("------------------------");
                        break;

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

                var adress = _singletonInputData.InputString("Enter the adress");
                Console.WriteLine("Choose class");
                for (int i = 0; i < classes.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {classes[i].ClassName}");
                }

                var classNumber = _singletonInputData.InputInt("Enter the class number", 1, classes.Count);
                var c = classes[classNumber - 1];

                Student s = new Student(id, name, age, adress, c.ClassId, c);
                students.Add(s);
                Console.WriteLine("=======================");
                Console.WriteLine(s);
            }
            catch
            {

            }
        }
    }
}
