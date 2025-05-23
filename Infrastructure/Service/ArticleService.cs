using System.IO.Pipelines;
using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;
namespace Infrastructure.Service;

public class ArticleService(DataContext context) : IArticleService
{
    public async Task<Response<List<Article>>> GetAllArticleAsync()
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from articles";
        var result = await connection.QueryAsync<Article>(sql);
        return result == null
            ? new Response<List<Article>>("Article not founded", HttpStatusCode.NotFound)
            : new Response<List<Article>>(result.ToList(), "Article found");
    }
    public async Task<Response<Article>> GetByIdAsync(int id)
    {
        using var connection = await context.GetConnection();

        var sql = @"select * from articles where id = @id";
        var result = await connection.QueryFirstOrDefaultAsync<Article>(sql, new { id });
        return result == null
            ? new Response<Article>("Article not found", HttpStatusCode.NotFound)
            : new Response<Article>(result, "Article found");
    }
    public async Task<Response<string>> CreateAsync(Article article)
    {
        using var connection = await context.GetConnection();
        // var check = @"select * from users where id = @userId";
        // var checkout = await connection.QueryFirstAsync<User>(check, new { userId = article.UserId });
        // if (checkout == null)
        // {
        //     return checkout;
        // }
        var sql = @"insert into articles(UserId,Title,Content,Description,CreatedAt,Status)
                    values (@UserId,@Title,@Content,@Description,@CreatedAt,@Status)";
        var result = await connection.ExecuteAsync(sql, article);
        return result == 0
            ? new Response<string>("Article not created", HttpStatusCode.NotFound)
            : new Response<string>(null, "Article created");

    }
    public async Task<Response<string>> UpdateAsync(Article article)
    {
        using var connection = await context.GetConnection();
        var sql = @"update articles set UserId=@UserId,Title=@Title,Content=@Content,Description=@Description,CreatedAt=@CreatedAt,Status=@Status
                    where id = @id";
        var result = await connection.ExecuteAsync(sql, article);
        return result == 0
            ? new Response<string>("Article not updated", HttpStatusCode.NotFound)
            : new Response<string>(null, "Article updated");
    }
    public async Task<Response<string>> DeleteAsync(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"delete from articles where id = @id";
        var result = await connection.ExecuteAsync(sql, new { id });
        return result == 0
            ? new Response<string>("Article not deleted", HttpStatusCode.NotFound)
            : new Response<string>(null, "Article deleted");
    }
    
}
