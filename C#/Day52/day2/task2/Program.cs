using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a string");
            string list = Console.ReadLine();
            //Console.WriteLine(list);

            string[] reverse = list.Split(' ').Reverse().ToArray(); ;
            Console.WriteLine(string.Join(" ", reverse));

        }
    }
}