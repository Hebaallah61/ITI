using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.Dtos.Tickets;

namespace Tickets.BL.Dtos.Departments;

public record DepartmentsreadDto(int Id,string? Name, ICollection<TicketgetallDto> Tickets);
