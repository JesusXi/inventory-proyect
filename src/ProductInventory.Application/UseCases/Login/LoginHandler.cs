using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductInventory.Application.Interfaces;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Application.UseCases.Login
{
    public class LoginHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IPassService _passer;
        private readonly IConfiguration _configuration;
        public LoginHandler(IUserRepository userRepository, ISessionRepository sessionRepository, IPassService passer, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _passer = passer;
            _configuration = configuration;
        }
        public async Task<LoginResult> ExecuteAsync(LoginCommand command)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email)
                ?? throw new UnauthorizedAccessException("Invalid credentials");
            if (!_passer.Verify(command.Pass, user.Password))
                throw new UnauthorizedAccessException("Invalid credentials");
            var token = GenerateJwt(user);
            var expiresAt = DateTime.UtcNow.AddMinutes(10);
            var session = await _sessionRepository.GetByUserIdAsync(user.Id);
            if (session is null)
            {
                session = new SessionVM(user.Id, token);
                _sessionRepository.Add(session);
            }
            else
            {
                session.Renew(token);
            }
            await _sessionRepository.SaveSessionChangesAsync();
            return new LoginResult(token, expiresAt);
        }
        private string GenerateJwt(UsersVM user)
        {
            var jwt = _configuration.GetSection("Jwt");
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
