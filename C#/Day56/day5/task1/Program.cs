namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x=0, y=0, z=0;
            string point2;
            int parse = 0;
            Point3D p1 = new();
            Point3D p2 = new();

            do
            {
                Console.WriteLine("enter x for p1");

            } while (!int.TryParse(Console.ReadLine(), out x));


            do
            {
            Console.WriteLine("enter y for p1");
                try { y = Convert.ToInt32(Console.ReadLine());
                    parse = 1;
                }catch(Exception ex) { };
            } while (parse==0);
            parse= 0;

            do { Console.WriteLine("enter z for p1");
                try
                {
                    z = int.Parse(Console.ReadLine());
                    parse= 1;
                }catch(Exception ex) { };
            } while (parse==0);
            parse= 0;
            
            p1= new(x,y,z);
            do
            {
                do
                {
                    Console.WriteLine("enter x,y,z for p2");
                } while ((point2 = Console.ReadLine()) == null);

                string[] xyz2 = point2.Split(',');
                if (xyz2.Length > 3 || xyz2.Length < 3)
                {
                    Console.WriteLine("not valid point");
                }
                else
                {
                    x = int.Parse(xyz2[0]);
                    y = int.Parse(xyz2[1]);
                    z = int.Parse(xyz2[2]);
                    p2= new(x,y,z);
                    parse = 1;
                }
            }while(parse==0);
           
            Console.WriteLine("p1: " +p1);
            Console.WriteLine("p2: " +p2);
            Console.WriteLine($"p1 == p2 : {p1==p2}" );
            Console.WriteLine("p1.Equals(p2): " + p1.Equals(p2));
            Console.WriteLine("p1.tostring : " + p1.ToString());



        }
    }
}