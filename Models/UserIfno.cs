using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        [StringLength(15, MinimumLength = 10, ErrorMessage ="This is not a valid phone number")]
        public string? Phone { get; set; }
        public float? Grade { get; set; }
        public string University { get; set; } = null!;
        public string? Speciality { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; } = null!;     // Foreign Key

        // Navigation properties
        public User User { get; set; } = null!;
    }
}
