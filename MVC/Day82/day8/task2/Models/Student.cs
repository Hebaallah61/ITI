using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace task2.Models
{
    public enum Gender
    {
        Female, Male
    }
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [MaxLength(11)]
        public string phoneNum { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date")]
        public DateTime? Birthdate { get; set; }

        public List<Course> Courses { get; set; }
    }
       
}
