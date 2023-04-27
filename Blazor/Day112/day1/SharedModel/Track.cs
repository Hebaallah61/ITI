using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel;

public class Track
{
    public int Id { get; set; }
    [Required]
    [StringLength(10, ErrorMessage = "Too long Name!!")]
    public string? Name { get; set; }
    [Required]
    [StringLength(35, ErrorMessage = "Too long Description!!")]
    public string? Description { get; set; }
    public ICollection<Trainee>? Trainees { get; set;}
}
