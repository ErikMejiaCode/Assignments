#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId {get; set;}

    [Required]
    [Display(Name = "Wedder One")]
    public string WedderOne {get; set;}

    [Required]
    [Display(Name = "Wedder Two")]
    public string WedderTwo {get; set;}

    [FutureDate]
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Wedding Date")]
    public DateTime DateOfWedding {get; set;}

    [Required]
    public string Address {get; set;}


    //This is for the One to Many
    public int UserId { get; set;}
    public User? Creator { get; set;}

    //This is for the Many to Many
    public List<Association> Listings { get; set; } = new List<Association>();

}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value < DateTime.Now)
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Date must be in the Future.");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}