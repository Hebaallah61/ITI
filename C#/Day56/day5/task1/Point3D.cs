using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Point3D : Point
    {
        public int Z { get; set; }

        public Point3D(int _x, int _y, int _z) : base (_x, _y)
        {
            
            Z = _z;
        }
        public Point3D()
        {
            Z= 0;
        }

        public override string ToString()
        {
            return $"Point Coordinates: ({X},{Y},{Z})";
        }

        static public explicit operator string(Point3D pt)
        {
            return pt.ToString() ;
        }
    }
}
