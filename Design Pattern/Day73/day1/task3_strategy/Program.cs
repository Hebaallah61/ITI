namespace task3_strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team t1 = new("Wings of Freedom");
            t1.play();

            t1.Strategy = new AttacktSrategy();
            t1.play();
            
        }
    }
}