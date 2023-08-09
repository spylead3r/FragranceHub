using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FragranceHub.Data.Migrations
{
    public partial class Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems");

            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("6b6b5507-0a4e-493c-b61d-c0be388e3f5b"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingCartItems",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_CartId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 9, 18, 30, 55, 625, DateTimeKind.Utc).AddTicks(380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 4, 13, 10, 44, 592, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "UserId", "WishlistId" },
                values: new object[] { new Guid("b6fc03bd-79ac-40ac-950a-fc8348a8db1f"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", true, "Creed Aventus", 620.00m, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_CartId",
                table: "ShoppingCartItems",
                column: "CartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_CartId",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("b6fc03bd-79ac-40ac-950a-fc8348a8db1f"));

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "ShoppingCartItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_CartId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 4, 13, 10, 44, 592, DateTimeKind.Utc).AddTicks(5624),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 9, 18, 30, 55, 625, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "IsApproved", "Name", "Price", "PublishedOn", "UserId", "WishlistId" },
                values: new object[] { new Guid("6b6b5507-0a4e-493c-b61d-c0be388e3f5b"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", false, true, "Creed Aventus", 620.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
