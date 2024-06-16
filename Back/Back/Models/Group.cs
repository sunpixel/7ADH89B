using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string ModeOfStudy { get; set; } = null!;


        // Navigation properties
        public Schedule Schedule { get; set; }
        public ICollection<User> User { get; set; }
        public ICollection<HomeWork> HomeWorks { get; set; }
    }
}
