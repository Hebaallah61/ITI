using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4_Decorator
{
    internal class Defender:PlayerRole
    {
        public Defender(Player player) : base(player) { }
        public void Defend()
        {
            Console.WriteLine("Defender Defend ");
        }
        public override void PassBall()
        {
            Console.WriteLine("Defend Passing The Ball");
            prole.PassBall();
        }
    }
}
