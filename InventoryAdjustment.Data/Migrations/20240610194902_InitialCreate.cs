using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAdjustment.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adjustaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adjustaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAdjustments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityHand = table.Column<int>(type: "int", nullable: false),
                    QuantityCounted = table.Column<int>(type: "int", nullable: false),
                    Difference = table.Column<int>(type: "int", nullable: false),
                    AdjustamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAdjustments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAdjustments_Adjustaments_AdjustamentId",
                        column: x => x.AdjustamentId,
                        principalTable: "Adjustaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdjustments_AdjustamentId",
                table: "ProductAdjustments",
                column: "AdjustamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAdjustments");

            migrationBuilder.DropTable(
                name: "Adjustaments");
        }
    }
}
