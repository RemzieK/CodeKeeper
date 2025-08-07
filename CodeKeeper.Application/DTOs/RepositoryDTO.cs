using CodeKeeper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Application.DTOs
{
    public class RepositoryDTO
    {
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime createdAt { get; set; } = new DateTime();
        public User user { get; set; }
        public bool isPrivate { get; set; } = false;
    }
}
