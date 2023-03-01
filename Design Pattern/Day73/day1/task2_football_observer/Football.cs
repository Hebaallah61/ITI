using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_football_Observer
{
    internal class Football:Ball
    {
        private Location _location;
        public Location Location
        {
            get { return _location; }
            set { 
                if (value != _location) {
                    _location = value;
                    Notify(value);
                } }///---------notify
        }
        public Football(Location value)
        {
            _location = value;
        }
    }
}
