using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserInfo UserInfo { get; set; } = null!;
        public Group? Group { get; set; }
    }
}
