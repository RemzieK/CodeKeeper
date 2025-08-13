using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Domain.Entities
{
    public class Repository
    {
        public Guid RepositoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = new DateTime();
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public bool IsPrivate { get; set; } = false;

    }
}
