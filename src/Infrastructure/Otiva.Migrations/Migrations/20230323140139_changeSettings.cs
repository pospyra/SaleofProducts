using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otiva.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class changeSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Product_AdId",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "ShoppingCart",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "AdId",
                table: "ShoppingCart",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "AdId",
                table: "Photo",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_AdId",
                table: "Photo",
                newName: "IX_Photo_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Product_ProductId",
                table: "Photo",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Product_ProductId",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShoppingCart",
                newName: "AdId");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "ShoppingCart",
                newName: "DateAdded");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Photo",
                newName: "AdId");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_ProductId",
                table: "Photo",
                newName: "IX_Photo_AdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Product_AdId",
                table: "Photo",
                column: "AdId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
