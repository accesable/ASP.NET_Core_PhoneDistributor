using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_Slicone_Supplier.Models
{
    public class PhoneModel
    {
        [Key]
        public int ModelId { get; set; }

        [Display(Name = "Phone Model")]
        [StringLength(200)]
        [Required]
        public string ModelName { get; set; } 

        [Display(Name = "Model Brand")]
        public int ModelBrandId { get; set; }
        public virtual Brand ?ModelBrand { get; set; }

        [Display(Name ="Agent Price")]
        public double AgentPrice { get; set; }


        [Required]
        [Display(Name = "Retail Price")]
        public double CustomerPrice { get; set; }

        [StringLength(128)]
        public string Image { get; set; } = string.Empty;
    }
}
