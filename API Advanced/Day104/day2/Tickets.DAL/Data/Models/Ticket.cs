using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Data.Models;

public class Ticket
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Developer>? Developer { get; set; }=new HashSet<Developer>();
    
   
}
