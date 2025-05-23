using Domain.Entities;
using Domain.ApiResponse;
namespace Infrastructure.Interface;

public interface ICommentService
{
    public Task<Response<List<Comment>>> GetAllCommentAsync();
    public Task<Response<Comment>> GetByIdAsync(int id);
    public Task<Response<string>> CreateAsync(Comment comment);
    public Task<Response<string>> UpdateAsync(Comment comment);
    public Task<Response<string>> DeleteAsync(int id);
}
