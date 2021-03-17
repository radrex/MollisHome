using Microsoft.EntityFrameworkCore.Migrations;

namespace MollisHome.Data.Migrations
{
    public partial class ChangePercentageDataTypesAddCheckAndUniqueConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sizes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "DiscountPercentage",
                table: "PromoCodes",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PromoCodes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "DiscountPercentage",
                table: "ProductStock",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "Percentage",
                table: "Materials",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materials",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HexValue",
                table: "Colors",
                type: "char(7)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Sizes_Name",
                table: "Sizes",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PromoCodes_Code",
                table: "PromoCodes",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_Name_CategoryId",
                table: "Products",
                columns: new[] { "Name", "CategoryId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Materials_Name_Percentage",
                table: "Materials",
                columns: new[] { "Name", "Percentage" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Genders_Name",
                table: "Genders",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Colors_Name",
                table: "Colors",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_PromoCode_DiscountPercentage",
                table: "PromoCodes",
                sql: "[DiscountPercentage] >= 0 AND [DiscountPercentage] <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_ProductStock_DiscountPercentage",
                table: "ProductStock",
                sql: "[DiscountPercentage] >= 0 AND [DiscountPercentage] <= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Material_Percentage",
                table: "Materials",
                sql: "[Percentage] >= 0 AND [Percentage] <= 100");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Sizes_Name",
                table: "Sizes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PromoCodes_Code",
                table: "PromoCodes");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_PromoCode_DiscountPercentage",
                table: "PromoCodes");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_ProductStock_DiscountPercentage",
                table: "ProductStock");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_Name_CategoryId",
                table: "Products");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Materials_Name_Percentage",
                table: "Materials");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_Material_Percentage",
                table: "Materials");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Genders_Name",
                table: "Genders");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Colors_Name",
                table: "Colors");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercentage",
                table: "PromoCodes",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PromoCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercentage",
                table: "ProductStock",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Percentage",
                table: "Materials",
                type: "int",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "HexValue",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(7)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
