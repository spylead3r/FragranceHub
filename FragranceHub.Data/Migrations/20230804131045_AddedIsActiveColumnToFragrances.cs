using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FragranceHub.Data.Migrations
{
    public partial class AddedIsActiveColumnToFragrances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("d99f1a34-5044-4e02-941e-38de4a2b9eae"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 4, 13, 10, 44, 592, DateTimeKind.Utc).AddTicks(5624),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 31, 14, 59, 34, 382, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Fragrances",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Fragrances",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "UserId", "WishlistId" },
                values: new object[] { new Guid("6b6b5507-0a4e-493c-b61d-c0be388e3f5b"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", true, "Creed Aventus", 620.00m, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("6b6b5507-0a4e-493c-b61d-c0be388e3f5b"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Fragrances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 14, 59, 34, 382, DateTimeKind.Utc).AddTicks(7992),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 4, 13, 10, 44, 592, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Fragrances",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "PublishedOn", "UserId", "WishlistId" },
                values: new object[] { new Guid("d99f1a34-5044-4e02-941e-38de4a2b9eae"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", true, "Creed Aventus", 620.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
