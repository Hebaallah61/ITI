using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.Dtos.Departments;
using Tickets.BL.Dtos.Tickets;
using Tickets.DAL.Repos.Departments;
using Tickets.DAL.Repos.Tickets;

namespace Tickets.BL.Managers.Departments;

public class DepartmentsManager : IDepartmentsManager
{
    private readonly IDepartmentsRepo _Context;
    public DepartmentsManager(IDepartmentsRepo Depcontext)
    {
        _Context = Depcontext;
    }
    public IEnumerable<DepartmentsreadDto> GetAll()
    {
        return _Context.GetAll()
                 .Select(d => new DepartmentsreadDto(d.Id, d.Name, d.Tickets.Select(t =>
                     new TicketgetallDto(t.Id, t.Description, t.Title,t.Developer!.Count)).ToList()
                 ));
    }
}
