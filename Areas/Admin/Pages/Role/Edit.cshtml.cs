using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApplication_Slicone_Supplier.Models;

namespace WebApplication_Slicone_Supplier.Areas.Admin.Pages.Role
{
    public class EditModel : RolePageModel
    {
        public EditModel(RoleManager<IdentityRole> roleManager, ApplicationDbContext context) : base(roleManager, context)
        {
        }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {

            [Required(ErrorMessage = "Role Name Required")]
            [Display(Name = "Role Name")]
            [StringLength(100, ErrorMessage = "{0} from {2} to {1} characters.", MinimumLength = 3)]
            public string Name { set; get; }

        }
        [BindProperty]
        public InputModel Input { get; set; }
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
                this.Input = new InputModel() {
                    Name = role.Name
                };
                return Page();
            }
            
        }
        public async Task<IActionResult> OnPostAsync(string roleid)
        {
            if (roleid == null) return NotFound("Role Not Founded");
            this.role = await _roleManager.FindByIdAsync(roleid);
            if (!ModelState.IsValid)
            {

                this.StatusMessage = "Invalid Input";
                return Page();
            }
            string preName = role.Name;
            role.Name = this.Input.Name;
            var result = await _roleManager.UpdateAsync(role);

            if(result.Succeeded)
            {
                StatusMessage = preName+" Update To "+Input.Name;
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
