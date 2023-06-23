using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Slicone_Supplier.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Brands_BrandId",
                table: "Phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phones",
                table: "Phones");

            migrationBuilder.RenameTable(
                name: "Phones",
                newName: "PhoneModels");

            migrationBuilder.RenameIndex(
                name: "IX_Phones_BrandId",
                table: "PhoneModels",
                newName: "IX_PhoneModels_BrandId");

            migrationBuilder.AddColumn<string>(
                name: "IventoryID",
                table: "PhoneModels",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneModels",
                table: "PhoneModels",
                column: "ModelId");

            migrationBuilder.CreateTable(
                name: "ImportedReceipt",
                columns: table => new
                {
                    ReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportedReceipt", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_ImportedReceipt_SliconeUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "SliconeUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    IventoryID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IventoryAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.IventoryID);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneModelId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImportedReceiptReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptDetail_ImportedReceipt_ImportedReceiptReceiptId",
                        column: x => x.ImportedReceiptReceiptId,
                        principalTable: "ImportedReceipt",
                        principalColumn: "ReceiptId");
                    table.ForeignKey(
                        name: "FK_ReceiptDetail_PhoneModels_PhoneModelId",
                        column: x => x.PhoneModelId,
                        principalTable: "PhoneModels",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneModelsDetail",
                columns: table => new
                {
                    IventoryDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IventoryID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneModelModelId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModelsDetail", x => x.IventoryDetailId);
                    table.ForeignKey(
                        name: "FK_PhoneModelsDetail_Inventory_IventoryID",
                        column: x => x.IventoryID,
                        principalTable: "Inventory",
                        principalColumn: "IventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneModelsDetail_PhoneModels_PhoneModelModelId",
                        column: x => x.PhoneModelModelId,
                        principalTable: "PhoneModels",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModels_IventoryID",
                table: "PhoneModels",
                column: "IventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ImportedReceipt_StaffId",
                table: "ImportedReceipt",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModelsDetail_IventoryID",
                table: "PhoneModelsDetail",
                column: "IventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModelsDetail_PhoneModelModelId",
                table: "PhoneModelsDetail",
                column: "PhoneModelModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetail_ImportedReceiptReceiptId",
                table: "ReceiptDetail",
                column: "ImportedReceiptReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetail_PhoneModelId",
                table: "ReceiptDetail",
                column: "PhoneModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModels_Brands_BrandId",
                table: "PhoneModels",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModels_Inventory_IventoryID",
                table: "PhoneModels",
                column: "IventoryID",
                principalTable: "Inventory",
                principalColumn: "IventoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModels_Brands_BrandId",
                table: "PhoneModels");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModels_Inventory_IventoryID",
                table: "PhoneModels");

            migrationBuilder.DropTable(
                name: "PhoneModelsDetail");

            migrationBuilder.DropTable(
                name: "ReceiptDetail");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "ImportedReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneModels",
                table: "PhoneModels");

            migrationBuilder.DropIndex(
                name: "IX_PhoneModels_IventoryID",
                table: "PhoneModels");

            migrationBuilder.DropColumn(
                name: "IventoryID",
                table: "PhoneModels");

            migrationBuilder.RenameTable(
                name: "PhoneModels",
                newName: "Phones");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneModels_BrandId",
                table: "Phones",
                newName: "IX_Phones_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                table: "Phones",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Brands_BrandId",
                table: "Phones",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
