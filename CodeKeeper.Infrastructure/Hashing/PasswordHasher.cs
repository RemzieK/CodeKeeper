using CodeKeeper.Domain.Interfaces;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Infrastructure.Hashing
{
    public class PasswordHasher : IPasswordHashing
    {
        public Task<string> HashPasswordAsync(string password)
        {
            return Task.Run(() =>
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            });
        }

        public Task<bool> VerifyPasswordAsync(string password, string hash)
        {
            return Task.Run(() => BCrypt.Net.BCrypt.Verify(password, hash));
        }
    }
}
