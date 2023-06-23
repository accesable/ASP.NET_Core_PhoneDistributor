using System.ComponentModel.DataAnnotations;

namespace WebApplication_Slicone_Supplier.Models
{
    public class ReceiptDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public PhoneModel Phone { get; set; }
        [Required]
        
        public int Quantity { get; set; }
    }
}