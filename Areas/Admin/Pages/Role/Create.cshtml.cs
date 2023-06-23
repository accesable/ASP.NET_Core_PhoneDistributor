using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApplication_Slicone_Supplier.Models;

namespace WebApplication_Slicone_Supplier.Areas.Admin.Pages.Role
{
    public class CreateModel : RolePageModel
    {
        public CreateModel(RoleManager<IdentityRole> roleManager, ApplicationDbContext context) : base(roleManager, context)
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
/*        [BindProperty]
        public bool IsUpdate { get; set; }*/
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {

                this.StatusMessage = "Invalid Input";
                return Page();
            }
            IdentityRole NewRole = new IdentityRole(this.Input.Name);
            var r = await _roleManager.CreateAsync(NewRole);
            if(r.Succeeded)
            {
                StatusMessage = "New Role Created"+Input.Name;
                return RedirectToPage("./Index");
            }
            else
            {
                StatusMessage = "Error: ";
                foreach (var er in r.Errors)
                {
                    StatusMessage += er.Description;
                }
            }
            return Page();
        }
    }
}
