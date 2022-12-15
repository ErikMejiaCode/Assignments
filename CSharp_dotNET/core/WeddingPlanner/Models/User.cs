#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters in length.")]
    public string Password { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [Display(Name = "Confirm Password")]
    public string Confirm { get; set; }


    //This is for the One to Many 
    public List<Wedding> Listings { get; set;} = new List<Wedding>();

    //This is for the Many to Many 
    public List<Association> Attendees { get; set; } = new List<Association>();
    
}


//Custom validator used to prevent same email from being registered as a user more than once. 
public class UniqueEmailAttribute : ValidationAttribute
{
    // Call upon the protected IsValid method
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Email is required.");
        }
        //this is our connection to our database.
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if (_context.Users.Any(e => e.Email == value.ToString()))
        {
            //If it matches, throw error
            return new ValidationResult("Email already registered");
        }
        else
        {
            //Passed validations
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}