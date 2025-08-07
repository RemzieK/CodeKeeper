using CodeKeeper.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDTO register);
        Task<UserDTO> LoginAsync(LoginDTO login);

    }
}
