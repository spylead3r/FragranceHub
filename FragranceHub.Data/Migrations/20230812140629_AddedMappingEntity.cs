using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FragranceHub.Data.Migrations
{
    public partial class AddedMappingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("28777b53-f1d0-49d5-8095-477bbcb3e173"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 6, 28, 228, DateTimeKind.Utc).AddTicks(8348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 13, 48, 1, 974, DateTimeKind.Utc).AddTicks(9548));

            migrationBuilder.CreateTable(
                name: "FragranceAccords",
                columns: table => new
                {
                    FragranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccordsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FragranceAccords", x => new { x.FragranceId, x.AccordsId });
                    table.ForeignKey(
                        name: "FK_FragranceAccords_Accords_AccordsId",
                        column: x => x.AccordsId,
                        principalTable: "Accords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FragranceAccords_Fragrances_FragranceId",
                        column: x => x.FragranceId,
                        principalTable: "Fragrances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsApproved", "Name", "Price", "UserId", "WishlistId" },
                values: new object[] { new Guid("896f5f99-da2f-4128-b89f-e89ffeb00150"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", true, "Creed Aventus", 620.00m, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_FragranceAccords_AccordsId",
                table: "FragranceAccords",
                column: "AccordsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FragranceAccords");

            migrationBuilder.DeleteData(
                table: "Fragrances",
                keyColumn: "Id",
                keyValue: new Guid("896f5f99-da2f-4128-b89f-e89ffeb00150"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Fragrances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 13, 48, 1, 974, DateTimeKind.Utc).AddTicks(9548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 6, 28, 228, DateTimeKind.Utc).AddTicks(8348));

            migrationBuilder.InsertData(
                table: "Fragrances",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "IsApproved", "Name", "Price", "PublishedOn", "UserId", "WishlistId" },
                values: new object[] { new Guid("28777b53-f1d0-49d5-8095-477bbcb3e173"), 1, "Creed Aventus is a timeless men's fragrance, exuding confidence and power. With notes of pineapple, blackcurrant, and musk, it evokes a bold and unforgettable aura.", "https://i.makeup.bg/r/rv/rvuuikzs9nz6.jpg", false, true, "Creed Aventus", 620.00m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
