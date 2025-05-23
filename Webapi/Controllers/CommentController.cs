using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController(ICommentService commentService)
{
    [HttpGet]
    public async Task<Response<List<Comment>>> GetAllCommentAsync()
    {
        return await commentService.GetAllCommentAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Comment>> GetByIdAsync(int id)
    {
        return await commentService.GetByIdAsync(id);
    }
    [HttpPost]
    public async Task<Response<string>> CreateAsync(Comment comment)
    {
        return await commentService.CreateAsync(comment);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Comment comment)
    {
        return await commentService.UpdateAsync(comment);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        return await commentService.DeleteAsync(id);
    }
}
