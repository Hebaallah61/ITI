using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Topic { get; set; }
        [Range(0, 50)]
        public int grade { get; set; }
        [ForeignKey(nameof(Student))]
        public int cid { get; set; }
        public Student student { get; set; }
    }
}
