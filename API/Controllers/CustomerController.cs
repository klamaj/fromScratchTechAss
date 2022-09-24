using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerController : BaseApiController
{
    private readonly IGenericRepository<Customer> _customerRepo;
    private readonly IGenericRepository<Address> _addressRepo;
    private readonly DatabaseContext _context;

    public CustomerController(IGenericRepository<Customer> customerRepo, 
        IGenericRepository<Address> addressRepo, 
        DatabaseContext context)
    {
        _context = context;
        _addressRepo = addressRepo;
        _customerRepo = customerRepo;
    }

    // GetCustomersList
    [HttpGet("get")]
    public async Task<ActionResult<IReadOnlyList<Customer>>> GetCustomersList()
    {
        return Ok(await _customerRepo.ListAllAsync());
    }

    // GetCustomerById
    [HttpGet("get/{id}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        return Ok(await _customerRepo.GetByIdAsync(id));
    }

    // AddCustomer
    [HttpPost("add")]
    public async Task<ActionResult<Customer>> AddCustomer(Customer val)
    {
        Customer res = await _customerRepo.Add(val);

        if(res != null)
        {
            foreach(var address in val.Addresses)
            {
                address.CustomerId = res.ID;
                await _addressRepo.Add(address);
            }
        }

        return Ok(res);
    }

    // UpdateCustomer
    [HttpPut("update")]
    public async Task<ActionResult<Customer>> UpdateCustomer(Customer val)
    {
        var customer = await _customerRepo.Update(val);

        foreach(var item in val.Addresses)
        {
            await _addressRepo.Update(item);
        }

        return Ok(customer);
    }

    // DeleteCustomer
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Customer>> DeleteCustomer(int id)
    {
        return Ok(await _customerRepo.Delete(id));
    }
}
