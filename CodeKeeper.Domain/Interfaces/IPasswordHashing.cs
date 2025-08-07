using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Domain.Interfaces
{
    public interface IPasswordHashing
    {
        Task HashPassword(string password);
        Task<bool> VerifyPassword(string password);
    }
}
