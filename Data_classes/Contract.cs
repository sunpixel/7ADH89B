using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace dbapp.Data_classes
{
    public class Contract
    {
        [Key]
        [Required]
        public int ContractID { get; set; }
        
        [Required]
        [NotNull]
        public int UserID { get; set; }

        public byte[] contractPDF { get; set; }
    }
}
