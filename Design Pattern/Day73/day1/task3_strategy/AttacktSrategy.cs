using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3_strategy
{
    internal class AttacktSrategy:TeamStrategy
    {
        public override void play()
        {
            Console.WriteLine("Attack on Titan");
        }
    }
}
