using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entites;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService cServ) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<CustomerDTO>>> GetCustomersAsync()
    {
        return await cServ.GetCustomersAsync();
    }

    [HttpGet("Get by id")]
    public async Task<Response<CustomerDTO?>> GetCustomerByIdAsync(int id)
    {
        return await cServ.GetCustomerAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> GetCustomersAsync(CustomerDTO Customer)
    {
        return await cServ.AddCustomerAsync(Customer);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCustomerAsync(CustomerDTO Customer)
    {
        return await cServ.UpdateCustomerAsync(Customer);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCustomerAsync(int id)
    {
        return await cServ.DeleteCustomerAsync(id);
    }
}
