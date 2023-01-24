namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Duration d1 = new(1, 10, 15);
            Console.WriteLine($"d1: {d1.ToString()}");
            Duration d2 = new(3600);
            Console.WriteLine($"d2: {d2.ToString()}");
            Duration d3 = new(7800);
            Console.WriteLine($"d3: {d3.ToString()}");
            Duration d4 = new(666);
            Console.WriteLine($"d4: {d4.ToString()}");
            Console.WriteLine("=======================");
            
            Duration d5=d1+ d2;
            Console.WriteLine("D===>"+d5);
            d5 = d1 + 7800;
            Console.WriteLine("D===>" +d5 );
            d5 = 666 + d3;
            Console.WriteLine("D===>" + d5);
            d5 = d1++;
            Console.WriteLine("D===>" + d5);
            d5 = --d2;
            Console.WriteLine("D===>" + d5);
            d5 = -d2;
            Console.WriteLine("D===>" + d5);
            Console.WriteLine("=======================");
            Console.WriteLine($"d1>d2? {d1 > d2}");
            Duration d6 = new Duration(1, 1, 1);
            Duration d7 = new Duration(1, 1, 1);
            Console.WriteLine($"d1<=d2? { d6 <= d7}");
            if (d1)
            {
                Console.WriteLine("true");

            }
            else
            {
                Console.WriteLine("false");
            }
            Console.WriteLine("=======================");
            DateTime obj = (DateTime)d1;
            Console.WriteLine(obj);

        }
    }
}