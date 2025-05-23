using Domain.Entities;
using Domain.ApiResponse;
namespace Infrastructure.Interface;

public interface IClapService
{
    public Task<Response<List<Clap>>> GetAllClapAsync();
    public Task<Response<Clap>> GetByIdAsync(int id);
    public Task<Response<string>> CreateAsync(Clap clap);
    public Task<Response<string>> UpdateAsync(Clap clap);
    public Task<Response<string>> DeleteAsync(int id);
}
