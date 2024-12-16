using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace profile_service.Data_classes
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [NotNull]
        public string Username { get; set; }

        [Required]
        [NotNull]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [NotNull]
        public string Email { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Profile? Profile { get; set; }
    }

    public class User_Request
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class User_Response
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}