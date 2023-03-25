using System.ComponentModel.DataAnnotations;

namespace task1.Models
{
    public class Track
    {
        [Key]
     public int ID { get; set; }
        [Required]
     public string Name { get; set; }
        [Required]
     public string Description { get; set; }

     public List<Trainee> Trainees { get; set; }

    }
}
