namespace task1_all_in_one_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee [] earray = new Employee[3];

            for (int i = 0; i < earray.Length;i++) {
                Employee e = new Employee();
                Console.WriteLine($"enter employee{i+1} id:");//id
                e.set_id(int.Parse(Console.ReadLine()));
                Console.WriteLine("enter salary");//salary
                e.set_salary(double.Parse(Console.ReadLine()));
                Console.WriteLine("enter security level[guest, Developer, secretary, DBA, security officer ]");//seclevel
                string seclev = Console.ReadLine();
                switch (seclev)
                {
                    case "guest":
                        e.set_securitylevel(securitlevel.guest);
                        break;
                    case "developer":
                        e.set_securitylevel(securitlevel.Developer);
                        break;
                    case "secratery":
                        e.set_securitylevel(securitlevel.secretary);
                        break;
                    case "dba":
                        e.set_securitylevel(securitlevel.DBA);
                        break;
                    case "security officer":
                        e.set_securitylevel(securitlevel.security_officer);
                        break;

                }
                Console.WriteLine("enter day of hiredate");//hdate day
                int d=int.Parse(Console.ReadLine());
                Console.WriteLine("enter month of hiredate");//hdate month
                int m=int.Parse(Console.ReadLine());
                Console.WriteLine("enter year of hiredate");//hdate year
                int y=int.Parse(Console.ReadLine());
                hiredate hdate = new hiredate(d, m, y);
                e.set_hiredate(hdate);
                Console.WriteLine("enter gender[female/male]");//gender
                e.set_gender((gender)Enum.Parse(typeof(gender), Console.ReadLine()));
                earray[i]  = e;
            }

            for(int i = 0; i < earray.Length; i++)
            {
                Console.WriteLine(earray[i]);
            }
            

        }

        struct Employee
        {
            int Id;
            double salary;
            securitlevel secleve;
            hiredate hdate;
            gender gen;

            public void set_id(int _id)
            {
                Id= _id;
            }

            public void set_salary(double _salary)
            {
                salary= _salary;
            }

            public void set_securitylevel(securitlevel sec)
            {
                secleve= sec;
            }

            public void set_hiredate(hiredate hiredate)
            {
                hdate= hiredate;
            }

            public void set_gender(gender _gen)
            {
                gen= _gen;
            }

            public int get_id()
            {
                return Id;
            }

            public double get_salary()
            {
                return salary;
            }

            public securitlevel get_securitylevel()
            {
                return secleve;
            }

            public hiredate get_hiredate()
            {
                return hdate;
            }

            public gender get_gender()
            {
                return gen;
            }

            public override string ToString()
            {
                return $"[ID: {Id}/ salary:{salary:c}/ security level:{secleve}/ hiredate:{hdate.get_day()}-{hdate.get_month()}-{hdate.get_year()}/ gender:{gen}]";
            }

        }

        struct hiredate
        {
            int day;
            int month;
            int year;

            public hiredate(int _day, int _month, int _year)
            {
                day= _day;
                month= _month;
                year= _year;
            }

            public void set_day(int d)
            {
                day= d;
            }

            public void set_month(int m)
            {
                month= m;
            }

            public void set_year(int y)
            {
                year= y;
            }

            public int get_day()
            {
                return day;
            }

            public int get_month()
            {
                return month;
            }

            public int get_year()
            {
                return year;
            }
        }

        enum securitlevel
        {
            guest=0x01, Developer=0x02, secretary=0x03 , DBA=0x04, security_officer=0x0f
        }

        enum gender
        {
            female,male
        }
    }
}