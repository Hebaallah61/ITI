using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Context;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos.Developers;

public class DevelopersRepo : IDevelopersRepo
{
    private readonly TicketsContext _Devcontext;
    public DevelopersRepo(TicketsContext Devcontext)
    {
        _Devcontext = Devcontext;
    }
    public IEnumerable<Developer> GetAll()
    {
      return  _Devcontext.Set<Developer>();
    }

    public IEnumerable<Developer> GetByID(int[] id)
    {
        return _Devcontext.Set<Developer>().Where(
                  d => id.Contains(d.Id));
    }
}
