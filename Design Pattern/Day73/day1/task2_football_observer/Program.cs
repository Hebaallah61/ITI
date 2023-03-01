namespace task2_football_Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Football fb = new(new(5, 6, 10));
            Player p1 = new("Player:Ahmed", fb);
            Player p2 = new("Player:Mohammed", fb);
            Referee r1 = new("Referee:Ali", fb);
            fb.Attach(p1);
            fb.Attach(p2);
            fb.Attach(r1);
            fb.Location = new(4, 9, 3);

        }
    }
}