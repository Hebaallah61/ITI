using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_Decorator
{
    internal abstract class PlayerRole:Player
    {
        protected Player prole;
        public PlayerRole(Player prole)
        {
            this.prole = prole;
        }

        public override void PassBall()
        {
            Console.WriteLine($"{prole} Passing The Ball");
        }
    }
}
