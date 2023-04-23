using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.BL.Dtos.Tickets;


public record TicketgetallDto(int Id,string? Title, string? Description, int DevelopersCount);

