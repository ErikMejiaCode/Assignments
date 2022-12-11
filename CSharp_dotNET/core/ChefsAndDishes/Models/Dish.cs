#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsAndDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    [GreaterThan0]
    public int Calories { get; set; }
    [Required]
    [Range(1,5)]
    public int Tastiness { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //ID to be brought in from the Chef model
    public int ChefId { get; set;}

    //Navigation Properties - Stand in for us to access the particular information 
    public Chef? Chef { get; set;}
}

public class GreaterThan0Attribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        int CalorieCount = (int)value;
        if (CalorieCount > 0)
        {
            return ValidationResult.Success;
        } else {
            return new ValidationResult("Must be more than 0 Calories.");
        }
    }
}
