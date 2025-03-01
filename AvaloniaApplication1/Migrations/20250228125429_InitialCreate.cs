using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaloniaApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    CName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.CName);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SName);
                });

            migrationBuilder.CreateTable(
                name: "Wallpapers",
                columns: table => new
                {
                    WId = table.Column<string>(type: "text", nullable: false),
                    WProdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WCompany = table.Column<string>(type: "text", nullable: false),
                    WQuantity = table.Column<int>(type: "integer", nullable: false),
                    WImage = table.Column<byte[]>(type: "bytea", nullable: false),
                    WWidth = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallpapers", x => new { x.WId, x.WProdDate, x.WCompany });
                });

            migrationBuilder.CreateTable(
                name: "Restocks",
                columns: table => new
                {
                    WId = table.Column<string>(type: "text", nullable: false),
                    WProdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WCompany = table.Column<string>(type: "text", nullable: false),
                    SName = table.Column<string>(type: "text", nullable: false),
                    RestockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BasePrice = table.Column<float>(type: "real", nullable: true),
                    Quantity = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restocks", x => new { x.WId, x.WProdDate, x.WCompany, x.RestockDate, x.SName });
                    table.ForeignKey(
                        name: "FK_Restocks_Sellers_SName",
                        column: x => x.SName,
                        principalTable: "Sellers",
                        principalColumn: "SName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restocks_Wallpapers_WId_WProdDate_WCompany",
                        columns: x => new { x.WId, x.WProdDate, x.WCompany },
                        principalTable: "Wallpapers",
                        principalColumns: new[] { "WId", "WProdDate", "WCompany" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sells",
                columns: table => new
                {
                    WId = table.Column<string>(type: "text", nullable: false),
                    WProdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WCompany = table.Column<string>(type: "text", nullable: false),
                    CName = table.Column<string>(type: "text", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    WholePrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sells", x => new { x.WId, x.WProdDate, x.WCompany, x.PurchaseDate, x.CName });
                    table.ForeignKey(
                        name: "FK_Sells_Clients_CName",
                        column: x => x.CName,
                        principalTable: "Clients",
                        principalColumn: "CName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sells_Wallpapers_WId_WProdDate_WCompany",
                        columns: x => new { x.WId, x.WProdDate, x.WCompany },
                        principalTable: "Wallpapers",
                        principalColumns: new[] { "WId", "WProdDate", "WCompany" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restocks_SName",
                table: "Restocks",
                column: "SName");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_CName",
                table: "Sells",
                column: "CName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restocks");

            migrationBuilder.DropTable(
                name: "Sells");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Wallpapers");
        }
    }
}
