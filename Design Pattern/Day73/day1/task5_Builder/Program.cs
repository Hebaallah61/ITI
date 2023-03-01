namespace task5_Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Director director = new Director();

            Builder b1 = new ScreenBuilder1();
            Builder b2 = new ScreenBuilder2();

           
            director.ConstructProduct(b1);
            Product stadium1 = b1.GetResult();
            stadium1.Show();

            director.ConstructProduct(b2);
            Product stadium2 = b2.GetResult();
            stadium2.Show();

        }
    }
}