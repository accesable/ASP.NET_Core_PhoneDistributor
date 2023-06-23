using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Slicone_Supplier.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedPhoneModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModels_Brands_BrandId",
                table: "PhoneModels");

            migrationBuilder.DropColumn(
                name: "ModelBrand",
                table: "PhoneModels");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "PhoneModels",
                newName: "ModelBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneModels_BrandId",
                table: "PhoneModels",
                newName: "IX_PhoneModels_ModelBrandId");

            migrationBuilder.AlterColumn<string>(
                name: "AgentAddress",
                table: "SliconeUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModels_Brands_ModelBrandId",
                table: "PhoneModels",
                column: "ModelBrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModels_Brands_ModelBrandId",
                table: "PhoneModels");

            migrationBuilder.RenameColumn(
                name: "ModelBrandId",
                table: "PhoneModels",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneModels_ModelBrandId",
                table: "PhoneModels",
                newName: "IX_PhoneModels_BrandId");

            migrationBuilder.AlterColumn<string>(
                name: "AgentAddress",
                table: "SliconeUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelBrand",
                table: "PhoneModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModels_Brands_BrandId",
                table: "PhoneModels",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
