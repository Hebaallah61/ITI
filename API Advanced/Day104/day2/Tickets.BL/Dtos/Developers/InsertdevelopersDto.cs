using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.BL.Dtos.Developers;

public record InsertdevelopersDto(int id, int[] TicketIDs);
