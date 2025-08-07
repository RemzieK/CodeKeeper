using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Domain.Entities
{
    public class Repository
    {
        public Guid repId { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime createdAt { get; set; } = new DateTime();
        public Guid ownerId { get; set; }
        public User owner { get; set; }
        public bool isPrivate { get; set; } = false;

    }
}
