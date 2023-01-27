using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Subject 
    {
        public int id { get; set; }
        public string name { get; set; }
        public Subject(int _id, string name)
        {
            this.id = _id;
            this.name = name;
        }

        public override string ToString()
        {
            return $"Sub name: {name}";
        }



    }
}
