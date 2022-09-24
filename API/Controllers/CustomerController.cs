using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerController : BaseApiController
{
    private readonly IGenericRepository<Customer> _customerRepo;
    public CustomerController(IGenericRepository<Customer> customerRepo)
    {
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
        return Ok(await _customerRepo.Add(val));
    }

    // UpdateCustomer
    [HttpPut("update")]
    public async Task<ActionResult<Customer>> UpdateCustomer(Customer val)
    {
        return Ok(await _customerRepo.Update(val));
    }

    // DeleteCustomer
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Customer>> DeleteCustomer(int id)
    {
        return Ok(await _customerRepo.Delete(id));
    }
    
}
