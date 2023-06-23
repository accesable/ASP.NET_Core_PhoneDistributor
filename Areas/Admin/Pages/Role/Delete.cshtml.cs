using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApplication_Slicone_Supplier.Models;

namespace WebApplication_Slicone_Supplier.Areas.Admin.Pages.Role
{
    public class DeleteModel : RolePageModel
    {
        public DeleteModel(RoleManager<IdentityRole> roleManager, ApplicationDbContext context) : base(roleManager, context)
        {
        }

        [TempData]
        public string StatusMessage { get; set; }


        public IdentityRole role { get; set; }  
/*        [BindProperty]
        public bool IsUpdate { get; set; }*/
        public async Task<IActionResult> OnGet(string roleid)
        {
            if(roleid == null) return NotFound("Role Not Founded");

            this.role = await _roleManager.FindByIdAsync(roleid);
            if (role == null) return NotFound("Role Not Founded");
            else
            {
                return Page();
            }
            
        }
        public async Task<IActionResult> OnPostAsync(string roleid)
        {
            if (roleid == null) return NotFound("Role Not Founded");
            this.role = await _roleManager.FindByIdAsync(roleid);
            if (role == null) return NotFound("Role Not Founded");


            var result = await _roleManager.DeleteAsync(role);

            if(result.Succeeded)
            {
                StatusMessage = role.Name+" Deleted";
                return RedirectToPage("./Index");
            }
            else
            {
                StatusMessage = "Error: ";
                foreach (var er in result.Errors)
                {
                    StatusMessage += er.Description;
                }
            }
            return Page();
        }
    }
}
