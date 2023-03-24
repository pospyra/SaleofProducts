using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otiva.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addConnItemShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartId",
                table: "ItemShoppingCart",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ItemShoppingCart_ShoppingCartId",
                table: "ItemShoppingCart",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemShoppingCart_ShoppingCart_ShoppingCartId",
                table: "ItemShoppingCart",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemShoppingCart_ShoppingCart_ShoppingCartId",
                table: "ItemShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ItemShoppingCart_ShoppingCartId",
                table: "ItemShoppingCart");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ItemShoppingCart");
        }
    }
}
