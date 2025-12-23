using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.Interfaces
{
    public interface ISessionRepository
    {
        Task<SessionVM?> GetByUserIdAsync(Guid userId);
        Task SaveSessionChangesAsync();
        void Add(SessionVM session);
    }
}
