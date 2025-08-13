using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string passwordHash { get; set; } = string.Empty;

        public ICollection<Repository> repositories { get; set; } = new List<Repository>();
    }
}
