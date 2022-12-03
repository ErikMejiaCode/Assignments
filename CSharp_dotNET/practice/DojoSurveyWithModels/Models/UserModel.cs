#pragma warning disable CS8618
namespace DojoSurveyWithModels;
using System.ComponentModel.DataAnnotations;
public class User
{
    [Required]
    public string Name {get;set;}
    [Required]
    public string Location {get;set;}
    [Required]
    public string Language {get;set;}
    public string? Comment {get;set;}
}
