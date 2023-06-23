using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Slicone_Supplier.Models
{
    public class ApplicationDbContext : IdentityDbContext<WebUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                string TableName = item.GetTableName();
                if (TableName.StartsWith("AspNet"))
                {
                    item.SetTableName("Slicone"+TableName.Substring(6));
                }
            }

        }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Iventory> Inventories { get; set; }
        public DbSet<PhoneModel> PhoneModels { get; set; }
        public DbSet<IventoryDetail> IventoryDetails { get; set; }
        public DbSet<ImportedReceipt> ImportedReceipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
