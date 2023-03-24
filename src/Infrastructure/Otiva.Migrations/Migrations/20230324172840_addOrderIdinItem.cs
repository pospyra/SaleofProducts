using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otiva.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addOrderIdinItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemShoppingCart_User_UserId",
                table: "ItemShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_ClientId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_ItemShoppingCart_UserId",
                table: "ItemShoppingCart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItemShoppingCart");

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemShoppingCart_ProductId",
                table: "ItemShoppingCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemShoppingCart_Product_ProductId",
                table: "ItemShoppingCart",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemShoppingCart_Product_ProductId",
                table: "ItemShoppingCart");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Order_ClientId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_ItemShoppingCart_ProductId",
                table: "ItemShoppingCart");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ItemShoppingCart",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemShoppingCart_UserId",
                table: "ItemShoppingCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemShoppingCart_User_UserId",
                table: "ItemShoppingCart",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
