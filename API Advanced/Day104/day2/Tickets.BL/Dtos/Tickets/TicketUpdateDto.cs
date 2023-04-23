using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.BL.Dtos.Tickets;


public record TicketUpdateDto(int id,string? Title, string? Description, int DepartmentId);

