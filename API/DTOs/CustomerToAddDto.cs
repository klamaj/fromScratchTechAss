using API.Models;

namespace API.DTOs;

public class CustomerToAddDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public int[] CustomersProducts { get; set; }
}
