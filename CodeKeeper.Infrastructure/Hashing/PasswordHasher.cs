using CodeKeeper.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Infrastructure.Hashing
{
    public class PasswordHasher : IPasswordHashing
    {
        public Task HashPassword(string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyPassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}
