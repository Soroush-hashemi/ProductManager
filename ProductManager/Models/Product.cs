using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models;
public class Product
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public int Price { get; set; }
}