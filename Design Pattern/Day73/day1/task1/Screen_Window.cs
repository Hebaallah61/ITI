using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_Observer
{
    internal class Screen_Window
    {
        public string Screen_Name { get; set; }
        public Screen_Window(string screen_name)
        {
            Screen_Name=screen_name;
        }
        public void diplay(object sender, DataofweatherEventArgs e)
        {
            if(sender is Dataofweather d && d != null)
            {
                Console.WriteLine($"{Screen_Name}:\tTemperature:{e.Temperature}\tHumidity:{e.Humidity}\tPressure:{e.Pressure}\n");
                
            }
        }
    }
}
