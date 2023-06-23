using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_Slicone_Supplier.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;


namespace WebApplication_Slicone_Supplier.Areas.Admin.Pages.User
{
    public class IndexModel : PageModel
    {

        private readonly UserManager<WebUser> _userManager;
        private readonly IConfiguration _configuration;

        public IndexModel(UserManager<WebUser> userManager,IConfiguration configuration )
        {
            _userManager = userManager;
            _configuration = configuration;

        }
        [TempData]
        public string StatusMessage { get; set; }

        public List<WebUser> Users { get; set; }

        public List<UserAndRoles> Users2 { get; set; }

        public class UserAndRoles : WebUser
        {
            public string RoleNames { get; set; }
        }





        /*public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            
            CurrentFilter = searchString;

            IQueryable<WebUser> UsersIQ = from s in _userManager.Users
                                          orderby s.UserName
                                          select s;
            Count = UsersIQ.Count();

            *//*if (!String.IsNullOrEmpty(searchString))
            {
                UsersIQ = UsersIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }*//*

            var pageSize = _configuration.GetValue("PageSize", 4);
            Users = await PaginatedList<WebUser>.CreateAsync(UsersIQ.AsNoTracking(),
                 pageIndex ?? 1, pageSize);



            CurrentPage = pageIndex ?? 1;

            *//*foreach(var user in Users)
            {
                var roles= await _userManager.GetRolesAsync(user);
                user.RoleNames = string.Join(",", roles);
            }*//*
        }*/

        public Pager PagingPage { get; set; } = new Pager();
        public int PageNo{ get; set; }

        public async Task OnGetAsync(int pageIndex=1)
        {
            var data =  (await _userManager.Users.OrderBy(u=>u.UserName).ToListAsync()).Select(u=>new UserAndRoles() { 
                Id = u.Id,
                UserName = u.UserName,
            });
            if (pageIndex <1 )
            {
                pageIndex = 1;

            }
            int rescCount = data.Count();
            

            const int pageSize = 10;
            PagingPage = new Pager(rescCount,pageIndex, pageSize);


            int recSkip = (pageIndex-1) * pageSize;
            Users2 = data.Skip(recSkip).Take(PagingPage.PageSize).ToList();

            foreach(var user in Users2) {
                var AllUserRoles = await _userManager.GetRolesAsync(user);
                user.RoleNames = String.Join(",", AllUserRoles);
            }

        }   


        public void OnPost() => RedirectToPage();
    }
}
