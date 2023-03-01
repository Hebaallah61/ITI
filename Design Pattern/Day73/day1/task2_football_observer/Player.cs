using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_football_Observer
{
    internal class Player : IObserver<Location>
    {
        public string Name { get; set; }
        private Location _location;
        private Football fb;

        public Player(string name,Football _fb) {
            Name= name;
            fb= _fb;
            _location = fb.Location;
        }
        public void OnCompleted()
        {
            Console.WriteLine($"{Name} Player Is Running To Ball Location 'Changed'");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{Name} Player Ball Location Changed");
        }

        public void OnNext(Location value)
        {
            _location = value;
        }
    }
}
