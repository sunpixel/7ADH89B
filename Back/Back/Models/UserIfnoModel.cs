using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class UserIfnoModel
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public float AVG_Grade { get; set; }
        public string University { get; set; }
        public string Speciality { get; set; }

        [ForeignKey("User_ID")]
        public UserModel User { get; set; }
    }
}
