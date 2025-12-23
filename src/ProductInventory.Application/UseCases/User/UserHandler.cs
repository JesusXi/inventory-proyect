using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.User
{
    public class UserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPassService _passHasher;
        public UserHandler(IUserRepository userRepository, IPassService passwordHasher)
        {
            _userRepository = userRepository;
            _passHasher = passwordHasher;
        }
        public async Task ExecuteAsync(UserCommand command)
        {
            var existingUser = await _userRepository.GetByEmailAsync(command.Email);
            if (existingUser != null)
                throw new InvalidOperationException("User already exists");
            var passwordHash = _passHasher.Hash(command.Pass);
            var user = new UsersVM(command.Email, passwordHash);
            await _userRepository.AddAsync(user);
        }
    }
}