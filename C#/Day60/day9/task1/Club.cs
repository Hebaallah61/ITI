using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Club
    {

        public int ClubID { get; set; }
        public String ClubName { get; set; }
        List<Employee> Members;

        public Club(int cid, String CName)
        {
            ClubID = cid;
            ClubName = CName;
            Members= new List<Employee>();
        }
        public void AddMember(Employee E)
        {
            Members.Add(E);
            E.EmployeeLayOff += RemoveMember;
        }
        ///CallBackMethod
        public void RemoveMember

        (object sender, EmployeeLayOffEventArgs e)

        {
            if ((sender is Employee emp) && (sender != null))
            {
                if (e.Cause == LayOffCause.VacationOut)
                {
                    if (emp.GetType().Name == "Employee")
                    {
                        Members.Remove(emp);
                        Console.WriteLine($"Deleting Employee EC: {emp}");
                    }
                }
                else if (e.Cause == LayOffCause.Sales_Target)
                {
                    if (emp.GetType().Name == "SalesPerson")
                    {
                        Members.Remove(emp);
                        Console.WriteLine($"Deleting Employee SC: {emp}");
                    }
                }
                else if (e.Cause == LayOffCause.Resign)
                {
                    if (emp.GetType().Name != "BoardMember")
                    {
                        Members.Remove(emp);
                        Console.WriteLine($"Deleting Employee BC: {emp}");
                    }
                }
            }
        }
        public override string ToString()
        {
            StringBuilder Club_Members = new StringBuilder();

            foreach (var e in Members)
            {
                Club_Members.Append(e.EmployeeID).Append("/");
            }

            return Club_Members.ToString();
        }
    }
}
