using Microsoft.AspNetCore.Mvc;

namespace ProductManager.Controllers;
public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}