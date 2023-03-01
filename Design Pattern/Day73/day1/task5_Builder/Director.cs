using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_Builder
{
    internal class Director
    {
        public void  ConstructProduct(Builder build)
        {
            build.Sky();
            build.Grass();
            build.Fans();
        }
    }
}
