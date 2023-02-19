using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> Staff;

        public Department(int did, string dnme) {
            DeptID= did;
            DeptName= dnme;
            Staff= new List<Employee>();
        }
        public void AddStaff(Employee e)
        {
            Staff.Add(e);
            e.EmployeeLayOff += this.RemoveStaff;
        }
        ///CallBackMethod
        public void RemoveStaff(object sender,EmployeeLayOffEventArgs e)

        {
            if ((sender is Employee emp) && (sender != null))
            {
                if (e.Cause == LayOffCause.VacationOut)
                {
                    if (emp.GetType().Name == "Employee")
                    {
                        Staff.Remove(emp);
                        Console.WriteLine($"Deleting Employee ED: {emp}");
                    }
                }
                else if (e.Cause == LayOffCause.Sales_Target)
                {
                    if (emp.GetType().Name == "SalesPerson")
                    {
                        Staff.Remove(emp);
                        Console.WriteLine($"Deleting Employee SD: {emp}");
                    }
                }
                else if (e.Cause == LayOffCause.Retire)
                {
                    if (emp.GetType().Name != "BoardMember")
                    {
                        Staff.Remove(emp);
                        Console.WriteLine($"Deleting Employee BD: {emp}");
                    }
                }
                else
                {
                    Staff.Remove(emp);
                    Console.WriteLine($"Deleting Employee ELD: {emp}");
                }


            }

        }

        public override string ToString()
        {
            StringBuilder EmpStaff = new StringBuilder();

            foreach (var employee in Staff)
            {
                EmpStaff.Append(employee.EmployeeID).Append("/");
            }

            return EmpStaff.ToString();
        }
    }
}
