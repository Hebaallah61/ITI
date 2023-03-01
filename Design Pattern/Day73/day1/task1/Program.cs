namespace task1_Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dataofweather d = new(1, 15, 60);
            Screen_Window S1 = new("Egypt");
            Screen_Window S2 = new("Gland");
            d.Temperature = 40;
            d.updateweather += S1.diplay!;
            d.updateweather += S2.diplay!;
            d.Temperature = -2;
            d.Humidity = -2;
            d.Pressure = -2;
        }
    }
}