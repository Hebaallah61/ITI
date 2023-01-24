using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Point
    {
        public int x, y;

        public int X
        {
            set { this.x = value; }
            get { return x; }
        }

        public int Y
        {
            set { this.y = value; }
            get { return y; }
        }

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(int x) : this()
        {
            X= x;
        }

        public Point(int x,int y) : this(x)
        {
            Y= y;
        }

        
        

        public override bool Equals(object? obj)
        {
            if(obj == null)
            return false;
            Point p=(Point)obj;
            if(this.x==p.X && this.y==p.y) return true;
            else return false;
        }

        public override string ToString()
        {
            return $"Point Coordinates: ({X},{Y})";
        }
    }
}
