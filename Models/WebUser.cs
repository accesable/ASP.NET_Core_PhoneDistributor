using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_Slicone_Supplier.Models
{
    public class WebUser :IdentityUser
    {
        [StringLength(200)]
        public string? AgentAddress { get; set; }
    }
}
