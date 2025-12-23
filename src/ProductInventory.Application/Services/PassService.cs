using Microsoft.AspNetCore.Identity;
using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.Services
{
    public class PassService : IPassService
    {
        private readonly PasswordHasher<UsersVM> _hasher = new();
        public byte[] Hash(string password)
        {
            var user = new UsersVM("temp@email.com", Array.Empty<byte>());
            var hashed = _hasher.HashPassword(user, password);
            return System.Text.Encoding.UTF8.GetBytes(hashed);
        }
        public bool Verify(string password, byte[] passwordHash)
        {
            var user = new UsersVM("temp@email.com", Array.Empty<byte>());
            var hashString = System.Text.Encoding.UTF8.GetString(passwordHash);
            var result = _hasher.VerifyHashedPassword(user, hashString, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
