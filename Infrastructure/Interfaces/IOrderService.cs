using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IOrderService
{
    Task<Response<string>> AddOrderAsync(OrderDTO order, OrderDetail orderDetail);
    Task<Response<string>> UpdateOrderAsync(OrderDTO order, OrderDetail orderDetail);
    Task<Response<string>> DeleteOrderAsync(int id);
    Task<Response<OrderDTO?>> GetOrderAsync(int id);
    Task<Response<List<OrderDTO>>> GetOrdersAsync();
}
