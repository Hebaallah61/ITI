using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.Dtos.Developers;
using Tickets.BL.Dtos.Tickets;
using Tickets.DAL.Data.Models;
using Tickets.DAL.Repos.Developers;
using Tickets.DAL.Repos.Tickets;

namespace Tickets.BL.Managers.Developers;

public class DevelopersManager : IDevelopersManager
{
    
    private readonly IDevelopersRepo _Context;
    public DevelopersManager( IDevelopersRepo developersRepo)
    {

        _Context = developersRepo;
    }
    public IEnumerable<DeveloperDto> GetAll()
    {
        var DeveloperfromDB = _Context.GetAll();
        return DeveloperfromDB.Select(d => new DeveloperDto( Id:d.Id,Name:d.Name));

    }
    private DeveloperDto MapDevDto(Developer t)//for getbyid
    {
        return new DeveloperDto(t.Id, t.Name);
    }
    public DeveloperDto? GetById(int[] id)
    {
        Developer? developer = (Developer?)_Context.GetByID(id);
        if (developer == null) return null;
        return MapDevDto(developer);
    }
}
