using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace profile_service.Data_classes
{
    public enum EnrollmentStatus
    {
        Enrolled,
        Pending,
        Terminated,
        Suspended
    }


    public class Profile
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string F_name { get; set; }
        public byte[] Profile_picture { get; set; }
        public DateOnly? Enrolment_day { get; set; }
        public EnrollmentStatus Enrolllment_status { get; set; }

        // Navigation property
        public User User { get; set; }
    }

    public class Profile_Request
    {
        public string F_name { get; set; }
        public DateOnly Enrolment_day { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnrollmentStatus Enrolllment_status { get; set; }
    }
}