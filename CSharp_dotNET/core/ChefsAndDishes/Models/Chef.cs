#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsAndDishes.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set;}
    [Required]
    public string FirstName { get; set;}
    [Required]
    public string LastName { get; set;}
    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime DateOfBirth { get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    [AtLeast18]
    public int Age 
    { 
        get 
            {
                DateTime now = DateTime.Today;
                int age = now.Year - DateOfBirth.Year;
                if (DateOfBirth > now.AddYears(-age)) age--;
                return age;
            }
    }

    //Navigation Property!
    public List<Dish> AllDishes {get; set;} = new List<Dish>();
}


//custom validation used where dates used must be in the past.
public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value > DateTime.Now)
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Date must be in the past.");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}

//custom validation used to validate users are at least 18 years of age 
public class AtLeast18Attribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((int)value < 18)
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("You must be at least 18 to be added as a chef.");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}