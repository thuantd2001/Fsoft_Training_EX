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
        public int InputInt(string mess, int min= -999, int max=999)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(mess);

                    var input = Console.ReadLine();
                    var value = Convert.ToInt32(input);
                    if (value < min || value > max) throw new Exception($"Value must be more than {max} and less than {min}");
                    return value;
                }
                catch(Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.WriteLine($"Please {mess} again !! ");
                }
            }
        }
        public double InputDouble(string mess, int min = -999, int max = 999)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(mess);
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
    }
}
