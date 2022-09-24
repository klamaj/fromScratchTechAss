using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AddressController : BaseApiController
{
    private readonly IGenericRepository<Address> _addressRepo;
    private readonly DatabaseContext _context;
    public AddressController(IGenericRepository<Address> addressRepo, 
        DatabaseContext context)
    {
        _context = context;
        _addressRepo = addressRepo;
    }

    // AddAddress
    [HttpPost("add")]
    public async Task<ActionResult<Address>> AddAddress(Address val)
    {
        if (CheckAddress(val)) return Ok(await _addressRepo.Add(val));
        return BadRequest("Address already exists");
    }

    // UpdateAddress
    [HttpPut("update")]
    public async Task<ActionResult<Address>> UpdateAddres(Address val)
    {
        return await _addressRepo.Update(val);
    }

    // DeleteAddress
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Address>> DeleteAddress(int id)
    {
        return await _addressRepo.Delete(id);
    }

    // Check if address already exists
    private bool CheckAddress(Address val)
    {
        var addresses = _context.Addresses.Where(a => a.CustomerId == val.CustomerId).ToList();

        foreach (var item in addresses)
        {
            if (item == val) return false;
        }

        return true;
    }
}
