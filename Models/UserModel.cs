using System.ComponentModel.DataAnnotations;

namespace Filters.Models
{
    public class UserModel
    {
        public string? UserName { get; set; }

        public string? UserPassword { get; set; }

        public int RoleId { get; set; }

        public bool IsActive { get; set; }

        public string? UserEmailId { get; set; } = string.Empty;
    }
}
