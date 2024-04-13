using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FragranceHub.Data.Migrations
{
    public partial class AdminSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("692ec903-63f7-4035-b3f2-ac3aef5d2781"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOnDate",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 19, 35, 24, 442, DateTimeKind.Utc).AddTicks(9123),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 19, 23, 50, 572, DateTimeKind.Utc).AddTicks(7937));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "UserId", "WishlistId" },
                values: new object[] { new Guid("4c4798e1-c5b1-414b-a903-6b3ff20b35a2"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://cdn.notinoimg.com/list_2k//creed/3508441104662_01-o__230320.jpg", true, "Creed Aventus", 620.00m, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("4c4798e1-c5b1-414b-a903-6b3ff20b35a2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOnDate",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 19, 23, 50, 572, DateTimeKind.Utc).AddTicks(7937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 19, 35, 24, 442, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "IsApproved", "Name", "Price", "PublishedOnDate", "UserId", "WishlistId" },
                values: new object[] { new Guid("692ec903-63f7-4035-b3f2-ac3aef5d2781"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://cdn.notinoimg.com/list_2k//creed/3508441104662_01-o__230320.jpg", false, true, "Creed Aventus", 620.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
