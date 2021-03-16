using Microsoft.EntityFrameworkCore.Migrations;

namespace MollisHome.Data.Migrations
{
    public partial class RenameEntitySexToGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStock_Sexes_SexId",
                table: "ProductStock");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.RenameColumn(
                name: "SexId",
                table: "ProductStock",
                newName: "GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStock_SexId",
                table: "ProductStock",
                newName: "IX_ProductStock_GenderId");

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStock_Genders_GenderId",
                table: "ProductStock",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStock_Genders_GenderId",
                table: "ProductStock");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "ProductStock",
                newName: "SexId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStock_GenderId",
                table: "ProductStock",
                newName: "IX_ProductStock_SexId");

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStock_Sexes_SexId",
                table: "ProductStock",
                column: "SexId",
                principalTable: "Sexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
