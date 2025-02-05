using Microsoft.AspNetCore.Mvc;

namespace ProductManager.Views.Shared.Components.GetList;
public class GetListViewComponent : ViewComponent
{
    private readonly ProductDbContext _productDbContext;
    public GetListViewComponent(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public IViewComponentResult Invoke()
    {
        var Product = _productDbContext.Products.ToList();

        return View(Product);
    }
}