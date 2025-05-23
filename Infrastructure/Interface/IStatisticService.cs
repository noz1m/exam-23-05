using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Service;

namespace Infrastructure.Interface;

public interface IStatisticService
{
    public Task<Response<List<Article>>> GetUserArticlesAsync(int userId);
    public Task<Response<List<Comment>>> GetArticleRecentCommentsAsync();
    public Task<Response<List<Comment>>> GetArticleClapsCountAsync();
    public Task<Response<List<Article>>> GetRecentArticlesAsync();
    public Task<Response<List<User>>> GetUserStatsAsync();
}
