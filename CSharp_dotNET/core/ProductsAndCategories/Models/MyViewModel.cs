#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategories.Models;

public class MyViewModel
{
    public Product? Product { get; set; }
    public List<Product> AllProducts { get; set; }
    public List<Product> NotProducts { get; set; }

    public Category? Category { get; set; }
    public List<Category> AllCategory { get; set; }
    public List<Category> CategoryNotChosen { get; set; }

    public KnownCategory Known { get; set; }
    public List<KnownCategory> AllKnownCategories { get; set; }
}