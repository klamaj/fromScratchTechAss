using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AssignProductsController : BaseApiController
{
    private readonly DatabaseContext _context;
    public AssignProductsController(DatabaseContext context)
    {
        _context = context;
    }

    // Assign
    [HttpPost("assign")]
    public async Task<ActionResult<CustomersProducts>> AddAssignedProducts(CustomersProducts val)
    {
        await _context.CustomersProducts.AddAsync(val);
        await _context.SaveChangesAsync();

        return Ok(val);
    }

    // Delete
    [HttpDelete("delete")]
    public async Task<ActionResult<CustomersProducts>> DeleteAssignedProducts(CustomersProducts val)
    {
        _context.CustomersProducts.Remove(val);
        await _context.SaveChangesAsync();

        return Ok(val);
    }
}
