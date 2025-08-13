using CodeKeeper.Application.DTOs;
using CodeKeeper.Application.Interfaces;
using CodeKeeper.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserDTO> LoginAsync(LoginDTO login)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(RegisterDTO register)
        {
            throw new NotImplementedException();
        }
    }
}
