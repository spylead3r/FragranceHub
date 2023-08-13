using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FragranceHub.Data.Migrations
{
    public partial class PublishedOnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("896f5f99-da2f-4128-b89f-e89ffeb00150"));

            migrationBuilder.DropColumn(
                name: "PublishedOn",
                table: "Fragrances");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedOnDate",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 18, 39, 15, 362, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "UserId", "WishlistId" },
                values: new object[] { new Guid("61b148e3-0a82-477f-afed-7903f7ffba56"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", true, "Creed Aventus", 620.00m, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("61b148e3-0a82-477f-afed-7903f7ffba56"));

            migrationBuilder.DropColumn(
                name: "PublishedOnDate",
                table: "Fragrances");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedOn",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 6, 28, 228, DateTimeKind.Utc).AddTicks(8348));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "IsApproved", "Name", "Price", "PublishedOn", "UserId", "WishlistId" },
                values: new object[] { new Guid("896f5f99-da2f-4128-b89f-e89ffeb00150"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", false, true, "Creed Aventus", 620.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
