using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    internal class City : BaseClass<Family>
    {
        public List<Family> families = new List<Family>();

        public City()
        {
            _singletonInputData = SingletonInputData.GetInstance();
        }

        public void Menu()
        {
            while (true)
            {
                var value = _singletonInputData.InputInt(1, 2, "1 - Add more Family", "2 - display");
                switch (value)
                {
                    case 1:
                        AddData();
                        break;
                    case 2:
                        Display(families);

                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("--------------");
                        break;

                }
            }
        }
        public void AddData()
        {
            try
            {
                var n = _singletonInputData.InputInt("Enter the number of family", 1, 2);
                for (var i = 0; i < n; i++)
                {
                    var homeId = _singletonInputData.InputInt("Enter the homeId", 1);
                    var numberOfMember = _singletonInputData.InputInt("Enter the number of member", 1, 99);
                    List<Member> members = new List<Member>();
                    for (var j = 0; j < numberOfMember; j++)
                    {
                        
                        Console.WriteLine($"\tEnter the member number {j+1}");
                        var id = _singletonInputData.InputInt("\tEnter the Id", 1);
                        var fullName = _singletonInputData.InputString("\tEnter the fullName");
                        var age = _singletonInputData.InputInt("\tEnter the Age", 1);
                        var job = _singletonInputData.InputString("\tEnter the job");
                        Member m = new Member(id, fullName, age, job);
                        members.Add(m);
                    }
                    Family f = new Family(homeId, members);
                    families.Add(f);
                }
                Console.WriteLine("success");
            }
            catch
            {
                Console.WriteLine("fail");
            }
        }

    }
}
