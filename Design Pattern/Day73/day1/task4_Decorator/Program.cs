namespace task4_Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {   Player gooalk = new GoalKeeper();
            gooalk=new Defender(gooalk);
            gooalk.PassBall();
            if(gooalk is Defender defender)
            {
                defender.Defend();
            }
            Console.WriteLine("\n");

            Player fieldp= new FieldPlayer();
            fieldp = new Forward(fieldp);
            fieldp.PassBall();
            if(fieldp is Forward ford)
            {
                ford.ScootGoal();
            }

            


        }
    }
}