using CodeKeeper.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Domain.Services
{
    public class PasswordValidation 
    {
        public static Task<bool> IsValidAsync(string password)
        {
            bool isValid =
                !string.IsNullOrWhiteSpace(password) &&
                password.Length >= 8 &&
                password.Any(char.IsUpper) &&
                password.Any(char.IsDigit);

            return Task.FromResult(isValid);
        }
    }
}
