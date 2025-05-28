using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService prServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<ProductDTO>>> GetProductsAsync()
    {
        return await prServ.GetProductsAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<ProductDTO?>> GetProductByIdAsync(int id)
    {
        return await prServ.GetProductAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> GetProductsAsync(ProductDTO Product)
    {
        return await prServ.AddProductAsync(Product);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateProductAsync(ProductDTO Product)
    {
        return await prServ.UpdateProductAsync(Product);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteProductAsync(int id)
    {
        return await prServ.DeleteProductAsync(id);
    }
}
