#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FirstConnection.Models;

public class Pet
{
    [Key]
    [Required]
    public string Name {get;set;}
    [Required]
    public string Type {get;set;}
    [Required]
    public int Age {get;set;}
    [Required]
    public bool HasFur {get;set;}
}