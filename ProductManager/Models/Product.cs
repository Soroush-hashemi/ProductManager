using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models;
public class Product
{
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    [Key]
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public int Price { get; set; }
}