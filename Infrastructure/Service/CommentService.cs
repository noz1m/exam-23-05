using System.IO.Pipelines;
using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;
namespace Infrastructure.Service;

public class CommentService(DataContext context) : ICommentService
{
    public async Task<Response<List<Comment>>> GetAllCommentAsync()
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from comments";
        var result = await connection.QueryAsync<Comment>(sql);
        return result == null
            ? new Response<List<Comment>>("Comment not founded", HttpStatusCode.NotFound)
            : new Response<List<Comment>>(result.ToList(), "Comment found");
    }
    public async Task<Response<Comment>> GetByIdAsync(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from comments where id = @id";
        var result = await connection.QueryFirstOrDefaultAsync<Comment>(sql, new { id });
        return result == null
            ? new Response<Comment>("Comment not found", HttpStatusCode.NotFound)
            : new Response<Comment>(result, "Comment found");
    }
    public async Task<Response<string>> CreateAsync(Comment comment)
    {
        using var connection = await context.GetConnection();
        var sql = @"insert into comments(ArticleId,UserId,Content,CreatedAt)
                    values (@ArticleId,@UserId,@Content,@CreatedAt)";
        var result = await connection.ExecuteAsync(sql, comment);
        return result == 0
            ? new Response<string>("Comment not created", HttpStatusCode.NotFound)
            : new Response<string>(null, "Comment created");

    }
    public async Task<Response<string>> UpdateAsync(Comment comment)
    {
        using var connection = await context.GetConnection();
        var sql = @"update comments set ArticleId=@ArticleId,UserId=@UserId,Content=@Content,CreatedAt=@CreatedAt
                    where id = @id";
        var result = await connection.ExecuteAsync(sql, comment);
        return result == 0
            ? new Response<string>("Comment not updated", HttpStatusCode.NotFound)
            : new Response<string>(null, "Comment updated");
    }
    public async Task<Response<string>> DeleteAsync(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"delete from comments where id = @id";
        var result = await connection.ExecuteAsync(sql, new { id });
        return result == 0
            ? new Response<string>("Comment not deleted", HttpStatusCode.NotFound)
            : new Response<string>(null, "Comment deleted");
    }
}
