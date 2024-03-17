using ClassLibrary;
using Ex13.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ex13.Service
{
    public class Manage : BaseClass<Employee>
    {
        List<Employee> list = new List<Employee>();
        List<Certificate> certificates = new List<Certificate>();
        public Manage()
        {
            _singletonInputData = SingletonInputData.GetInstance();
        }
        public void InnitData()
        {
            certificates.Add(new Certificate(1, "vip", 1));
            certificates.Add(new Certificate(2, "pro", 2));
            certificates.Add(new Certificate(3, "master", 3));
            certificates.Add(new Certificate(4, "king", 4));


            list.Add(new Experience(1, "thuan", DateTime.ParseExact("12-12-2012", "MM-dd-yyyy", CultureInfo.InvariantCulture), "a@gmail", "0000011", EnumEmployeeType.Experience, certificates,
                2, "java"));
            list.Add(new Experience(2, "xxx", DateTime.ParseExact("12-12-2012", "MM-dd-yyyy", CultureInfo.InvariantCulture), "a@gmail", "0000011", EnumEmployeeType.Experience, certificates,
                2, "java"));
            list.Add(new Experience(3, "vvvv", DateTime.ParseExact("12-12-2012", "MM-dd-yyyy", CultureInfo.InvariantCulture), "a@gmail", "0000011", EnumEmployeeType.Experience, certificates,
                2, "java"));
            list.Add(new Intern(4, "iii", DateTime.ParseExact("12-12-2012", "MM-dd-yyyy", CultureInfo.InvariantCulture), "a@gmail", "0000011", EnumEmployeeType.Intern, certificates,
                "java", 2, "FPT"));
        }
        public void Menu()
        {
            while (true)
            {
                var value = _singletonInputData.InputInt(1, 5, "1 - Add more employee", "2 - Update ", "3 - delete", "4 - display");
                switch (value)
                {
                    case 1:
                        AddData();
                        break;
                    case 2:
                        var id = _singletonInputData.InputInt("Enter the id to update");
                        EditEmploy(id);

                        break;
                    case 3:
                        var idDel = _singletonInputData.InputInt("Enter the Id to delete");
                        DeleteItem(idDel);
                        break;
                    case 4:
                        var typeE = _singletonInputData.InputInt("Enter the type ", 0, 2);
                        DisplayByType((EnumEmployeeType)typeE);
                        break;
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
                    if (list.Any(e => e.Id == id))
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

        public void AddData()
        {
            Employee.EmployeeCount++;
            var id = InputId();
            var name = _singletonInputData.InputString("Enter the name: ");
            var dob = _singletonInputData.InputDateTime("Enter the Dob (MM-dd-yyyy): ");

            var email = _singletonInputData.InputEndWith("Enter email", "@gmail.com", "@fpt.com");
            var phone = _singletonInputData.InputWithRegex("Enter phone", "Charactor must be number and length = 5", @"^\d{5}$");
            var type = _singletonInputData.InputInt("0-Experience; 1-Fresher; 2-Intern", 0, 2);

            var numberOfMember = _singletonInputData.InputInt("Enter the number of certificate", 0, 99);
            List<Certificate> cers = new List<Certificate>();
            if (numberOfMember > 0)
            {
                for (var j = 0; j < numberOfMember; j++)
                {

                    for (var i = 0; i < certificates.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {certificates[i].CertificateName} - {certificates[i].Rank} ");
                    }
                    var classNumber = _singletonInputData.InputInt("Enter the number the Certificate", 1, certificates.Count);
                    var c = certificates[classNumber - 1];

                    var date = _singletonInputData.InputDateTime("Enter the date get certificate (MM-dd-yyyy): ");
                    Certificate cer = new Certificate(c, date);
                    cers.Add(cer);
                }
            }
            if (type == 0)
            {
                var year = _singletonInputData.InputInt("Enter the year", 0);
                var proskill = _singletonInputData.InputString("Enter the skill ");
                Experience e = new Experience(id, name, dob, email, phone, (EnumEmployeeType)type, cers, year, proskill);
                list.Add(e);
                Console.WriteLine($"{Employee.EmployeeCount} new employee ");
                return;
            }
            if (type == 1)
            {
                DateTime granduaDate = _singletonInputData.InputDateTime("Enter the Date (MM-dd-yyyy): ");
                var rank = _singletonInputData.InputInt("Enter the s ");
                Fresher fresh = new Fresher(id, name, dob, email, phone, (EnumEmployeeType)type, cers, granduaDate, rank);
                list.Add(fresh);
                Console.WriteLine($"{Employee.EmployeeCount} new employee ");
                return;
            }
            if (type == 2)
            {
                var major = _singletonInputData.InputString("Enter the major");
                var semester = _singletonInputData.InputInt("Enter the semester");
                var univerName = _singletonInputData.InputString("Enter the University Name");
                Intern intern = new Intern(id, name, dob, email, phone, (EnumEmployeeType)type, cers, major, semester, univerName);
                list.Add(intern);
                Console.WriteLine($"{Employee.EmployeeCount} new employee ");
                return;
            }

        }
        public int SearchIndexEmployee(int id)
        {
            var result = list.IndexOf(list.Where(p => p.Id == id).FirstOrDefault());
            if (result != -1)
            {
                return result;
            }
            return -1;

        }

        public void EditEmploy(int id)
        {
            var index = SearchIndexEmployee(id);
            if (index == -1)
            {
                Console.WriteLine("not found");
                return;
            }
            var name = _singletonInputData.InputString("Enter the name: ");
            var dob = _singletonInputData.InputDateTime("Enter the Dob (MM-dd-yyyy): ");

            var email = _singletonInputData.InputEndWith("Enter email", "@gmail.com", "@fpt.com");
            var phone = _singletonInputData.InputWithRegex("Enter phone", "Charactor must be number and length = 5", @"^\d{5}$");
            var type = _singletonInputData.InputInt("0-Experience; 1-Fresher; 2-Intern", 0, 2);

            var numberOfMember = _singletonInputData.InputInt("Enter the number of certificate", 0, 99);
            List<Certificate> cers = new List<Certificate>();
            if (numberOfMember > 0)
            {
                for (var j = 0; j < numberOfMember; j++)
                {

                    for (var i = 0; i < certificates.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {certificates[i].CertificateName} - {certificates[i].Rank} ");
                    }
                    var classNumber = _singletonInputData.InputInt("Enter the number the Certificate", 1, certificates.Count);
                    var c = certificates[classNumber - 1];

                    var date = _singletonInputData.InputDateTime("Enter the date get certificate (MM-dd-yyyy): ");
                    Certificate cer = new Certificate(c, date);
                    cers.Add(cer);
                }
            }

            if (type == (int)EnumEmployeeType.Experience)
            {
                var year = _singletonInputData.InputInt("\tEnter the Id", 0);
                var proskill = _singletonInputData.InputString("Enter the skill ");
                Experience e = new Experience(id, name, dob, email, phone, (EnumEmployeeType)type, cers, year, proskill);
                list[index] = e;
                return;
            }
            if (type == 1)
            {

                DateTime granduaDate = _singletonInputData.InputDateTime("Enter the Date (MM-dd-yyyy): ");
                var rank = _singletonInputData.InputInt("Enter the rank ");
                Fresher fresh = new Fresher(id, name, dob, email, phone, (EnumEmployeeType)type, cers, granduaDate, rank);
                list[index] = fresh;
                return;
            }
            if (type == 2)
            {
                var major = _singletonInputData.InputString("Enter the major");
                var semester = _singletonInputData.InputInt("Enter the semester");
                var univerName = _singletonInputData.InputString("Enter the University Name");
                Intern intern = new Intern(id, name, dob, email, phone, (EnumEmployeeType)type, cers, major, semester, univerName);
                list[index] = intern;
                return;
            }
        }
        public void DeleteItem(int id)
        {
            var index = SearchIndexEmployee(id);
            if (index == -1)
            {
                Console.WriteLine("not found");
                return;
            }
            list.RemoveAt(index);
        }

        public void DisplayByType(EnumEmployeeType type)
        {
            var result = list.Where(l => l.EmployeeType == type).ToList();
            if (type == EnumEmployeeType.Experience)
            {

                foreach (var employee in result)
                {

                    Experience ex = (Experience)employee;
                    // Cast the employee to Experience
                    Console.WriteLine($"{ex.Id}, {ex.FullName}, {ex.DOB.ToString("MM-dd-yyyy")}, {ex.Email}, {ex.EmployeeType.ToString()},\nYear experient {ex.YearOfExperience}, Pro skill {ex.ProSkill} ");
                }
            }
            else if (type == EnumEmployeeType.Fresher)
            {

                foreach (var employee in result)
                {

                    Fresher fr = (Fresher)employee;
                    // Cast the employee 
                    Console.WriteLine($"{fr.Id}, {fr.FullName}, {fr.DOB.ToString("MM-dd-yyyy")}, {fr.Email}, {fr.EmployeeType.ToString()},\nGranduate {fr.GraduateDate.ToString("MM-dd-yyyy")}, Rank: {fr.GraduationRank} ");
                }
            }
            else if (type == EnumEmployeeType.Intern)
            {

                foreach (var employee in result)
                {
                    // Check if employee has experience data (e.g., YearOfExperience > 0)
                    Intern ex = (Intern)employee;
                    // Cast the employee to Experience
                    Console.WriteLine($"{ex.Id}, {ex.FullName}, {ex.DOB.ToString("MM-dd-yyyy")}, {ex.Email}, {ex.EmployeeType.ToString()},\nMajor {ex.Major},Semester {ex.Semester}, UniverName: {ex.UniversityName} ");
                }
            }
        }



    }
}
