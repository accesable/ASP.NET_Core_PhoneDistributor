using System.ComponentModel.DataAnnotations;

namespace WebApplication_Slicone_Supplier.Models
{
    public class Iventory
    {
        [Key]
        [StringLength(50)]
        public string IventoryID { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        [Display(Name ="Inventory Address")]
        public string IventoryAddress { get; set; }
        
        public List<IventoryDetail> IventoryDetails { get; set; } = new List<IventoryDetail>();

    }
}
