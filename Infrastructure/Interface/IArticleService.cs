using Domain.Entities;
using Domain.ApiResponse;
namespace Infrastructure.Interface;

public interface IArticleService
{
    public Task<Response<List<Article>>> GetAllArticleAsync();
    public Task<Response<Article>> GetByIdAsync(int id);
    public Task<Response<string>> CreateAsync(Article articles);
    public Task<Response<string>> UpdateAsync(Article articles);
    public Task<Response<string>> DeleteAsync(int id);
}
