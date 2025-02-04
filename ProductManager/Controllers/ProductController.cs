using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers;
[Route("Product")]
public class ProductController : Controller
{
    private readonly ProductDbContext _context;
    public ProductController(ProductDbContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("GetList")]
    public IActionResult GetList()
    {
        List<Product> products = _context.Products.ToList();
        return View(products);
    }


    [HttpGet("Detail/{id}")]
    public IActionResult Detail(int id)
    {
        Product product = GetProduct(id);
        return View(product);
    }

    [HttpGet("Add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("Add")]
    public IActionResult Add(string name, int price)
    {
        Product product = new Product(name, price);
        _context.Products.Add(product);
        _context.SaveChanges();

        return Redirect("../");
    }

    [HttpGet("Update/{id}")]
    public IActionResult Update(int id)
    {
        Product product = GetProduct(id);
        return View(product);
    }

    [HttpPost("Update/{id}")]
    public IActionResult Update(int id, string name, int price)
    {
        Product product = GetProduct(id);
        product.Name = name;
        product.Price = price;
        _context.Products.Update(product);
        _context.SaveChanges();

        return Redirect("../");
    }

    [HttpGet("Remove/{id}")]
    public IActionResult Remove(int id)
    {
        Product product = GetProduct(id);
        _context.Products.Remove(product);
        _context.SaveChanges();
        return Redirect("../");
    }

    private Product GetProduct(int id)
    {
        Product? product = _context.Products
            .FirstOrDefault(p => p.Id == id);

        return product;
    }
}