using System.Drawing;
using System.Xml.Linq;
using System;
using System.Security.Claims;

namespace task1_all_in_one_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee[] earray = new Employee[3];

            //for (int i = 0; i < earray.Length; i++)
            //{
            //    Employee e = new Employee();
            //    Console.WriteLine($"enter employee{i + 1} id:");//id
            //    e.ID=(int.Parse(Console.ReadLine()));
            //    Console.WriteLine("enter salary");//salary
            //    e.Salary=(double.Parse(Console.ReadLine()));
            //    Console.WriteLine("enter security level[guest, Developer, secretary, DBA, security officer ]");//seclevel
            //    string seclev = Console.ReadLine();
                
            //        switch (seclev)
            //        {
            //            case "guest":
            //                e.Set_securitylevel = (securitlevel.guest);
            //                break;
            //            case "developer":
            //                e.Set_securitylevel = (securitlevel.Developer);
            //                break;
            //            case "secratery":
            //                e.Set_securitylevel = (securitlevel.secretary);
            //                break;
            //            case "dba":
            //                e.Set_securitylevel = (securitlevel.DBA);
            //                break;
            //            case "security officer":
            //                e.Set_securitylevel = (securitlevel.security_officer);
            //                break;

            //        }
               
            //    Console.WriteLine("enter day of hiredate");//hdate day
            //    int d = int.Parse(Console.ReadLine());
            //    Console.WriteLine("enter month of hiredate");//hdate month
            //    int m = int.Parse(Console.ReadLine());
            //    Console.WriteLine("enter year of hiredate");//hdate year
            //    int y = int.Parse(Console.ReadLine());
            //    hiredate hdate = new hiredate(d, m, y);
            //    e.Hiredate=(hdate);
            //    Console.WriteLine("enter gender[female/male]");//gender
            //    e.Gender=((gender)Enum.Parse(typeof(gender), Console.ReadLine()));
            //    earray[i] = e;
            //}

            //for (int i = 0; i < earray.Length; i++)
            //{
            //    Console.WriteLine(earray[i]);
            //}

            Console.WriteLine("=========================================================");

            EmployeeSearch employees = new(3);
            string name;
            int nid;
            gender gen;
            hiredate hd;
            securitlevel sec;
            int _d, _m, _y;
            double sal;
            object temp;

            for (int i = 0; i < employees.C; i++)
            {
                Console.WriteLine($"enter employee name:");//name
                name = (Console.ReadLine());
                Console.WriteLine($"enter employee national id:");//nid
                nid = (int.Parse(Console.ReadLine()));
                Console.WriteLine("enter day of hiredate");//hdate day
                _d = int.Parse(Console.ReadLine());
                Console.WriteLine("enter month of hiredate");//hdate month
                _m = int.Parse(Console.ReadLine());
                Console.WriteLine("enter year of hiredate");//hdate year
                _y = int.Parse(Console.ReadLine());
                hiredate _hdate = new hiredate(_d, _m, _y);
                Console.WriteLine("enter gender[female/male]");//gender
                gen = ((gender)Enum.Parse(typeof(gender), Console.ReadLine()));
                Console.WriteLine("enter salary");//salary
                sal = (double.Parse(Console.ReadLine()));
                Console.WriteLine("enter security level[guest, Developer, secretary, DBA, security officer ]");//seclevel
                while (!Enum.TryParse(typeof(securitlevel), Console.ReadLine(), out temp)) ;
                sec = (securitlevel)temp;

                employees[nid, name!, _hdate] = new Employee(nid, sal, sec, _hdate, gen);

            }
            Console.WriteLine("=========================================");
            Console.WriteLine("enter name to search");
            name= (Console.ReadLine());
            Console.WriteLine(employees[name!]);
            
           
        }

        struct Employee
        {
            int Id;
            double salary;
            securitlevel secleve;
            hiredate hdate;
            gender gen;

            public Employee(int id, double salary,securitlevel sec,hiredate hd,gender gen)
            {
                this.Id = id;
                this.Salary = salary;
                this.hdate = hd;
                this.gen = gen;
                this.secleve= sec;
            }

            public int ID
            {
                set { Id = value; }
                get { return Id; }
            }

       
            public double Salary
            {
                set { salary = value; }
                get { return salary; }
            }


           

            public securitlevel Set_securitylevel
            {
                set { secleve = value; }
                get { return secleve; }
            }

            public hiredate Hiredate
            {
                set { hdate = value; }
                get { return hdate; }
            }


            

            public gender Gender
            {
                set { gen = value; }
                get { return gen; }
            }

        
        

            public override string ToString()
            {
                return $"[ID: {Id}/ salary:{salary:c}/ security level:{secleve}/ hiredate:{hdate.Day}-{hdate.Month}-{hdate.Year}/ gender:{gen}]";
            }
        }

        class EmployeeSearch{ 
          int[] NationalIDs;
          Employee[] Employees;
            string[] name;
            hiredate[] hdate;
            int size;
            int c;
            public EmployeeSearch(int c)//ctor
            {
                this.size= 0;
                Employees = new Employee[c];
                NationalIDs= new int[c];
                name= new string[c];
                hdate= new hiredate[c];
                this.c = c;
            }

            public int C
            {
                get { return c; }
            }

            public int Size
            {
                get { return size; }
            }
            public Employee? this[int index]
            {
                get
                {
                    if(index<size)
                        return Employees[index];
                    return null;
                }
            }
            
            public Employee? this [long natid]
            {
                get
                {
                    for(int i = 0; i < size; i++)
                    {
                        if (NationalIDs[i] ==natid)
                            return Employees[i];
                    }
                    return null;
                }
            }

            public Employee? this[string nam]
            {
                get
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (name[i] == nam)
                            return Employees[i];
                    }
                    return null;
                }
            }

            public Employee? this[hiredate hd]
            {
                get
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (hdate[i].checkdate(hd))
                            return Employees[i];
                    }
                    return null;
                }
            }

            public Employee this[int id,string nam,hiredate hd]
            {
                set
                {
                    if (size != c)
                    {
                        NationalIDs[size] = id;
                        name[size] = nam;
                        hdate[size] = hd;
                        Employees[size] = value;
                        size++;
                    }
                    else
                    {
                        throw new Exception("full !--!");
                    }
                }
            }


        }


    struct hiredate
        {
            int day;
            int month;
            int year;

            public hiredate(int _day, int _month, int _year)
            {
                day = _day;
                month = _month;
                year = _year;
            }

       

            public int Day
            {
                set { day = value; }
                get { return day; }
            }

            public int Month
            {
                set { month = value; }
                get { return month; }
            }

           public int Year
            {
                set { year = value; }
                get
                {
                    return year;
                }
            }

            public bool checkdate(hiredate hd)
            {
                return hd.year==year && hd.month==month && hd.day==day;
            }



        }

        enum securitlevel
        {
            guest = 0x01, Developer = 0x02, secretary = 0x03, DBA = 0x04, security_officer = 0x0f
        }

        enum gender
        {
            female, male
        }
    }
}