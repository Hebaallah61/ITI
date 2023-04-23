using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos.Departments;

public interface IDepartmentsRepo
{
    IEnumerable<Department> GetAll();
}
