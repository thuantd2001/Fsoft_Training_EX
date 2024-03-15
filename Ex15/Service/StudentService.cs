using Ex15.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using ClassLibrary;


namespace Ex15.Service
{
    internal class StudentService:BaseClass<Student>
    {
        public List<Department> departments = new List<Department>();
        public List<Student> students = new List<Student>() {};
        public List<InServiceStudent> inServiceStudents = new List<InServiceStudent>();
        public List<LearningOutcome> learningOutCome = new List<LearningOutcome>();

        public void InnitData()
        {
            // department
            departments.Add(new Department(1,"Math"));
            departments.Add(new Department(2,"History"));
            departments.Add(new Department(3,"Technology"));

            // student
            students.Add(new Student( new Guid().ToString(), "Hai", DateTime.ParseExact("01-01-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 9.5, 1));
            students.Add(new Student(new Guid().ToString(), "Thuan", DateTime.ParseExact("01-30-2001", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 7, 1));
            students.Add(new Student(new Guid().ToString(), "Linh", DateTime.ParseExact("02-06-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2018, 7.5, 2));
            students.Add(new Student(new Guid().ToString(), "Hoang", DateTime.ParseExact("06-06-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2016, 8, 2));
            students.Add(new Student(new Guid().ToString(), "Van", DateTime.ParseExact("08-08-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 6, 3));
            // student in service
            inServiceStudents.Add(new InServiceStudent(new Guid().ToString(), "Khoa", DateTime.ParseExact("08-07-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 9.5, 3,"FPT funic"));
            inServiceStudents.Add(new InServiceStudent(new Guid().ToString(), "Hoang", DateTime.ParseExact("12-16-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 9.5, 3, "VTI academic"));
            inServiceStudents.Add(new InServiceStudent(new Guid().ToString(), "Hoang", DateTime.ParseExact("02-07-2022", "MM-dd-yyyy", CultureInfo.InvariantCulture), 2019, 9.5, 2, "Vin"));
            // learning outcome
            learningOutCome.Add(new LearningOutcome(1, 5, students[0].Id));
            learningOutCome.Add(new LearningOutcome(2, 8, students[0].Id));
            learningOutCome.Add(new LearningOutcome(1, 10, students[1].Id));
            learningOutCome.Add(new LearningOutcome(1, 5, students[2].Id));
            learningOutCome.Add(new LearningOutcome(1, 4, students[2].Id));
            learningOutCome.Add(new LearningOutcome(1, 8, students[3].Id));
            learningOutCome.Add(new LearningOutcome(1, 5, students[0].Id));
            learningOutCome.Add(new LearningOutcome(1, 7, students[1].Id));
            learningOutCome.Add(new LearningOutcome(1, 6, students[4].Id));
            learningOutCome.Add(new LearningOutcome(1, 1, students[2].Id));

        }
        public Student InputStudent()
        {
            try
            {

                string id = new Guid().ToString();
                Console.WriteLine("Enter FullName: ");
                string fullName = Console.ReadLine().Trim();
                Console.WriteLine("Enter dob(MM-dd-yyyy): ");
                string enterDob = Console.ReadLine();
                DateTime dob = DateTime.ParseExact(enterDob, "MM-dd-yyyy", CultureInfo.InvariantCulture); // 
                Console.WriteLine("Enter year of admission");
                int yearOfAdmission = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Entry point(double)");
                double entryPoint = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter number of Learning outcome");
                int number = Convert.ToInt32(Console.ReadLine());

                //learning outcome
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine("  -enter the score(double): ");
                    double score = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("  -enter the semester(int): ");
                    int semester = Convert.ToInt32(Console.ReadLine());

                    learningOutCome.Add(new LearningOutcome(score, semester, id));
                }
                //
                int departmentId = 0;

                Student st = new Student(id, fullName, dob, yearOfAdmission, entryPoint, departmentId);

                return st;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                if (e.InnerException != null)
                {
                    Console.WriteLine("message: " + e.Message);
                }
                return null;
            }
        }

        //public int ChoseDepartment()
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            for (int i = 0; i < departments.Count(); i++)
        //            {

        //                Console.WriteLine($"Number: {++i}: {departments[i]}");
        //            }
        //            Console.WriteLine("Enter number for chose department");
        //            int number = Convert.ToInt32(Console.ReadLine());

        //            return departments[number].Id;

        //        }
        //        catch(Exception ex)
        //        {
        //            Console.WriteLine("please enter again ");
        //        }
        //    }
        //}

        //public InServiceStudent InputInServiceStudent()
        //{
        //    try
        //    {
        //        Student s = InputStudent();
        //        Console.WriteLine("enter joint place ");
        //        string jointPlace = Console.ReadLine();
        //        InServiceStudent iStudent = new InServiceStudent(s.Id,s.FullName,s.DOB,s.YearOfAdmission,s.EntryPoint,2 ,jointPlace);
        //        return iStudent;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error");
        //        if (e.InnerException != null)
        //        {
        //            Console.WriteLine("message: " + e.Message);
        //        }
        //        return null;
        //    }
        //}

        //public void AddMoreStudent()
        //{
        //    Student s = InputStudent();
        //    students.Add(s);
        //}
        //public void AddMoreInServiceStudent()
        //{
        //    InServiceStudent s = InputInServiceStudent();
        //    inServiceStudents.Add(s);
        //}
        //public void DisplayStudent()
        //{
        //    foreach(var s in students)
        //    {
        //        double gpa = GetGPA(s);
        //        string formattedGpa = gpa.ToString("F2"); // Format GPA to two decimal places

        //        Console.WriteLine(s.ToString() + " \nGPA: " + formattedGpa);

        //    }
        //}

        //public void DisplayInServiceStudent()
        //{
        //    foreach (var s in inServiceStudents)
        //    {

        //        double gpa = GetGPA(s);
        //        string formattedGpa = gpa.ToString("F2"); // Format GPA to two decimal places

        //        Console.WriteLine(s.ToString() + " \nGPA: " + formattedGpa);
        //    }
        //}
        //public bool CheckStudent(Student st)
        //{
        //    return st.GetType() == typeof(Student);
        //}
        //public double GetGPA(Student s)
        //{
        //    double total = learningOutCome.Where(l=> l.StudentId.Equals(s.Id)).Sum( l => l.Score);
        //    int count = learningOutCome.Where(l=> l.StudentId.Equals(s.Id)).Count();

        //    return Math.Round(total / count);
        //}

        //public void Input()
        //{
        //    Console.WriteLine("1: Display list student");
        //    Console.WriteLine("2: Display list student in service");
        //    while (true)
        //    {

        //    }
        //}


    }
}
