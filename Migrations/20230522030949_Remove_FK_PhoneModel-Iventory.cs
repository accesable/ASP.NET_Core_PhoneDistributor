using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Slicone_Supplier.Migrations
{
    /// <inheritdoc />
    public partial class Remove_FK_PhoneModelIventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModels_Inventory_IventoryID",
                table: "PhoneModels");

            migrationBuilder.DropIndex(
                name: "IX_PhoneModels_IventoryID",
                table: "PhoneModels");

            migrationBuilder.DropColumn(
                name: "IventoryID",
                table: "PhoneModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IventoryID",
                table: "PhoneModels",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModels_IventoryID",
                table: "PhoneModels",
                column: "IventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModels_Inventory_IventoryID",
                table: "PhoneModels",
                column: "IventoryID",
                principalTable: "Inventory",
                principalColumn: "IventoryID");
        }
    }
}
