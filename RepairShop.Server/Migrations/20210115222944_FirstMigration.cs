using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RepairShop.Server.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashRegisterT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateRegistered = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Ammount = table.Column<int>(type: "integer", nullable: false),
                    Customer = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisterT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDataT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    Tv_Brand = table.Column<string>(type: "text", nullable: true),
                    Tv_Inch = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDataT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvCheckInT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerDataId = table.Column<int>(type: "integer", nullable: false),
                    DateIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Failure = table.Column<string>(type: "text", nullable: true),
                    Returned = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvCheckInT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvCheckInT_CustomerDataT_CustomerDataId",
                        column: x => x.CustomerDataId,
                        principalTable: "CustomerDataT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvCheckOutT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FeePaid = table.Column<int>(type: "integer", nullable: false),
                    Repaired = table.Column<bool>(type: "boolean", nullable: false),
                    TvCheckInId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvCheckOutT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvCheckOutT_TvCheckInT_TvCheckInId",
                        column: x => x.TvCheckInId,
                        principalTable: "TvCheckInT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TvCheckInT_CustomerDataId",
                table: "TvCheckInT",
                column: "CustomerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TvCheckOutT_TvCheckInId",
                table: "TvCheckOutT",
                column: "TvCheckInId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashRegisterT");

            migrationBuilder.DropTable(
                name: "TvCheckOutT");

            migrationBuilder.DropTable(
                name: "TvCheckInT");

            migrationBuilder.DropTable(
                name: "CustomerDataT");
        }
    }
}
