using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public static class Math
    {
        public static double ADD(int x, int y){
            return x+y;
        }
        public static double SUB(int x, int y)
        {
            return x - y;
        }
        public static double MUL(int x, int y)
        {
            return x * y;
        }
        public static double DIV(int x, int y)
        {
            if (y != 0)
            {
                return x / y;
            }
            else
            {
                return 0;
            }
        }


    }
}
