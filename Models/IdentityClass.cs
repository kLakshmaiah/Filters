using System.ComponentModel.DataAnnotations;

namespace Filters.Models
{
    public class IdentityClass
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
