using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FragranceHub.Data.Migrations
{
    public partial class Dbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("7cf7737e-fc17-497b-b4bd-4635e9b6db51"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 13, 48, 1, 974, DateTimeKind.Utc).AddTicks(9548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 13, 38, 36, 620, DateTimeKind.Utc).AddTicks(1050));

            migrationBuilder.CreateTable(
                name: "Accords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Woody = table.Column<int>(type: "int", nullable: false),
                    Citrus = table.Column<int>(type: "int", nullable: false),
                    Floral = table.Column<int>(type: "int", nullable: false),
                    Spicy = table.Column<int>(type: "int", nullable: false),
                    Fruity = table.Column<int>(type: "int", nullable: false),
                    Aromatic = table.Column<int>(type: "int", nullable: false),
                    Green = table.Column<int>(type: "int", nullable: false),
                    Musky = table.Column<int>(type: "int", nullable: false),
                    Herbal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "UserId", "WishlistId" },
                values: new object[] { new Guid("28777b53-f1d0-49d5-8095-477bbcb3e173"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", true, "Creed Aventus", 620.00m, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accords");

            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("28777b53-f1d0-49d5-8095-477bbcb3e173"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 13, 38, 36, 620, DateTimeKind.Utc).AddTicks(1050),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 13, 48, 1, 974, DateTimeKind.Utc).AddTicks(9548));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "IsApproved", "Name", "Price", "PublishedOn", "UserId", "WishlistId" },
                values: new object[] { new Guid("7cf7737e-fc17-497b-b4bd-4635e9b6db51"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", false, true, "Creed Aventus", 620.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
