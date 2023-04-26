using System.ComponentModel.DataAnnotations.Schema;

namespace task1.API.Data.Models;

public class Instructor
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? SSN { get; set; }
    public int? Age { get; set; }
    public string? Address { get; set;}
    public double? Salary { get; set; }
    public DateTime? DOB { get; set;}
    public string? Password { get; set;}
    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }
    public virtual Department? Department { get; set; }
  

}
