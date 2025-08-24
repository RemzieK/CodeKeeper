using CodeKeeper.Domain.Entities;
using CodeKeeper.Domain.Interfaces;
using CodeKeeper.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace CodeKeeper.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            context.Users.Remove(user);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await context.Users.Include(u => u.repositories).FirstOrDefaultAsync(u => u.email == email);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
