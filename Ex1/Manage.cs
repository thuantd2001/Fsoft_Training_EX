using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Manage : BaseClass<Officer>
    {
        List<Officer> list = new List<Officer>();
        public Manage()
        {
            _singletonInputData = SingletonInputData.GetInstance();
        }

        public void Menu()
        {
            while (true)
            {
                var value = _singletonInputData.InputInt(1, 4, "1 - Add more officer", "2 - Search by name", "3 - Display officer", "4 - exit");
                switch (value)
                {
                    case 1:
                        AddData();
                        break;
                    case 2:
                        var text = _singletonInputData.InputString("Enter the text search");
                        Display(list, l => l.Name.Equals(text));
                        break;
                    case 3:
                        Display(list);
                        break;
                    case 4:
                        return;
                    default: Console.WriteLine("------------------------"); 
                        break ;
                     
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
                Console.WriteLine("chose the gender ");
                var gender = _singletonInputData.InputInt("0-Male; 1-Female; 2-Other", 0, 2);
                var adress = _singletonInputData.InputString("Enter the adress");

                Officer o = new Officer(id, name, age, (EnumGender)gender, adress);
                list.Add(o);
                Console.WriteLine("=======================");
                Console.WriteLine(o);
            }
            catch
            {

            }
            
        }
        


    }
}
