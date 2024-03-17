using Ex15.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using ClassLibrary;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using Ex15.IComparer;
using System.ComponentModel.DataAnnotations;


namespace Ex15.Service
{
    internal class ManageService : BaseClass<Student>
    {
        public ManageService()
        {
            _singletonInputData = SingletonInputData.GetInstance();
        }
        public List<Department> departments = new List<Department>();
        public List<Student> students = new List<Student>() { };
        //public List<StudentInService> inServiceStudents = new List<StudentInService>();
        public List<Result> learningOutCome = new List<Result>();

        public void InnitData()
        {
            // department
            departments.Add(new Department(1, "Math"));
            departments.Add(new Department(2, "History"));
            departments.Add(new Department(3, "Technology"));

            // student
            students.Add(new Student(1, "Hai", DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 9.5, 1));
            students.Add(new Student(2, "Thuan", DateTime.ParseExact("01-30-2001", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2011, 7, 1));
            students.Add(new Student(3, "Linh", DateTime.ParseExact("02-06-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2018, 7.5, 1));

            // student in service
            students.Add(new StudentInService(6, "Khoa", DateTime.ParseExact("08-07-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 9.5, 3, "FPT funic"));
            students.Add(new StudentInService(7, "Hoang", DateTime.ParseExact("12-16-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 9.5, 3, "VTI academic"));
            students.Add(new StudentInService(8, "Hoang", DateTime.ParseExact("02-07-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 9.5, 2, "Vin"));

            // student
            students.Add(new Student(4, "Hoang", DateTime.ParseExact("06-06-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2016, 8, 2));
            students.Add(new Student(5, "Van", DateTime.ParseExact("08-08-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 6, 3));
            // learning outcome
            learningOutCome.Add(new Result(1, 1, 5, students[0].Id));
            learningOutCome.Add(new Result(2, 9, 8, students[0].Id));
            learningOutCome.Add(new Result(3, 1, 10, students[1].Id));
            learningOutCome.Add(new Result(4, 8, 5, students[2].Id));
            learningOutCome.Add(new Result(5, 1, 4, students[2].Id));
            learningOutCome.Add(new Result(6, 1, 8, students[3].Id));
            learningOutCome.Add(new Result(7, 1, 5, students[0].Id));
            learningOutCome.Add(new Result(8, 1, 7, students[1].Id));
            learningOutCome.Add(new Result(9, 1, 6, students[4].Id));
            learningOutCome.Add(new Result(10, 1, 1, students[2].Id));

            learningOutCome.Add(new Result(11, 1, 1, students[5].Id));
            learningOutCome.Add(new Result(12, 3, 3, students[6].Id));
            learningOutCome.Add(new Result(13, 3, 1, students[7].Id));

        }

        public void Menu()
        {
            while (true)
            {
                var value = _singletonInputData.InputInt(1, 11, "1 - Display all", "2 - Add more Student ", "3 - Display student in department",
                    "4 - NumberOfStudent in Department", "5 - list result of student in semester", "6 - highest entry point in department",
                    "7 - list student inservice search by joinplace ", "8 - get result of student in current semester by department (score > 8.0)",
                    "9 - Get highest result of student in department", "10 - Sort student", "11 - Get sdudent by year admiss");
                switch (value)
                {
                    case 1:
                        DisplayListStudent(students);

                        break;
                    case 2:
                        AddData();

                        break;
                    case 3:

                        GetStudentInDepartment();
                        break;
                    case 4:
                        CountStudentInDepartment();
                        break;
                    case 5:
                        GetResultBySemester();
                        break;
                    case 6:
                        HighestEntryPointInDepartment();
                        break;
                    case 7:
                        FindStudentInServiceInDepartment();
                        break;
                    case 8:
                        GetCurrentResult();
                        break;
                    case 9:
                        FindHighestScoreIndepartnet();
                        break;
                    case 10:
                        SortByCompare();
                        break;
                    case 11:
                        GetNumberOfStudentByYear();
                        break;
                    case 12:
                        return;
                    default:
                        Console.WriteLine("------------------------");
                        break;

                }
            }
        }
        public int InputId()
        {
            while (true)
            {
                try
                {
                    var id = _singletonInputData.InputInt("Enter the Id", 0);
                    if (students.Any(e => e.Id == id))
                    {
                        throw new Exception("Id has been exsist ");
                    }
                    return id;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        public bool IsSemestterExist(List<Result> list, int semester)
        {
            var result = list.FirstOrDefault(l => l.Semester == semester);
            if (result != null) return true;
            return false;
        }

        public int InputSemester(List<Result> list, string mess)
        {

            Console.WriteLine(mess);
            while (true)
            {
                try
                {


                    int semester = _singletonInputData.InputInt("\t-enter the semester(int): ", 1, 20);
                    var s = IsSemestterExist(list, semester);
                    if (s)
                    {
                        throw new Exception("Semester has been exist");
                    }
                    return semester;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine($"Please {mess} again !! ");
                }
            }
        }


        //3
        public void AddData()
        {

            int id = InputId();
            int type = _singletonInputData.InputInt("1- student ; 2 - Inservice student", 1, 2);
            string fullName = _singletonInputData.InputString("Enter the fullname");


            DateTime dob = _singletonInputData.InputDateTime("Enter dob(MM-dd-yyyy): ");

            int yearOfAdmission = _singletonInputData.InputInt("Enter year of admission ", 0, 2999);

            double entryPoint = _singletonInputData.InputDouble("Enter entry point (double)", 0, 10);

            int number = _singletonInputData.InputInt("Input the number of result: ", 0, 10);

            var results = new List<Result>();

            //learning outcome
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{i + 1} --");
                double score = _singletonInputData.InputDouble("\t-enter the score(double): ", 0, 10);

                int semester = InputSemester(results, " Enter the semster ");

                results.Add(new Result(learningOutCome.Count() + 1, score, semester, id));

            }
            learningOutCome.AddRange(results);
            int departmentId = ChoseTheDepartment();



            if (type == 1)
            {
                Student st = new Student(id, fullName, dob, yearOfAdmission, entryPoint, departmentId);
                DisplayStudent(st);
            }
            else
            {
                string jointPlace = _singletonInputData.InputString("Enter the joint place: ");

                Student studentInService = new StudentInService(id, fullName, dob, yearOfAdmission, entryPoint, departmentId, jointPlace);
                students.Add(studentInService);
                DisplayStudent(studentInService);
            }
        }
        //4 check type 
        public bool IsStudentInService(Student student)
        {
            if (student is StudentInService s)
            {
                return true;
            }
            return false;
        }

        public void DisplayListStudent(List<Student> stds)
        {
            if (stds == null || stds.Count() == 0)
            {
                return;
            }
            foreach (Student student in stds)
            {


                DisplayStudent(student);
            }

            Console.WriteLine("----------------");

        }
        public void DisplayStudent(Student student)
        {
            if (student.GetType() == typeof(StudentInService))
            {
                Console.WriteLine($"StudentInService: {(StudentInService)student}");
            }
            else
            {
                Console.WriteLine($"Student: {student}");

            }
        }

        // display student in department
        public void GetStudentInDepartment()
        {
            int departmentId = ChoseTheDepartment();
            var result = students.Where(s => s.DepartmentId == departmentId).ToList();
            DisplayListStudent(result);
        }

        //6 get result of list sutudent in semester
        public void GetResultBySemester()
        {
            int semester = _singletonInputData.InputInt("Enter the result");
            var result = learningOutCome.Where(l => l.Semester == semester)
                                        .Join(students,
                                        l => l.StudentId,
                                        s => s.Id,
                                        (l, s) => new
                                        {
                                            Student = s,
                                            Score = l.Score
                                        });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Student.FullName}: score : {item.Score}");
            }

        }

        //7 
        public void CountStudentInDepartment()
        {
            int departmentId = ChoseTheDepartment();

            var result = students.Where(s => s.DepartmentId == departmentId && s.GetType() == typeof(Student)).Count();
            Console.WriteLine($"total : {result} students");

            Console.WriteLine("----------");
        }
        //requre 8 - input 6
        public void HighestEntryPointInDepartment()
        {
            int departmentId = ChoseTheDepartment();

            var result = students.Where(s => s.EntryPoint == students.Where(s2 => s2.DepartmentId == departmentId).Max(s2 => s2.EntryPoint) && s.DepartmentId == departmentId).ToList();

            DisplayListStudent(result);


        }

        public int ChoseTheDepartment()
        {
            Console.WriteLine("Chose the department: ");
            for (int i = 0; i < departments.Count(); i++)
            {
                Console.WriteLine($"{i + 1} - department {departments[i].Name}");
            }
            var departmentNumber = _singletonInputData.InputInt("Enter the department number", 1, departments.Count);
            return departments[departmentNumber - 1].Id;
        }
        // require 9  - input 7
        public void FindStudentInServiceInDepartment()
        {
            int departmentId = ChoseTheDepartment();

            var listStudent = students.Where(s => s.DepartmentId == departmentId && s.GetType() == typeof(StudentInService)).ToList();

            string jointPlace = _singletonInputData.InputString("Enter the joinplace");

            foreach (var student in listStudent)
            {
                var studentInservice = (StudentInService)student;
                if (studentInservice.JointPlace.Contains(jointPlace))
                {
                    Console.WriteLine($"StudentInService: {(StudentInService)student}");
                }
            }

        }



        //10
        public int GetCurrentSemester(int studentId)
        {
            var result = learningOutCome.Where(l => l.StudentId == studentId).Max(l => l.Semester);

            return result;
        }

        public void GetCurrentResult()
        {


            int departmentId = ChoseTheDepartment();
            var listStudent = students.Where(s => s.DepartmentId == departmentId).ToList();
            foreach (var student in listStudent)
            {

                int semester = GetCurrentSemester(student.Id);
                if (semester != 0)
                {
                    var gpa = learningOutCome.Where(l => l.Semester == semester && l.StudentId == student.Id).Select(l => l.Score).FirstOrDefault();
                    if (gpa >= 8)
                    {
                        if (student.GetType() == typeof(StudentInService))
                        {
                            Console.WriteLine($"StudentInService: {(StudentInService)student}");
                            Console.WriteLine($"GPA in semester {semester}: {gpa}");

                        }
                        else
                        {
                            Console.WriteLine($"Student: {student}");
                            Console.WriteLine($"GPA in semester {semester}: {gpa}");
                        }

                    }
                }


                Console.WriteLine("----------------");
            }



        }

        //11 - input 9
        public void FindHighestScoreIndepartnet()
        {
            int departmentId = ChoseTheDepartment();

            var listScore = students.Where(s => s.DepartmentId == departmentId)
                                    .Join(learningOutCome,
                                            s => s.Id,
                                            l => l.StudentId,
                                            (student, result) => new
                                            {
                                                Student = student,
                                                Score = result.Score,
                                            });

            var result = listScore.Where(l => l.Score == listScore.Max(l => l.Score));
            foreach (var item in result)
            {
                if (item.Student.GetType() == typeof(StudentInService))
                {
                    Console.WriteLine($"StudentInService: {((StudentInService)item.Student).FullName}; Score {item.Score} ");


                }
                else
                {
                    Console.WriteLine($"Student: {item.Student.FullName}; Score {item.Score} ");
                }
            }
        }


        //12 
        public void SortByCompare()
        {
            students.Sort(new StudentCompare());

        }

        //13 input 11
        public void GetNumberOfStudentByYear()
        {
            int year = _singletonInputData.InputInt("Enter the year", 0,2999);
            int departmentId = ChoseTheDepartment();
            var result = students.Where(s => s.YearOfAdmission == year && s.DepartmentId == departmentId).ToList();

            DisplayListStudent(result);

        }


    }


}

