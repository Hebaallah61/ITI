using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string img { get; set; }
        public override string ToString()
        {
            return  $"Name:{Name}";
        }
    }
}