using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_Slicone_Supplier.Models;

namespace WebApplication_Slicone_Supplier.Areas.Admin.Pages.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly ApplicationDbContext _context;
        protected readonly RoleManager<IdentityRole> _roleManager;    
        public RolePageModel(RoleManager<IdentityRole> roleManager,ApplicationDbContext context) {
            _roleManager = roleManager;
            _context = context;
        }
    }
}
