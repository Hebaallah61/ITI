using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_Decorator
{
    internal class GoalKeeper:Player
    {
        public override void PassBall()
        {
            Console.WriteLine("GoalKeeper Passing The Ball");
        }
    }
}
