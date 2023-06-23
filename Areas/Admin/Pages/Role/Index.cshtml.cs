using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_Slicone_Supplier.Models;

namespace WebApplication_Slicone_Supplier.Areas.Admin.Pages.Role
{
    [Authorize(Roles = "Examiner")]
    public class IndexModel : RolePageModel
    {
        public IndexModel(RoleManager<IdentityRole> roleManager, ApplicationDbContext context) : base(roleManager, context)
        {
        }
        [TempData]
        public string StatusMessage { get; set; }

        public List<IdentityRole> Roles { get; set; }

        public async Task OnGetAsync()
        {
            this.Roles= await  _roleManager.Roles.ToListAsync();
        }

        public void OnPost() => RedirectToPage();
    }
}
