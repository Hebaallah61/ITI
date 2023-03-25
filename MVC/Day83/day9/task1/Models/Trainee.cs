using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace task1.Models
{
    public class Trainee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Enter Email....")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        [Required]
        public string MobileNo { get; set; }
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date")]
        public DateTime Birthdate { get; set; }

        [ForeignKey("Track")]
        public int TID { get; set; }
        [ForeignKey("Course")]
        public int CID { get; set; }
        public Course Course { get; set; }
        public Track Track { get; set; }
    }
    public enum Gender
    {
        Female,Male
    }
}
