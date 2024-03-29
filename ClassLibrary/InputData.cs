﻿using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public sealed class SingletonInputData
    {

        private static int Counter = 0;
        //This variable is going to store the SingletonInputData Instance
        private static SingletonInputData Instance = null;
        //The following Static Method is going to return the SingletonInputData Instance
        public static SingletonInputData GetInstance()
        {
            //This is not thread-safe
            if (Instance == null)
            {
                Instance = new SingletonInputData();
            }
            //Return the SingletonInputData Instance
            return Instance;
        }
        public int InputInt(int min = -999, int max = 999, params string[] mess)
        {
            while (true)
            {
                try
                {
                    foreach (var item in mess)
                    {
                        Console.WriteLine(item);
                    }

                    var input = Console.ReadLine();
                    var value = Convert.ToInt32(input);
                    if (value < min || value > max) throw new Exception($"Value must be more than {max} and less than {min}");
                    return value;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine($"Please enter again !! ");
                }
            }
        }
        public string InputString(string mess)
        {
            Console.WriteLine(mess);
            var value = Console.ReadLine().Trim();
            return value;
        }
        public int InputInt(string mess, int min = -999, int max = 999)
        {
            Console.WriteLine(mess);
            while (true)
            {
                try
                {


                    var input = Console.ReadLine();
                    var value = Convert.ToInt32(input);
                    if (value < min || value > max) throw new Exception($"Value must be more than {max} and less than {min}");
                    return value;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine($"Please {mess} again !! ");
                }
            }
        }
        public double InputDouble(string mess, int min = -999, int max = 999)
        {
            Console.WriteLine(mess);
            while (true)
            {
                try
                {

                    var input = Console.ReadLine();
                    var value = Convert.ToDouble(input);
                    if (value < min || value > max) throw new Exception($"Value must be more than {max} and less than {min}");
                    return value;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine($"Please {mess} again !! ");
                }
            }
        }
        public DateTime InputDateTime(string mess)
        {
            Console.WriteLine(mess);
            while (true)
            {
                try
                {
                    string enterDob = Console.ReadLine();
                    DateTime value = DateTime.ParseExact(enterDob, "MM-dd-yyyy", CultureInfo.InvariantCulture); // 

                    return value;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine($"Please {mess} again !! ");
                }
            }
        }


        public string InputEndWith(string mess, params string[] end)
        {
            Console.WriteLine(mess);
            while (true)
            {
                try
                {
                    var value = Console.ReadLine().Trim();
                    bool flag = false;
                    StringBuilder sb = new StringBuilder();
                    if (end != null && end.Length > 0)
                    {
                        for (var i = 0; i < end.Count(); i++)
                        {
                            if (i < (end.Count() - 1))
                            {
                                sb.Append($"{end[i]} or ");
                            }
                            else
                            {
                                sb.Append(end[i]);
                            }
                            if (value.EndsWith(end[i]))
                            {
                                flag = true;
                            }
                         

                        }
                    }

                    if (!flag)
                    {
                        throw new Exception($"Value must be end with {sb.ToString()}");
                    }

                    return value;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine($"Please {mess} again !! ");
                }
            }


        }
        public string InputStartWith(string mess, params string[] start)
        {
            Console.WriteLine(mess);
            while (true)
            {
                try
                {
                    bool flag = false;
                    var value = Console.ReadLine().Trim();
                    StringBuilder sb = new StringBuilder();
                    if (start != null && start.Length > 0)
                    {
                        for (var i = 0; i < start.Count(); i++)
                        {
                            if (i < (start.Count() - 1))
                            {
                                sb.Append($"{start[i]} or");
                            }
                            else
                            {
                                sb.Append(start[i]);
                            }

                            if (value.StartsWith(start[i]))
                            {
                                flag = true;
                            }
                        }
                    }
                    if (!flag)
                    {
                        throw new Exception($"Value must be end with {sb.ToString()}");
                    }

                    return value;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine($"Please {mess} again !! ");
                }
            }


        }

        public string InputWithRegex(string mess, string messErorr, string regex)
        {
            Console.WriteLine(mess);
            while (true)
            {
                try
                {

                    var value = Console.ReadLine().Trim();

                    bool isNumeric = Regex.IsMatch(value, regex);

                    if (!isNumeric)
                    {
                        throw new Exception(messErorr);
                    }

                    return value;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine($"Please {mess} again !! ");
                }
            }
        }
    }
}
