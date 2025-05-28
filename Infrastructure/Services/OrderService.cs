using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class OrderService(DataContext context) : IOrderService
{
    public async Task<Response<string>> AddOrderAsync(OrderDTO order, OrderDetail orderDetail)
    {
        var newOr = new Order
        {
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            TotalAmount = orderDetail.Quantity * orderDetail.Price
        };
        await context.Orders.AddAsync(newOr);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Success");
    }

    public async Task<Response<string>> DeleteOrderAsync(int id)
    {
        var order = await context.Orders.FindAsync(id);
        if (order == null)
        {
            return new Response<string>("order not found", HttpStatusCode.NotFound);
        }

        context.Orders.Remove(order);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>("Success", null);
    }

    public async Task<Response<OrderDTO?>> GetOrderAsync(int id)
    {
        var order = await context.Orders.FindAsync(id);
        if (order == null)
        {
            return new Response<OrderDTO?>("order not found", HttpStatusCode.NotFound);
        }

        var result = new OrderDTO
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount
        };
        return result == null
        ? new Response<OrderDTO?>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<OrderDTO?>("success", result);
    }




    public async Task<Response<List<OrderDTO>>> GetOrdersAsync()
    {
        var orders = await context.Orders.ToListAsync();
        var result = orders.Select(o => new OrderDTO
        {
            Id = o.Id,
            CustomerId = o.CustomerId,
            OrderDate = o.OrderDate,
            TotalAmount = o.TotalAmount
        }).ToList();
        return result == null
        ? new Response<List<OrderDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<OrderDTO>>("success", result);
    }

    public async Task<Response<string>> UpdateOrderAsync(OrderDTO order, OrderDetail orderDetail)
    {
        var or = await context.Orders.FindAsync(order.Id);
        if (or == null)
        {
            return new Response<string>("order not found", HttpStatusCode.NotFound);
        }

        or.CustomerId = order.CustomerId;
        or.OrderDate = order.OrderDate;
        or.TotalAmount = orderDetail.Quantity * orderDetail.Price;

        var res = await context.SaveChangesAsync();
        return res == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "success");
    }

}
