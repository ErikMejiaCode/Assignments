#pragma warning disable CS8618
namespace DojoSurveyWithValidations.Models;
using System.ComponentModel.DataAnnotations;
public class User
{
    [MinLength(2)]
    [Required]
    public string Name {get;set;}
    [Required]
    public string Location {get;set;}
    [Required]
    public string Language {get;set;}
    [MinLength(20)]
    public string? Comment {get;set;}
}
