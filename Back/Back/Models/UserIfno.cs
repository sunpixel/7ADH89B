using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public float? Grade { get; set; }
        public string University { get; set; } = null!;
        public string? Speciality { get; set; }
        public string UserId { get; set; } = null!;     // Foreign Key
        public User User { get; set; } = null!;         // What actually makes the foreign key work
    }
}
