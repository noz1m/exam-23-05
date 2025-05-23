using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService)
{
    [HttpGet]
    public async Task<Response<List<User>>> GetAllUserAsync()
    {
        return await userService.GetAllUserAsync();
    }
    [HttpGet("{id:int}")]
    public async Task<Response<User>> GetByIdAsync(int id)
    {
        return await userService.GetByIdAsync(id);
    }
    [HttpPost]
    public async Task<Response<string>> CreateAsync(User user)
    {
        return await userService.CreateAsync(user);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(User user)
    {
        return await userService.UpdateAsync(user);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        return await userService.DeleteAsync(id);
     }
}
