namespace API.Models;

public class Customer : Base
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<CustomersProducts> CustomersProducts { get; set; }
}
