using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BaseClass<T>

    {
        protected SingletonInputData _singletonInputData;
        
        public void Display(List<T> datas, Func<T, bool> func = null)
        {
            if(func != null)
            {
                datas = datas.Where(func).ToList();
            }

            foreach (var item in datas)
            {
                Console.WriteLine(item);
            }
        }
        public void DisplayGenderic<U>(List<U> datas, Func<U, bool> func = null)
        {
            if (func != null)
            {
                datas = datas.Where(func).ToList();
            }

            foreach (var item in datas)
            {
                Console.WriteLine(item);
            }
        }
        public void Add(List<T> list,T data)
        {
            list.Add(data);
        }
        public List<T> Search( List<T> list ,Func<T,bool> func)
        {
            return list.Where(func).ToList();
        }

      
    }
}
