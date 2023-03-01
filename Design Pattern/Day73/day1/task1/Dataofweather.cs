using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace task1_Observer
{
    internal class Dataofweather
    {
        private float temperature;
        private float humidity;
        private float pressure;

        public Dataofweather(float _temperature, float  _humidity, float  _pressure) { 
            temperature= _temperature;
            humidity= _humidity;
            pressure= _pressure;
        }
        public event EventHandler<DataofweatherEventArgs> updateweather;

        protected virtual void MeasurementsChanged(DataofweatherEventArgs e)
        {
            updateweather?.Invoke(this, e);//notify
        }

        public float Temperature {
            get { return temperature; }
            set
            {
                if (temperature != value)
                {
                    temperature = value;
                    MeasurementsChanged(new() {Temperature=this.temperature, Humidity=this.humidity, Pressure=this.pressure});
                }
            }
        }

        public float Humidity
        {
            get { return humidity; }
            set
            {
                if (humidity != value)
                {
                    humidity = value;
                    MeasurementsChanged(new() { Temperature = this.temperature, Humidity = this.humidity, Pressure = this.pressure });
                }
            }
        }

        public float Pressure
        {
            get { return pressure; }
            set
            {
                if (pressure != value)
                {
                    pressure = value;
                    MeasurementsChanged(new() { Temperature = this.temperature, Humidity = this.humidity, Pressure = this.pressure });
                }
            }
        }


    }

    public class DataofweatherEventArgs
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
    }
}
