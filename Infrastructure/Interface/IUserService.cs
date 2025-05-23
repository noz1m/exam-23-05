using Domain.ApiResponse;
using Domain.Entities;
namespace Infrastructure.Interface;

public interface IUserService
{
    public Task<Response<List<User>>> GetAllUserAsync();
    public Task<Response<User>> GetByIdAsync(int id);
    public Task<Response<string>> CreateAsync(User user);
    public Task<Response<string>> UpdateAsync(User user);
    public Task<Response<string>> DeleteAsync(int id);
}
