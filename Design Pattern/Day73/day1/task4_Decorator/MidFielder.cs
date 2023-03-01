using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_Decorator
{
    internal class MidFielder:PlayerRole
    {
        public MidFielder(Player player) : base(player) { }
        public void Dribble()
        {
            Console.WriteLine("MidFielder Dribbling ");
        }
        public override void PassBall()
        {
            Console.WriteLine("MidFielder Passing The Ball");
            prole.PassBall();
        }

    }
}
