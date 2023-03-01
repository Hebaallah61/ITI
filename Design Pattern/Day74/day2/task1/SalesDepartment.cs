using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_Composite
{
    internal class SalesDepartment:Department//Leaf
    {
        int id;
        String name;

        public SalesDepartment(int id, String name)
        {
            this.id = id;
            this.name = name;
        }
        public void printDepartmentName()
        {
            Console.WriteLine($"Department Name:{name}");
        }
        
    }
}
