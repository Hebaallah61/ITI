using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.Dtos.Developers;
using Tickets.BL.Dtos.Tickets;
using Tickets.DAL.Data.Context;
using Tickets.DAL.Data.Models;
using Tickets.DAL.Repos.Developers;
using Tickets.DAL.Repos.Tickets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tickets.BL.Managers.Tickets;

public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo _Context;
    private readonly IDevelopersRepo _developerRepo;
    public TicketsManager(ITicketsRepo Ticketcontext, IDevelopersRepo developersRepo)
    {
        _Context = Ticketcontext;
        _developerRepo = developersRepo;
    }

    public int Create(TicketDto ticket)
    {
        var newticket = _Context.AddTicket(
            new Ticket
            {
                DepartmentId = ticket.DepartmentId,
                Title = ticket.Title,
                Description = ticket.Description,
            }
            );
        _Context.SaveChanges();
        return newticket?.Entity.Id ?? -1;
    }

    public bool Delete(int id)
    {
        _Context.RemoveById(id);
        return _Context.SaveChanges()>0;

    }

    public IEnumerable<TicketgetallDto> GetAll()
    {
        var TicketfromDB = _Context.GetAll();
        return TicketfromDB.Select(d=>new TicketgetallDto(Id:d.Id,Title:d.Title,Description:d.Description,DevelopersCount:d.Developer!.Count));

    }

    private TicketgetallDto MapTicketDto(Ticket t)//for getbyid
    {
        return new TicketgetallDto(t.Id, t.Description, t.Title, t.Developer.Count);
    }
    public TicketgetallDto? GetById(int id)
    {
        Ticket? ticket=_Context.GetTicket(id);
        if(ticket==null) return null;
        return MapTicketDto(ticket);
    }

    public TicketgetallDto? EditDevelopers(int id, InsertdevelopersDto developers)
    {
        Ticket? ticket = _Context.GetTicket(id);
        if(ticket==null) return null;
        ticket.Developer.Clear();

        ICollection<Developer> Developers = _developerRepo.GetByID(developers.TicketIDs).ToList();

      
        ticket.Developer = Developers;
        var newticketUpdated=MapTicketDto(ticket);

       _Context.SaveChanges();
        return newticketUpdated;
    }

    public bool Update(TicketUpdateDto ticket)
    {
        
        if(ticket==null) return false;
        _Context.UpdateTicket(new Ticket
        {
            Id = ticket.id,
            Description = ticket.Description,
            Title = ticket.Title,
            DepartmentId = ticket.DepartmentId,
            
        });
        return _Context.SaveChanges()>0;

       
    }

    
}
