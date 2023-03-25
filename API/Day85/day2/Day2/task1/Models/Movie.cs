using System.ComponentModel.DataAnnotations;

namespace task1.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Rate { get; set; }
        [Required]
        public string Producer { get; set; }
        public virtual LinkedList<Actor> Actors { get; set;}=new LinkedList<Actor>();
    }
}
