namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime BD_1 = new(1985, 12, 2);
            DateTime BD_2 = new(1980, 4, 6);
            DateTime BD_3 = new(1986, 4, 12);
            

            Employee employee1 = new Employee(100, BD_2, 5);
            Employee employee2 = new Employee(150, BD_3, 5);
            
            Employee employee3 = new BoardMember(300, BD_1, 5);
            Employee employee4 = new SalesPerson(350, BD_1, 3,4000);

            Department department1 = new Department(1000, "Marketing");
            Club Club1 = new Club(333, "Re");

            department1.AddStaff(employee1);
            department1.AddStaff(employee2);
            department1.AddStaff(employee3);
            department1.AddStaff(employee4);

            Club1.AddMember(employee1);
            Club1.AddMember(employee2);
            Club1.AddMember(employee3);
            Club1.AddMember(employee4);

            Console.WriteLine(department1.ToString());
            Console.WriteLine(Club1.ToString());
            employee1.EndOfYearOperation();
            employee2.EndOfYearOperation();
            employee3.EndOfYearOperation();
            employee4.EndOfYearOperation();
            Console.WriteLine(department1.ToString());
            Console.WriteLine(Club1.ToString());

            employee2.RequestVacation(new DateTime(2021, 8, 3), new DateTime(2021, 8, 10));
            employee3.RequestVacation(new DateTime(2021, 8, 3), new DateTime(2021, 8, 8));
            employee4.RequestVacation(new DateTime(2021, 8, 3), new DateTime(2021, 8, 8));
            Console.WriteLine(department1.ToString());
            Console.WriteLine(Club1.ToString());

            employee4.CheckTarget(5000);
            Console.WriteLine(department1.ToString());
            Console.WriteLine(Club1.ToString());

            employee3.Resign();
            Console.WriteLine(department1.ToString());
            Console.WriteLine(Club1.ToString());



















        }
    }
}