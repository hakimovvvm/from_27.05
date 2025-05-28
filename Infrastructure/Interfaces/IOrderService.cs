using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IOrderService
{
    Task<Response<string>> AddOrderAsync(OrderDTO order, OrderDetailDTO orderDetailDTO);
    Task<Response<string>> UpdateOrderAsync(OrderDTO order, OrderDetailDTO orderDetailDTO);
    Task<Response<string>> DeleteOrderAsync(int id);
    Task<Response<OrderDTO>> GetOrderAsync(int id);
    Task<Response<List<OrderDTO>>> GetOrdersAsync();
}
