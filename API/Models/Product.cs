namespace API.Models;

public class Product : Base
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public float Price { get; set; }
    public string ProductImagePath { get; set; }
    public ICollection<CustomersProducts> CustomersProducts { get; set; }
}
