using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairShop.Server.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tv_Brand",
                table: "CustomerDataT");

            migrationBuilder.RenameColumn(
                name: "Tv_Inch",
                table: "CustomerDataT",
                newName: "TvInch");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "CustomerDataT",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CustomerDataT",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TvBrand",
                table: "CustomerDataT",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TvBrand",
                table: "CustomerDataT");

            migrationBuilder.RenameColumn(
                name: "TvInch",
                table: "CustomerDataT",
                newName: "Tv_Inch");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "CustomerDataT",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CustomerDataT",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Tv_Brand",
                table: "CustomerDataT",
                type: "text",
                nullable: true);
        }
    }
}
