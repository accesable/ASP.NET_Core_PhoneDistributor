using Microsoft.AspNetCore.Identity;

namespace WebApplication_Slicone_Supplier.Services
{
    public class MyAppIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateRoleName(string role)
        {
            var error= base.DuplicateRoleName(role);
            return new IdentityError()
            {
                Code = error.Code,
                Description = $"Duplicated Role Name {role} ! Please Try a different role name"
            };
        }
    }
}
