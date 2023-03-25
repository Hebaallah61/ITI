using System.ComponentModel.DataAnnotations;

namespace task1.Models
{
    public class Course
    {
        [Key]
    public int ID { get; set; }
        [Required]
    public string Topic { get; set; }

    public int Grade { get; set; }

    public List<Trainee> Trainees { get; set; }
    }
}
