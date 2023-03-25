using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Gender gender{get;set;}
        [Required]
        public int Age { get; set;}
        [Required]
        public string Address{ get; set;}
        [Required]
        public int Salary { get; set;}
        public virtual Movie Movie { get; set;}
        [ForeignKey("Movie")]
        public int Mid { get; set; }

    }
        public enum Gender
        {
            Female,Male
        }
}
