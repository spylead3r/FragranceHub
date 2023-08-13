using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FragranceHub.Data.Migrations
{
    public partial class CollectionShoppingCartItemsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("61b148e3-0a82-477f-afed-7903f7ffba56"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartId1",
                table: "ShoppingCartItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOnDate",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 13, 1, 46, 32, 67, DateTimeKind.Utc).AddTicks(6387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 18, 39, 15, 362, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "UserId", "WishlistId" },
                values: new object[] { new Guid("25a8792e-1f1d-4128-af62-23bd68e50481"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", true, "Creed Aventus", 620.00m, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId1",
                table: "ShoppingCartItems",
                column: "ShoppingCartId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId1",
                table: "ShoppingCartItems",
                column: "ShoppingCartId1",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId1",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId1",
                table: "ShoppingCartItems");

            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("25a8792e-1f1d-4128-af62-23bd68e50481"));

            migrationBuilder.DropColumn(
                name: "ShoppingCartId1",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOnDate",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 18, 39, 15, 362, DateTimeKind.Utc).AddTicks(3004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 13, 1, 46, 32, 67, DateTimeKind.Utc).AddTicks(6387));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "IsApproved", "Name", "Price", "PublishedOnDate", "UserId", "WishlistId" },
                values: new object[] { new Guid("61b148e3-0a82-477f-afed-7903f7ffba56"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", false, true, "Creed Aventus", 620.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
