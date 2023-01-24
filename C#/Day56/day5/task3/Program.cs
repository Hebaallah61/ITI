namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NC obj1 = new NC();==>not valid
            NC obj = NC.oneobj;
            Console.WriteLine($"Manufacture: {obj.Manufacture}");
            Console.WriteLine($"MAC_Address: { obj.MAC_Address}");
            Console.WriteLine($"Type: {obj.t}");
            Console.WriteLine($"NIC:{obj.nic}");

        }
    }
}