using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Data.Models;

public class Developer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Ticket>? Developers { get; set; }=new HashSet<Ticket>();
}
