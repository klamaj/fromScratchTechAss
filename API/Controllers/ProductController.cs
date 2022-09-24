using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductController : BaseApiController
{
    private readonly IGenericRepository<Product> _productRepo;
    public ProductController(IGenericRepository<Product> productRepo)
    {
        _productRepo = productRepo;
    }

    // GetProducts
    [HttpGet("get")]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
        return Ok(await _productRepo.ListAllAsync());
    }

    // GetProductById
    [HttpGet("get/{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        return Ok(await _productRepo.GetByIdAsync(id));
    }

    // AddProduct
    [HttpPost("add")]
    public async Task<ActionResult<Product>> AddProduct(Product val)
    {
        return Ok(await _productRepo.Add(val));
    }

    // UpdateProduct
    [HttpPut("update")]
    public async Task<ActionResult<Product>> UpdateProduct(Product val)
    {
        return Ok(await _productRepo.Update(val));  
    }

    // DeleteProduct
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        return Ok(await _productRepo.Delete(id));
    }
}
