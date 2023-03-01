using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_Decorator
{
    internal class Forward:PlayerRole
    {
        public Forward(Player player) : base(player) { }
        public void ScootGoal()
        {
            Console.WriteLine("Forward Scooting to Goal");
        }
        public override void PassBall()
        {
            Console.WriteLine("Forward Passing The Ball");
            prole.PassBall();
        }
    }
}
