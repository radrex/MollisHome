using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MollisHome.Data.Migrations
{
    public partial class AddPromoCodesForOrdersAndAddDiscountForProductStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromoCode",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentage",
                table: "ProductStock",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromoCodeId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false),
                    ExpirationDateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoCodes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_OrderId",
                table: "PromoCodes",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromoCodes");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "ProductStock");

            migrationBuilder.DropColumn(
                name: "PromoCodeId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PromoCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
