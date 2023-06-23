using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using WebApplication_Slicone_Supplier.Models;
using WebApplication_Slicone_Supplier.Services;
using WebApplication_Slicone_Supplier.Services.GenerateID;
using WebApplication_Slicone_Supplier.Services.SendMail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddDbContext<ApplicationDbContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));

// Add Self-Build Services
builder.Services.AddOptions();

//Add Mail Settings
var mailsettings = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailsettings);
builder.Services.AddTransient<IEmailSender, EmailSender>();

//Add Self-Generate ID services
builder.Services.AddTransient<IIdGeneratorService, IdGeneratorService>();
builder.Services.AddTransient<IFileUploadServices, FileUploadServices>();

//Add Self Identity-Role Error services
builder.Services.AddSingleton<IdentityErrorDescriber,MyAppIdentityErrorDescriber>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.SignIn.RequireConfirmedAccount = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Default Password settings.
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    // Default SignIn settings.
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

    // Default User settings.
    options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});
/*builder.Services.AddIdentity<WebUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();*/

builder.Services.ConfigureApplicationCookie(options =>
{

    options.LoginPath = $"/Login";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
    /*options.Cookie.Name = ".AspNetCore.Identity.Application";*/
    /*options.Cookie.HttpOnly = true;*/
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});

/*builder.Services.AddDefaultIdentity<WebUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
*/
builder.Services.AddIdentity<WebUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

/*app.UseStaticFiles( new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
    RequestPath = "/StaticFiles"
});*/

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
