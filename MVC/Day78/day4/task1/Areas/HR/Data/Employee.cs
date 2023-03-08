using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace task1.Areas.HR.Data
{
    [Table("EmployeeInfo")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Your Name Please")]
        [MaxLength(30, ErrorMessage = "Too long Name chararacters!!!!!!")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Your User Name Please")]
        [MaxLength(30, ErrorMessage = "Too long Name chararacters!!!!!!")]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "You Must Enter Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EnumDataType(typeof(gender))]
        public gender Gender { get; set; }
        public decimal Salary { get; set; }
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Join Date")]
        public DateTime joinDate { get; set; }
        [Required(ErrorMessage = "Enter Email....")]
        [DataType(DataType.EmailAddress)]
        
        public string email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string phoneNum { get; set; }

    }

    public enum gender
    {
        MALE, Female
    }
}