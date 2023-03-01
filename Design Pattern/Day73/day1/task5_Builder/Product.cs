using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_Builder
{
    internal class Product
    {
        private List<string> _Components = new List<string>();

        public void Add(string component)
        {
            _Components.Add(component);
        }

        public void Show()
        {
            Console.WriteLine("\nStadium Screen -------");
            foreach (string component in _Components)
                Console.WriteLine(component);
        }

    }

}
