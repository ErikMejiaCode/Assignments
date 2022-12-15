#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class Association
{
    [Key]
    public int AssociationId { get; set; }

    //Track Ids of our joining models
    public int UserId { get; set; }
    public int WeddingId { get; set; }

    //Navigation properties
    public User? User { get; set; }
    public Wedding? Wedding { get; set; }


    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}