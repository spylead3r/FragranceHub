using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FragranceHub.Data.Migrations
{
    public partial class SeedingOneFragrance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("e322f726-c43f-4c92-a70e-9147a31a66f6"));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "UserId", "WishlistId" },
                values: new object[] { new Guid("03d11678-c3dc-4bc9-9c6e-c45f9294a4fc"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", true, "Creed Aventus", 620.00m, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("03d11678-c3dc-4bc9-9c6e-c45f9294a4fc"));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "UserId", "WishlistId" },
                values: new object[] { new Guid("e322f726-c43f-4c92-a70e-9147a31a66f6"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", true, "Creed Aventus", 620.00m, null, null });
        }
    }
}
