namespace API.DTOs;

public class ProductToAddDto
{
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public float Price { get; set; }
    public string ProductImagePath { get; set; }
    public int[] CustomersProducts { get; set; }
}
