using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateOnly Day { get; set; }
        public TimeOnly Time { get; set; }

        [ForeignKey("Group")]
        public int GroupId {  get; set; }
        public Group Group { get; set; } = null!;
    }
}
