using System;

namespace _1.ClassBoxData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var boxParams = new double[3];
            for (int i = 0; i < boxParams.Length; i++)
            {
                boxParams[i] = double.Parse(Console.ReadLine());
            }
            try
            {
                Console.WriteLine(new Box(boxParams[0], boxParams[1], boxParams[2]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

