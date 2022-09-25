using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerController : BaseApiController
{
    private readonly IGenericRepository<Customer> _customerRepo;
    private readonly IGenericRepository<Address> _addressRepo;
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public CustomerController(IGenericRepository<Customer> customerRepo, 
        IGenericRepository<Address> addressRepo, 
        DatabaseContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
        _addressRepo = addressRepo;
        _customerRepo = customerRepo;
    }

    // GetCustomersList
    [HttpGet("get")]
    public async Task<ActionResult<IReadOnlyList<CustomerToReturnDto>>> GetCustomersList()
    {
        var customers = await _customerRepo.ListAllAsync();
        return Ok(_mapper.Map<IReadOnlyList<Customer>, IReadOnlyList<CustomerToReturnDto>>(customers));
    }

    // GetCustomerById
    [HttpGet("get/{id}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        return Ok(await _customerRepo.GetByIdAsync(id));
    }

    // AddCustomer
    [HttpPost("add")]
    public async Task<ActionResult<Customer>> AddCustomer(CustomerToAddDto val)
    {
        Customer res = await _customerRepo.Add(SetCustomer(val));

        if(res != null)
        {
            foreach(var address in val.Addresses)
            {
                address.CustomerId = res.ID;
                await _addressRepo.Add(address);
            }

            foreach(var item in val.CustomersProducts)
            {
                var productAssigned = new CustomersProducts
                {
                    ProductId = item,
                    CustomerId = res.ID
                };

                await _context.CustomersProducts.AddAsync(productAssigned);
            }

            await _context.SaveChangesAsync();
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

    // SetCustomer
    private Customer SetCustomer(CustomerToAddDto val)
    {
        return new Customer
        {
            FirstName = val.FirstName,
            LastName = val.LastName,
            Email = val.Email,
            PhoneNumber = val.PhoneNumber,
            Addresses = val.Addresses
        };
    }
}
