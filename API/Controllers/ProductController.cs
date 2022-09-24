using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductController : BaseApiController
{
    private readonly IGenericRepository<Product> _productRepo;
    private readonly DatabaseContext _context;
    public ProductController(IGenericRepository<Product> productRepo,
        DatabaseContext context)
    {
        _context = context;
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
    public async Task<ActionResult<Product>> AddProduct(ProductToAddDto val)
    {
        Product res = await _productRepo.Add(SetProduct(val));

        if (res != null)
        {
            foreach(var item in val.CustomersProducts)
            {
                var assignedProduct = new CustomersProducts
                {
                    ProductId = res.ID,
                    CustomerId = item
                };

                await _context.CustomersProducts.AddAsync(assignedProduct);
            }

            await _context.SaveChangesAsync();
        }

        return Ok(res);
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

    // SetProduct
    private Product SetProduct(ProductToAddDto val)
    {
        return new Product 
        {
            ProductName = val.ProductName,
            ProductDescription = val.ProductDescription,
            Price = val.Price,
            ProductImagePath = val.ProductImagePath
        };
    }
}