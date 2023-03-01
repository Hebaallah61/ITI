using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_football_Observer
{
    internal class Location
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public Location(int _x,int _y,int _z) {
            x= _x;
            y= _y;
            z= _z;
        }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj is Location loc) return loc.x==x &&loc.y==y && loc.z==z;
            return false;
        }
    }
}
