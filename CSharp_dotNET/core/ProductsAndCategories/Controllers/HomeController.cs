using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //Default index page used to display the product creation form in addition to a list of the products in the db
    [HttpGet("")]
    public IActionResult Index()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllProducts = _context.Products.ToList()
        };
        return View(MyModel);
    }

    //Post route used when a product is created. updates database and should shoot out validations. 
    [HttpPost("product/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            MyViewModel MyModel = new MyViewModel
            {
                AllProducts = _context.Products.ToList()
            };
            return View("Index", MyModel);
        }
    }

    //Category page used to display the category creation form in addition to a list of the categories in the db
    [HttpGet("categories")]
    public IActionResult Category()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllCategory = _context.Categories.ToList()
        };
        return View(MyModel);
    }

    //Post route used when a product is created. updates database and should shoot out validations. 
    [HttpPost("category/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Category");
        }
        else
        {
            MyViewModel MyModel = new MyViewModel
            {
                AllCategory = _context.Categories.ToList()
            };
            return View("Category", MyModel);
        }
    }

    //Path used to take you to ONE product using its ID and display the form including the categories 
    [HttpGet("products/{ProductId}")]
    public IActionResult ShowProduct(int ProductId)
    {
        {
            KnownCategory Known = new KnownCategory();
            Known.ProductId = ProductId;
            MyViewModel MyModels = new MyViewModel()
            {
                Known = Known,

                Product = _context.Products
                .Include(prod => prod.CategoriesKnown)
                .ThenInclude(cop => cop.Category)
                .FirstOrDefault(p => p.ProductId == ProductId),

                CategoryNotChosen = _context.Categories
                    .Include(category => category.ProductsWithCategory)
                    .Where(category => !category.ProductsWithCategory.Any(p => p.ProductId == ProductId))
                    .ToList(),
            };

            // ViewBag.Product = _context.Products
            //     .Include(prod => prod.CategoriesKnown)
            //     .ThenInclude(cop => cop.Category)
            //     .FirstOrDefault(p => p.ProductId == ProductId);
            // ViewBag.CategoryNotChosen = _context.Categories
            //         .Include(category => category.ProductsWithCategory)
            //         .Where(category => !category.ProductsWithCategory.Any(p => p.ProductId == ProductId))
            //         .ToList();
            return View("ShowProduct", MyModels);
        }

        // return View("ShowProduct");
    }


    //Path used to take you to ONE Category using its ID and display the form including the products 
    [HttpGet("categories/{CategoryId}")]
    public IActionResult ShowCategory(int CategoryId)
    {
        KnownCategory Known = new KnownCategory();
        Known.CategoryId = CategoryId;
        MyViewModel MyModels = new MyViewModel()
        {
            Known = Known,

            Category = _context.Categories
            .Include(cat => cat.ProductsWithCategory)
            .ThenInclude(p => p.Product)
            .FirstOrDefault(c => c.CategoryId == CategoryId),

            NotProducts = _context.Products
                .Include(product => product.CategoriesKnown)
                .Where(product => !product.CategoriesKnown.Any(ca => ca.CategoryId == CategoryId))
                .ToList(),
        };

        // ViewBag.Category = _context.Categories
        //     .Include(cat => cat.ProductsWithCategory)
        //     .ThenInclude(p => p.Product)
        //     .FirstOrDefault(c => c.CategoryId == CategoryId);
        // ViewBag.NotProducts = _context.Products
        //         .Include(product => product.CategoriesKnown)
        //         .Where(product => !product.CategoriesKnown.Any(ca => ca.CategoryId == CategoryId))
        //         .ToList();
        return View("ShowCategory", MyModels);
    }

    //Post route used in the one product page in order to add a category to the product 
    [HttpPost("associations/{ProductId}/create")]
    public IActionResult AddCategory(KnownCategory newKnownCategory, int ProductId)
    {
        newKnownCategory.ProductId = ProductId;
        if (ModelState.IsValid)
        {
            _context.Add(newKnownCategory);
            _context.SaveChanges();
            return RedirectToAction
            ("ShowProduct", new { ProductId = newKnownCategory.ProductId });
        }
        return View("ShowProduct", new { ProductId = newKnownCategory.ProductId });
    }


    //Post route used in the one category page in order to add a product to the product 
    [HttpPost("associations/product/{CategoryId}/create")]
    public IActionResult AddProduct(KnownCategory newKnownCategory, int CategoryId)
    {
        newKnownCategory.CategoryId = CategoryId;
        if (ModelState.IsValid)
        {
            _context.Add(newKnownCategory);
            _context.SaveChanges();
            return RedirectToAction
            ("ShowCategory", new { CategoryId = newKnownCategory.CategoryId });
        }
        return View("ShowCategory", new { CategoryId = newKnownCategory.CategoryId });
    }






    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
