using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication_Slicone_Supplier.Models;

namespace WebApplication_Slicone_Supplier.Areas.Admin.Pages.User
{
    public class AssignRoleModel : PageModel
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly SignInManager<WebUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AssignRoleModel(
            UserManager<WebUser> userManager,
            SignInManager<WebUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        
        public WebUser User { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        public SelectList allRoles { get; set; }

        [BindProperty]
        [DisplayName("Role For User")]
        public string[] RoleName { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound($"Unable to load ID");
            }
            User = await _userManager.FindByIdAsync(id);
            if (User == null)
            {
                return NotFound($"Unable to load user with ID = {id}.");
            }

             RoleName = (await _userManager.GetRolesAsync(User)).ToArray<string>();

            List<String> roleNames = await _roleManager.Roles.Select(r=>r.Name).ToListAsync();
            allRoles = new SelectList(roleNames);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound($"Unable to load ID");
            }
            User = await _userManager.FindByIdAsync(id);
            if (User == null)
            {
                return NotFound($"Unable to load user with ID = {id}.");
            }

            var OldRoleName = (await _userManager.GetRolesAsync(User)).ToArray<string>();

            var deleteRoles = OldRoleName.Where(r => !RoleName.Contains(r));
            var addRoles = RoleName.Where(r=>!OldRoleName.Contains(r));

            var resultDelete = await _userManager.RemoveFromRolesAsync(User,deleteRoles);

            List<String> roleNames = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            allRoles = new SelectList(roleNames);

            if (!resultDelete.Succeeded)
            {
                resultDelete.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                });
                return Page();
            }

            var resultAdd =await _userManager.AddToRolesAsync(User, addRoles);
            if (!resultAdd.Succeeded)
            {
                resultAdd.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                });
                return Page();
            }
            StatusMessage = $"User '{User.UserName}' Role has been assigned.";
            return RedirectToPage("./Index");
        }
    }
}
