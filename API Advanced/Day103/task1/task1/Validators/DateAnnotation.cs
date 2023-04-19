using System.ComponentModel.DataAnnotations;

namespace task1.Validators;

public class DateAnnotation:ValidationAttribute
{
    public override bool IsValid(object? value) => value is DateTime date && date < DateTime.Now;
   
}
