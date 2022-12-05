#pragma warning disable CS8618
namespace FOrmSubmission.Models;
using System.ComponentModel.DataAnnotations;
public class User
{
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
    [Required]
    public string Name {get;set;}
    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string Email {get;set;}
    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime DateOfBirth {get;set;}
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
    public string Password {get;set;}
    [Required]
    [PrimeNumber]
    [OddNumber]
    public int OddNumber {get;set;}
}


public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value > DateTime.Now)
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Date od Birth must be in the past");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}

public class OddNumberAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (((int)value) % 2 == 0)
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Favorite odd number must be an odd number");
        }
        else if (((int)value) <= 1)
        {
            //we return an error message in ValidationResult we want to render    
            return new ValidationResult("Must be greater than 1.");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}

public class PrimeNumberAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        int n = ((int)value);
        int a = 0;
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                a++;
            }
        }
        if (a == 2) {
            return ValidationResult.Success;
        }
        else 
        {
            return new ValidationResult("Must be a prime number.");
        }






        // IEnumerable<int> PrimeInt = Enumerable.Range(2, ((int)value)-1);

        // if (((int)value) <= 1)
        // {
        //     // we return an error message in ValidationResult we want to render    
        //     return new ValidationResult("Must be greater than 1.");
        // }
        // else if (((int)value) % 2 != 0)
        // {
        //     return new ValidationResult("Must be a prime number.");
        // }
        // else if(((int)value) % ((int)value)-1 != 0) 
        // {
        //     return new ValidationResult("Must be a prime number.");
        // }
        // else
        // {
        //     // Otherwise, we were successful and can report our success  
        //     return ValidationResult.Success;
        // }
    }
}