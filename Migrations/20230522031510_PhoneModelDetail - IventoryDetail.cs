using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Slicone_Supplier.Migrations
{
    /// <inheritdoc />
    public partial class PhoneModelDetailIventoryDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportedReceipt_SliconeUsers_StaffId",
                table: "ImportedReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDetail_ImportedReceipt_ImportedReceiptReceiptId",
                table: "ReceiptDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDetail_PhoneModels_PhoneModelId",
                table: "ReceiptDetail");

            migrationBuilder.DropTable(
                name: "PhoneModelsDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptDetail",
                table: "ReceiptDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportedReceipt",
                table: "ImportedReceipt");

            migrationBuilder.RenameTable(
                name: "ReceiptDetail",
                newName: "ReceiptDetails");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "Inventories");

            migrationBuilder.RenameTable(
                name: "ImportedReceipt",
                newName: "ImportedReceipts");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptDetail_PhoneModelId",
                table: "ReceiptDetails",
                newName: "IX_ReceiptDetails_PhoneModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptDetail_ImportedReceiptReceiptId",
                table: "ReceiptDetails",
                newName: "IX_ReceiptDetails_ImportedReceiptReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportedReceipt_StaffId",
                table: "ImportedReceipts",
                newName: "IX_ImportedReceipts_StaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptDetails",
                table: "ReceiptDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "IventoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportedReceipts",
                table: "ImportedReceipts",
                column: "ReceiptId");

            migrationBuilder.CreateTable(
                name: "IventoryDetails",
                columns: table => new
                {
                    IventoryDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IventoryID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneModelModelId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IventoryDetails", x => x.IventoryDetailId);
                    table.ForeignKey(
                        name: "FK_IventoryDetails_Inventories_IventoryID",
                        column: x => x.IventoryID,
                        principalTable: "Inventories",
                        principalColumn: "IventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IventoryDetails_PhoneModels_PhoneModelModelId",
                        column: x => x.PhoneModelModelId,
                        principalTable: "PhoneModels",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IventoryDetails_IventoryID",
                table: "IventoryDetails",
                column: "IventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_IventoryDetails_PhoneModelModelId",
                table: "IventoryDetails",
                column: "PhoneModelModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportedReceipts_SliconeUsers_StaffId",
                table: "ImportedReceipts",
                column: "StaffId",
                principalTable: "SliconeUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDetails_ImportedReceipts_ImportedReceiptReceiptId",
                table: "ReceiptDetails",
                column: "ImportedReceiptReceiptId",
                principalTable: "ImportedReceipts",
                principalColumn: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDetails_PhoneModels_PhoneModelId",
                table: "ReceiptDetails",
                column: "PhoneModelId",
                principalTable: "PhoneModels",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportedReceipts_SliconeUsers_StaffId",
                table: "ImportedReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDetails_ImportedReceipts_ImportedReceiptReceiptId",
                table: "ReceiptDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptDetails_PhoneModels_PhoneModelId",
                table: "ReceiptDetails");

            migrationBuilder.DropTable(
                name: "IventoryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptDetails",
                table: "ReceiptDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImportedReceipts",
                table: "ImportedReceipts");

            migrationBuilder.RenameTable(
                name: "ReceiptDetails",
                newName: "ReceiptDetail");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Inventory");

            migrationBuilder.RenameTable(
                name: "ImportedReceipts",
                newName: "ImportedReceipt");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptDetails_PhoneModelId",
                table: "ReceiptDetail",
                newName: "IX_ReceiptDetail_PhoneModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptDetails_ImportedReceiptReceiptId",
                table: "ReceiptDetail",
                newName: "IX_ReceiptDetail_ImportedReceiptReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ImportedReceipts_StaffId",
                table: "ImportedReceipt",
                newName: "IX_ImportedReceipt_StaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptDetail",
                table: "ReceiptDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "IventoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImportedReceipt",
                table: "ImportedReceipt",
                column: "ReceiptId");

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
                name: "IX_PhoneModelsDetail_IventoryID",
                table: "PhoneModelsDetail",
                column: "IventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModelsDetail_PhoneModelModelId",
                table: "PhoneModelsDetail",
                column: "PhoneModelModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImportedReceipt_SliconeUsers_StaffId",
                table: "ImportedReceipt",
                column: "StaffId",
                principalTable: "SliconeUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDetail_ImportedReceipt_ImportedReceiptReceiptId",
                table: "ReceiptDetail",
                column: "ImportedReceiptReceiptId",
                principalTable: "ImportedReceipt",
                principalColumn: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptDetail_PhoneModels_PhoneModelId",
                table: "ReceiptDetail",
                column: "PhoneModelId",
                principalTable: "PhoneModels",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
