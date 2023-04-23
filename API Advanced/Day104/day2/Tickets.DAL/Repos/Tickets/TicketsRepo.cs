using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Context;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos.Tickets;

public class TicketsRepo : ITicketsRepo
{
    private readonly TicketsContext _ticketsContext;

    public TicketsRepo(TicketsContext ticketsContext)
    {
        _ticketsContext = ticketsContext;
    }

    public EntityEntry<Ticket>? AddTicket(Ticket ticket)
    {
        if(ticket == null) throw new ArgumentNullException(nameof(ticket));
        
        return _ticketsContext.Set<Ticket>().Add(ticket);
    }

    public IEnumerable<Ticket> GetAll()
    {
       return _ticketsContext.Set<Ticket>().Include(d=>d.Developer);
    }

    public Ticket? GetTicket(int id)
    {
        Ticket? ticket=_ticketsContext.Set<Ticket>().Include(d=>d.Developer).FirstOrDefault(d=>d.Id==id);
        if(ticket == null) return null;
        return ticket;
    }

    public void RemoveById(int id)
    {
        Ticket? ticket = GetTicket(id);
        if(ticket != null)
        {
           _ticketsContext.Set<Ticket>().Remove(ticket);
        }
        return ;

    }

    public int SaveChanges()
    {
      return  _ticketsContext.SaveChanges();
    }

    public void UpdateTicket(Ticket ticket)
    {
        var oldticket = GetTicket(ticket.Id);
        if(oldticket != null)
        {
            oldticket.Title=ticket.Title;
            oldticket.Description=ticket.Description;
            oldticket.Department=ticket.Department;
        }
        return;
    }
}
