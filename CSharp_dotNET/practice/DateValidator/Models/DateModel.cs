#pragma warning disable CS8618
namespace DateValidator.Models;
using System.ComponentModel.DataAnnotations;

public class Date
{
    [Required(ErrorMessage ="Please select a date.")]
    [FutureDate]
    public DateTime DateValidation { get; set; }
}


public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value > DateTime.Now)
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Date must be prior to today. In the past!");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}