using CodeKeeper.Application.DTOs;
using CodeKeeper.Application.Interfaces;
using CodeKeeper.Domain.Entities;
using CodeKeeper.Domain.Interfaces;
using CodeKeeper.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace CodeKeeper.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashing _passwordHashing;

        public AuthService(IUserRepository userRepository, IPasswordHashing passwordHashing)
        {
            _userRepository = userRepository;
            _passwordHashing = passwordHashing;
        }

        public async Task<UserDTO> LoginAsync(LoginDTO login)
        {
            var user = await _userRepository.GetUserByEmailAsync(login.Email);

            if (user == null)
                throw new Exception("Invalid credentials.");

            bool passwordMatches = await _passwordHashing.VerifyPasswordAsync(login.Password, user.passwordHash);
            if (!passwordMatches)
                throw new Exception("Invalid credentials.");

            return new UserDTO
            {
                userName = user.userName,
                email = user.email,
                repositories = user.repositories
            };
        }

        public async Task RegisterAsync(RegisterDTO register)
        {
            if (!await PasswordValidation.IsValidAsync(register.Password))
                throw new Exception("Password does not meet security requirements.");

            var existingUser = await _userRepository.GetUserByEmailAsync(register.Email);
            if (existingUser != null)
                throw new Exception("User already exists.");

            var hash = await _passwordHashing.HashPasswordAsync(register.Password);

            var newUser = new User
            {
                userName = register.Name,
                email = register.Email,
                passwordHash = hash
            };

            await _userRepository.AddUserAsync(newUser);
            await _userRepository.SaveChangesAsync();
        }
    }
}
