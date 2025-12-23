using Microsoft.EntityFrameworkCore;
using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
using ProductInventory.Infrastructure.Context;
namespace ProductInventory.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;
        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SessionVM?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Set<SessionVM>().FirstOrDefaultAsync(s => s.UserId == userId);
        }
        public Task SaveSessionChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Add(SessionVM session)
        {
            _context.Set<SessionVM>().Add(session);
        }
    }
}