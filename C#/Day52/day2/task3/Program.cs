using System.Diagnostics;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //Console.WriteLine(calc1());
            //Console.WriteLine(calc2());
            Console.WriteLine(calc3());

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

        }
       
        public static int calc1()
        {
            int count = 0;
             for (int i = 1; i < Math.Pow(10, 8); i++)//12480//11948
                         {
                             int j = i;
                             while (j > 0)
                             {
                                 if ((j % 10) == 1)
                                 {
                                     count++;

                                 }
                                 j /= 10;
                             }
                         }
            return count;
        }

        public static int calc2()
        {
            int count = 0;
            for(int i = 0; i < Math.Pow(10, 8); i++)//12615//12909
                         {
                             count += i.ToString().Split("1").Length-1;
                         }
            return count;

        }

        public static double calc3()
        {
            return (8 * Math.Pow(10,7));//18

        }

    }

    
}
