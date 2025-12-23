using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UsersVM?> GetByEmailAsync(string email);
        Task<UsersVM?> GetByIdAsync(Guid userId);
        Task<UsersVM?> GetByUserId(int userId);
        Task AddAsync(UsersVM user);
    }
}
