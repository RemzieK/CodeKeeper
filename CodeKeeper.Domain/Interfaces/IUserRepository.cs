using CodeKeeper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);

        Task SaveChangesAsync();
        Task DeleteUserAsync(User user);

    }
}
