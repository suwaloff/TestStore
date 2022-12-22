using Microsoft.EntityFrameworkCore.Migrations;

namespace TestStore.Migrations
{
    public partial class addBrandtoProduct4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandName",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "BrandName",
                table: "Product",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandName",
                table: "Product",
                newName: "IX_Product_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Product",
                newName: "BrandName");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                newName: "IX_Product_BrandName");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandName",
                table: "Product",
                column: "BrandName",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
