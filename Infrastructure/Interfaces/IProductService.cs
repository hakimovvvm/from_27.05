using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<Response<string>> AddProductAsync(ProductDTO product);
    Task<Response<string>> UpdateProductAsync(ProductDTO product);
    Task<Response<string>> DeleteProductAsync(int id);
    Task<Response<ProductDTO?>> GetProductAsync(int id);
    Task<Response<List<ProductDTO>>> GetProductsAsync();
}
