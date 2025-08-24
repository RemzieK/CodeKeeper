using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Domain.Interfaces
{
    public interface IPasswordHashing
    {
        Task<string> HashPasswordAsync(string password);
        Task<bool> VerifyPasswordAsync(string password, string hash);
    }
}
