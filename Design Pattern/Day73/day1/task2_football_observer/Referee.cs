using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_football_Observer
{
    internal class Referee:IObserver<Location>
    {

        public string Name { get; set; }
        private Location?  _location;
        private Football fb;
        public Referee(string name, Football _fb)
        {
            Name= name;
            fb = _fb;
            _location=fb.Location;
        }
        public void OnCompleted()
        {
            Console.WriteLine($"{Name} Referee Following Ball Location 'Changed'");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{Name} Referee Ball Location does not Change");     
        }

        public void OnNext(Location value)
        {
            _location = value;
        }
    }
}
