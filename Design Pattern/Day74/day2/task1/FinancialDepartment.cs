using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_Composite
{
    internal class FinancialDepartment : Department//Leaf
    {
         int id { get; set; }
         String name { get; set; }

        public FinancialDepartment(int _id,string _name) { id = _id;name = _name; }

        public void printDepartmentName()
        {
            Console.WriteLine($"Department Name:{name}");
        }
    }
}
