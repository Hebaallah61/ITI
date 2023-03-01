using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_football_Observer
{
    internal class Ball 
    {
        List<IObserver<Location>> observers = new();
        public void Attach(IObserver<Location> observer)
        {
            observers.Add(observer);
        }
        public void Detach(IObserver<Location> observer)
        {
            observers.Remove(observer);
        }
        public void Notify(Location loc)
        {
            foreach (var observer in observers)
            {
                try
                {
                    observer.OnNext(loc);
                }
                catch (Exception ex) { observer.OnError(ex); }
                finally { observer.OnCompleted(); }

            }
        }
    }
}
