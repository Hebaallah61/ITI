using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace task1.Models
{
    public class EmployeeList
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee(){Id=1,Name="Ahmed",Title="DevOps"},
            new Employee(){Id=2,Name="Hany",Title="Developer"},
            new Employee(){Id=3,Name="Omar",Title="Full Stack"},
            new Employee(){Id=4,Name="Mahmoud",Title=".Net"},
            new Employee(){Id=5,Name="Ali",Title="Agile"},
            new Employee(){Id=6,Name="Lotfy",Title="Data Analyst"},
            new Employee(){Id=7,Name="Hassan",Title="UI/UX"},

        };
    }
}