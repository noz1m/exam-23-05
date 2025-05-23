using System.IO.Pipelines;
using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interface;

namespace Infrastructure.Service;

public class UserService(DataContext context) : IUserService
{
    public async Task<Response<List<User>>> GetAllUserAsync()
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from users";
        var result = await connection.QueryAsync<User>(sql);
        return result == null
            ? new Response<List<User>>("User not founded", HttpStatusCode.NotFound)
            : new Response<List<User>>(result.ToList(), "User found");
    }
    public async Task<Response<User>> GetByIdAsync(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"select * from users where id = @id";
        var result = await connection.QueryFirstOrDefaultAsync<User>(sql, new { id });
        return result == null
            ? new Response<User>("User not found",HttpStatusCode.NotFound)
            : new Response<User>(result, "user found");
    }
    public async Task<Response<string>> CreateAsync(User user)
    {
        using var connection = await context.GetConnection();
        var sql = @"insert into users(UserName,Email,PasswordHash,Bio,CreatedAt)
                    values (@UserName,@Email,@PasswordHash,@Bio,@CreatedAt)";
        var result = await connection.ExecuteAsync(sql, user);
        return result == 0
            ? new Response<string>("User not created", HttpStatusCode.NotFound)
            : new Response<string>(null, "User created");

    }
    public async Task<Response<string>> UpdateAsync(User user)
    {
        using var connection = await context.GetConnection();
        var sql = @"update users set UserName=@UserName,Email=@Email,PasswordHash=@PasswordHash,Bio=@Bio,CreatedAt=@CreatedAt
                    where id = @id";
        var result = await connection.ExecuteAsync(sql, user);
        return result == 0
            ? new Response<string>("User not updated", HttpStatusCode.NotFound)
            : new Response<string>(null, "User updated");
    }
    public async Task<Response<string>> DeleteAsync(int id)
    {
        using var connection = await context.GetConnection();
        var sql = @"delete from users where id = @id";
        var result = await connection.ExecuteAsync(sql, new { id });
        return result == 0
            ? new Response<string>("User not deleted", HttpStatusCode.NotFound)
            : new Response<string>(null, "User deleted");
    }
}
