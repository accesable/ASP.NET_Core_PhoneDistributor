using System.ComponentModel.DataAnnotations;

namespace WebApplication_Slicone_Supplier.Models
{
    public class IventoryDetail
    {
        [Key]
        public string IventoryDetailId { get; set; } = string.Empty;
        public Iventory Iventory { get; set; }

        public PhoneModel PhoneModel { get; set; }
        public int Quantity { get; set; }
    }
}
