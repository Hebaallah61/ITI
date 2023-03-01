using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3_strategy
{
    internal class Team
    {
        public string Name { get; set; }
        public TeamStrategy Strategy { get; set; }
        public Team(String name) {
            Name= name;
            Strategy = new DefendStrategy();
        }
        public void play()
        {
            Strategy.play();
        }
    }
}
