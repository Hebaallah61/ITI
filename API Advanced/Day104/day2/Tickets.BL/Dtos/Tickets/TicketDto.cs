using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.BL.Dtos.Tickets;

public record TicketDto(string? Title , string? Description , int DepartmentId );
