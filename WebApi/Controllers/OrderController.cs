using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<OrderDTO>>> GetOrdersAsync()
    {
        return await orServ.GetOrdersAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<OrderDTO?>> GetOrderByIdAsync(int id)
    {
        return await orServ.GetOrderAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> GetOrdersAsync(OrderDTO Order, OrderDetail orderDetail)
    {
        return await orServ.AddOrderAsync(Order, orderDetail);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateOrderAsync(OrderDTO Order, OrderDetail orderDetail)
    {
        return await orServ.UpdateOrderAsync(Order, orderDetail);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteOrderAsync(int id)
    {
        return await orServ.DeleteOrderAsync(id);
    }
}
