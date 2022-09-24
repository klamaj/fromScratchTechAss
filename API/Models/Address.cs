namespace API.Models;

public class Address : Base
{
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZIPCode { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
}
