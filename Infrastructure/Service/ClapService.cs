using System.IO.Pipelines;
using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;
namespace Infrastructure.Service;

public class ClapService(DataContext context) : IClapService
{
    public async Task<Response<List<Clap>>> GetAllClapAsync()
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from claps";
        var result = await connection.QueryAsync<Clap>(sql);
        return result == null
            ? new Response<List<Clap>>("Clap not founded", HttpStatusCode.NotFound)
            : new Response<List<Clap>>(result.ToList(), "Clap found");
    }
    public async Task<Response<Clap>> GetByIdAsync(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from claps where id = @id";
        var result = await connection.QueryFirstOrDefaultAsync<Clap>(sql, new { id });
        return result == null
            ? new Response<Clap>("Clap not found", HttpStatusCode.NotFound)
            : new Response<Clap>(result, "Clap found");
    }
    public async Task<Response<string>> CreateAsync(Clap clap)
    {
        using var connection = await context.GetConnection();
        var sql = @"insert into claps(ArticleId,UserId,Count,CreatedAt)
                    values (@ArticleId,@UserId,@Count,@CreatedAt)";
        var result = await connection.ExecuteAsync(sql, clap);
        return result == 0
            ? new Response<string>("Clap not created", HttpStatusCode.NotFound)
            : new Response<string>(null, "Clap created");

    }
    public async Task<Response<string>> UpdateAsync(Clap clap)
    {
        using var connection = await context.GetConnection();
        var sql = @"update claps set ArticleId=@ArticleId,UserId=@UserId,Count=@Count,CreatedAt=@CreatedAt
                    where id = @id";
        var result = await connection.ExecuteAsync(sql, clap);
        return result == 0
            ? new Response<string>("Clap not updated", HttpStatusCode.NotFound)
            : new Response<string>(null, "Clap updated");
    }
    public async Task<Response<string>> DeleteAsync(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"delete from claps where id = @id";
        var result = await connection.ExecuteAsync(sql, new { id });
        return result == 0
            ? new Response<string>("Clap not deleted", HttpStatusCode.NotFound)
            : new Response<string>(null, "Clap deleted");
    }
}
