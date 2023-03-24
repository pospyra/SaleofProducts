using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otiva.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class order_shopingcart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_ShoppingCartId",
                table: "Order",
                column: "ShoppingCartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShoppingCart_ShoppingCartId",
                table: "Order",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShoppingCart_ShoppingCartId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ShoppingCartId",
                table: "Order");
        }
    }
}
