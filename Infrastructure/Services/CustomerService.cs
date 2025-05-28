using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CustomerService(DataContext context) : ICustomerService
{
    public async Task<Response<string>> AddCustomerAsync(CustomerDTO customer)
    {
        var newCm = new Customer
        {
            Name = customer.Name,
            Email = customer.Email,
            RegisteredOn = customer.RegisteredOn
        };
        await context.Customers.AddAsync(newCm);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Success");
    }

    public async Task<Response<string>> DeleteCustomerAsync(int id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            return new Response<string>("customer not found", HttpStatusCode.NotFound);
        }

        context.Customers.Remove(customer);
        var res = await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>("Some thing went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Success");
    }

    public async Task<Response<CustomerDTO?>> GetCustomerAsync(int id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            return new Response<CustomerDTO?>("customer not found", HttpStatusCode.NotFound);
        }

        var result = new CustomerDTO
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            RegisteredOn = customer.RegisteredOn
        };
        return result == null
        ? new Response<CustomerDTO?>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<CustomerDTO?>("success", result );
    }

    public async Task<Response<List<CustomerDTO>>> GetCustomersAsync()
    {
        var customers = await context.Customers.ToListAsync();
        var result = customers.Select(c => new CustomerDTO
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            RegisteredOn = c.RegisteredOn
        }).ToList();
        return result == null
        ? new Response<List<CustomerDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<CustomerDTO>>("success", result);
    }


    public async Task<Response<string>> UpdateCustomerAsync(CustomerDTO customer)
    {
        var c = await context.Customers.FindAsync(customer.Id);
        if (c == null)
        {
            return new Response<string>("customer not found", HttpStatusCode.NotFound);
        }

        c.Name = customer.Name;
        c.Email = customer.Email;
        c.RegisteredOn = customer.RegisteredOn;

        var res = await context.SaveChangesAsync();
        return res == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "success");
    }
}
