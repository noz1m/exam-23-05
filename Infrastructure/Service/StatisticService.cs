using System.IO.Pipelines;
using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;
namespace Infrastructure.Service;

public class StatisticService(DataContext context) : IStatisticService
{
    public async Task<Response<List<Comment>>> GetArticleClapsCountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Response<List<Comment>>> GetArticleRecentCommentsAsync()
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from comments
                    where articleId = @ArticleId
                    order by createdAt desc
                    limit 5";
        var result =  await connection.QueryAsync<Comment>(sql);
        return result == null
            ? new Response<Comment>("Comment not found", HttpStatusCode.NotFound)
            : new Response<Comment>(result.ToList(), "Comment found");
    }
    public async Task<Response<List<Article>>> GetRecentArticlesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Response<List<Article>>> GetUserArticlesAsync(int userId)
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from articles where UserId = @id";
        var result = await connection.QueryAsync<Article>(sql, new { UserId = userId });
        return result == null
            ? new Response<List<Article>>("Article not founded", HttpStatusCode.NotFound)
            : new Response<List<Article>>(result.ToList(), "Article found");
    }

    public async Task<Response<List<User>>> GetUserStatsAsync()
    {
        throw new NotImplementedException();
    }
}
