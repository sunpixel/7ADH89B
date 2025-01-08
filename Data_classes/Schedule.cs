using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace dbapp.Data_classes
{
    public class Schedule
    {
        [Key]
        [Required]
        public int Id { get; set; }     // Идентификатор записи

        [Required]
        public string Subject_Name { get; set; } = null!;

        [Required]
        public DateOnly? Day { get; set; }

        [Required]
        public DateTime? Time { get; set; }

        [Required]
        [NotNull]        
        public int GroupID { get; set; }
    }
}
