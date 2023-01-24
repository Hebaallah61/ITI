using System.ComponentModel;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter num1");
            int x=int.Parse(Console.ReadLine());
            Console.WriteLine("enter num2");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine($"x+y={Math.ADD(x,y)}");
            Console.WriteLine($"x-y={Math.SUB(x,y)}");
            Console.WriteLine($"x*y={Math.MUL(x,y)}");
            Console.WriteLine($"x/y={Math.DIV(x,y)}");

        }
    }
}