using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApplication_Slicone_Supplier.Models
{
    public class ImportedReceipt
    {
        [Key]
        public string ReceiptId { get; set; }
        [Required]
        [Display(Name = "Created on")]
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        [Required]

        public string StaffName { get; set; }

        public WebUser Staff { get; set; }

        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }

    }
}
