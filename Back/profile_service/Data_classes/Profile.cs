using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace profile_service.Data_classes
{
    public class Profile
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string F_Name { get; set; }
        public BinaryReader Profile_picture { get; set; }
        public DateOnly Enrolment_day { get; set; }
        public string Enrolllment_status { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}