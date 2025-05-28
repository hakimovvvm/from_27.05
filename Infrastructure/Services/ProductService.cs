using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService(DataContext context) : IProductService
{
    public async Task<Response<string>> AddProductAsync(ProductDTO Product)
    {
        var newPr = new Product
        {
            Name = Product.Name,
            Description = Product.Description,
            Price = Product.Price
        };
        await context.Products.AddAsync(newPr);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Success");
    }

    public async Task<Response<string>> DeleteProductAsync(int id)
    {
        var Product = await context.Products.FindAsync(id);
        if (Product == null)
        {
            return new Response<string>("Product not found", HttpStatusCode.NotFound);
        }

        context.Products.Remove(Product);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Success");
    }

    public async Task<Response<ProductDTO?>> GetProductAsync(int id)
    {
        var Product = await context.Products.FindAsync(id);
        if (Product == null)
        {
            return new Response<ProductDTO?>("Product not found", HttpStatusCode.NotFound);
        }

        var result = new ProductDTO
        {
            Id = Product.Id,
            Name = Product.Name,
            Description = Product.Description,
            Price = Product.Price
        };
        return result == null
        ? new Response<ProductDTO?>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<ProductDTO?>("success", result);
    }

    public async Task<Response<List<ProductDTO>>> GetProductsAsync()
    {
        var Products = await context.Products.ToListAsync();
        var result = Products.Select(Pr => new ProductDTO
        {
            Id = Pr.Id,
            Name = Pr.Name,
            Description = Pr.Description,
            Price = Pr.Price
        }).ToList();
        return result == null
        ? new Response<List<ProductDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<ProductDTO>>("success", result);
    }


    public async Task<Response<string>> UpdateProductAsync(ProductDTO Product)
    {
        var pr  = await context.Products.FindAsync(Product.Id);
        if (pr == null)
        {
            return new Response<string>("Product not found", HttpStatusCode.NotFound);
        }

        pr.Name = Product.Name;
        pr.Description = Product.Description;
        pr.Price = Product.Price;

        var res = await context.SaveChangesAsync();
        return res == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "success");
    }
}
