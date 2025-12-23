using Microsoft.EntityFrameworkCore;
using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
using ProductInventory.Infrastructure.Context;
namespace ProductInventory.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UsersVM?> GetByEmailAsync(string email)
        {
            return await _context.Set<UsersVM>().FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<UsersVM?> GetByIdAsync(Guid id)
        {
            return await _context.Set<UsersVM>().FindAsync(id);
        }
        public async Task<UsersVM?> GetByUserIdAsync(double idUser)
        {
            return await _context.Set<UsersVM>().FindAsync(idUser);
        }
        public async Task<UsersVM?> GetByUserId(int userId)
        {
            return await _context.Set<UsersVM>().FindAsync(userId);
        }
        public async Task AddAsync(UsersVM user)
        {
            await _context.Set<UsersVM>().AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}