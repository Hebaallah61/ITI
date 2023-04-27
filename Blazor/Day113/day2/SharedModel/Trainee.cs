using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel;

public class Trainee
{
    public int Id { get; set; }
    [Required]
    [StringLength(15, ErrorMessage = "Too long Name!!")]
    public string? Name { get; set; }
    [Required]
    public  Gender gender { get; set; }
    [Required]
    public string? email { get; set; }
    [Required(ErrorMessage = "Mobile number is required")]
    [RegularExpression(@"^(\+?\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Invalid mobile number ex +91-1234567890")]
    public string? MobileNo { get; set; }
    [Required]
    public DateTime Birthdate { get; set; }
    [Required]
    public Graduated IsGraduated { get; set; }
    public int TrackId { get; set; }
    public Track? Track { get; set; }
    
}

public enum Gender
{
    Female,Male
}

public enum Graduated
{
    True,False
}
