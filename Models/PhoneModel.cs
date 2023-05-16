using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_Slicone_Supplier.Models
{
    public class PhoneModel
    {
        [Key]
        public int ModelId { get; set; }
        [Required]
        [Display(Name = "Phone Model")]
        [StringLength(200)]
        public string ModelName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Model Brand")]
        public string ModelBrand { get; set; } = string.Empty;

        public Brand ? Brand { get; set; }

        [Required]
        [Display(Name ="Agent Price")]
        public double AgentPrice { get; set; }


        [Required]
        [Display(Name = "Retail Price")]
        public double CustomerPrice { get; set; }
        [Required]
        [StringLength(128)]
        public string Image { get; set; } = string.Empty;
    }
}
