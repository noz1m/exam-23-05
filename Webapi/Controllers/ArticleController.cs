using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController(IArticleService articleService)
{
    [HttpGet]
    public async Task<Response<List<Article>>> GetAllArticleAsync()
    {
        return await articleService.GetAllArticleAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Article>> GetByIdAsync(int id)
    {
        return await articleService.GetByIdAsync(id);
    }
    [HttpPost]
    public async Task<Response<string>> CreateAsync(Article article)
    {
        return await articleService.CreateAsync(article);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Article article)
    {
        return await articleService.UpdateAsync(article);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        return await articleService.DeleteAsync(id);
    }
}
