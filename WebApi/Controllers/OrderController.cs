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
    public async Task<Response<OrderDTO>> GetOrderByIdAsync(int id)
    {
        return await orServ.GetOrderAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> AddOrderAsync([FromBody]OrderDTO Order, [FromQuery]OrderDetailDTO orderDetailDTO)
    {
        return await orServ.AddOrderAsync(Order, orderDetailDTO);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateOrderAsync([FromBody]OrderDTO Order,[FromQuery] OrderDetailDTO orderDetailDTO)
    {
        return await orServ.UpdateOrderAsync(Order, orderDetailDTO);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteOrderAsync(int id)
    {
        return await orServ.DeleteOrderAsync(id);
    }
}
