using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Context;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos.Departments;

public class DepartmentsRepo : IDepartmentsRepo
{
    private readonly TicketsContext _ticketsContext;

    public DepartmentsRepo(TicketsContext ticketsContext)
    {
        _ticketsContext = ticketsContext;
    }
    public IEnumerable<Department> GetAll()
    {
       return _ticketsContext.Set<Department>().Include(t=>t.Tickets).ThenInclude(d=>d.Developer);
    }
}
