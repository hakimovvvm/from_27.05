using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<Response<string>> AddCustomerAsync(CustomerDTO customer);
    Task<Response<string>> UpdateCustomerAsync(CustomerDTO customer);
    Task<Response<string>> DeleteCustomerAsync(int id);
    Task<Response<CustomerDTO?>> GetCustomerAsync(int id);
    Task<Response<List<CustomerDTO>>> GetCustomersAsync();
}
