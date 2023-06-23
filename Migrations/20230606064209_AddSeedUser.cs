using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Slicone_Supplier.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for(int i = 0; i < 150; i++) {
                migrationBuilder.InsertData(
                    "SliconeUsers",
                    columns: new[]
                    {
                        "Id",
                        "UserName",
                        "Email",
                        "SecurityStamp",
                        "EmailConfirmed",
                        "PhoneNumberConfirmed",
                        "TwoFactorEnabled",
                        "LockoutEnabled",
                        "AccessFailedCount",
                        "FirstName",
                        "LastName"
                    },
                    values: new object[]
                    {
                        Guid.NewGuid().ToString(),
                        "User-"+i.ToString("D3"),
                        $"email{i.ToString("D3")}@example.com",
                        Guid.NewGuid().ToString(),
                        true,
                        false,
                        false,
                        false,
                        0,
                        "FTes__2",
                        "L"+i.ToString("D3")
                    }
                 );
            
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
