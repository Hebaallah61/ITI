using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.Dtos.Developers;
using Tickets.BL.Dtos.Tickets;

namespace Tickets.BL.Managers.Tickets;

public interface ITicketsManager
{
    IEnumerable<TicketgetallDto> GetAll();
    TicketgetallDto? GetById(int id);
    bool Update (TicketUpdateDto ticket);
    bool Delete(int id);
    int Create(TicketDto  ticket);
    TicketgetallDto? EditDevelopers(int id,InsertdevelopersDto developers);
}
