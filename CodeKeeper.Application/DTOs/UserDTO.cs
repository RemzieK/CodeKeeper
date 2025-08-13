using CodeKeeper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.Application.DTOs
{
    public class UserDTO
    {
        [Required]
        public string userName { get; set; } = string.Empty;
        [Required]
        public string email { get; set; } = string.Empty;
        [Required]
        public ICollection<Repository> repositories { get; set; } = new List<Repository>();
    }
}
