using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Repos.Tickets;

public interface ITicketsRepo
{
    IEnumerable<Ticket> GetAll();
    EntityEntry<Ticket>? AddTicket(Ticket ticket);
    Ticket? GetTicket(int id);
    void RemoveById(int id);
    void UpdateTicket(Ticket ticket);
    int SaveChanges();
}
