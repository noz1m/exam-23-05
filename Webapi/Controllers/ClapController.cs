using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClapController(IClapService clapService)
{
    [HttpGet]
    public async Task<Response<List<Clap>>> GetAllClapAsync()
    {
        return await clapService.GetAllClapAsync();
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Clap>> GetByIdAsync(int id)
    {
        return await clapService.GetByIdAsync(id);
    }
    [HttpPost]
    public async Task<Response<string>> CreateAsync(Clap clap)
    {
        return await clapService.CreateAsync(clap);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Clap clap)
    {
        return await clapService.UpdateAsync(clap);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        return await clapService.DeleteAsync(id);
    }
}
