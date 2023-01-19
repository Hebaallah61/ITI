namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region employees array [get from user and set]

            Employee[] earray =new Employee[3]; //array of employees struct

            for (int i = 0; i < earray.Length; i++)
            {
                Employee e = new Employee();//create employee

                Console.WriteLine($"enter id {i+1}:");
                e.set_id(int.Parse(Console.ReadLine()));


                Console.WriteLine("enter gender:");
                e.set_gender((gender)Enum.Parse(typeof(gender),Console.ReadLine())); 


                Console.WriteLine("enter hiredate as day:");
                int d=int.Parse(Console.ReadLine());


                Console.WriteLine("enter hiredate as month:");
                int m = int.Parse(Console.ReadLine());


                Console.WriteLine("enter hiredate as year:");
                int y = int.Parse(Console.ReadLine());


                e.set_date(new hiredate(d,m,y));

                Console.WriteLine("enter salary:");
                e.set_salary(double.Parse(Console.ReadLine()));


                Console.WriteLine("enter scuritylevel[guest-developer-secratery-dba-security officer]");
                string secl=Console.ReadLine();
                switch (secl)
                {
                    case "guest":
                        e.set_seclevel(securitylevel.guest);
                            break;
                    case "developer":
                        e.set_seclevel(securitylevel.developer);
                        break;
                    case "secratery":
                        e.set_seclevel(securitylevel.secratery);
                        break;
                    case "dba":
                        e.set_seclevel(securitylevel.dba);
                        break;
                    case "security officer":
                        e.set_seclevel(securitylevel.security_officer);
                        break;

                }
                earray[i] = e;

            }
            #endregion

            #region display info
            for (int i=0;i< earray.Length; i++)
            {
                Console.WriteLine(earray[i].ToString());//exceplicty or implicitly tostring 
            }

            #endregion
        }

    }

    #region gender and securitylevel enum
    internal enum gender
    {
        female, male
    }


    [Flags]
    enum securitylevel : byte
    {
        guest = 0x01, developer = 0x02, secratery = 0x03, dba = 0x04, security_officer = 0x0F
    }
    #endregion


}