using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework_4Point2.Migrations
{
    public partial class SeedDataVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "vehicle");

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerID",
                table: "vehicle",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "manufacturer",
                columns: new[] { "ID", "Name" },
                values: new object[] { -1, "Ford" });

            migrationBuilder.InsertData(
                table: "manufacturer",
                columns: new[] { "ID", "Name" },
                values: new object[] { -2, "Chevrolet" });

            migrationBuilder.InsertData(
                table: "manufacturer",
                columns: new[] { "ID", "Name" },
                values: new object[] { -3, "Dodge" });

            migrationBuilder.InsertData(
                table: "vehicle",
                columns: new[] { "ID", "Colour", "ManufacturerID", "Model", "ModelYear" },
                values: new object[,]
                {
                    { -1, "Blue", "-1", "Fusion", 2010 },
                    { -2, "Black", "-1", "Escape", 2014 },
                    { -3, "Red", "-2", "Cruze", 2012 },
                    { -4, "Black", "-3", "Ram", 2018 },
                    { -5, "Blue", "-3", "Charger", 2016 }
                });

            migrationBuilder.CreateIndex(
                name: "FK_Vehicle_Manufacturer",
                table: "vehicle",
                column: "ManufacturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Manufacturer",
                table: "vehicle",
                column: "ManufacturerID",
                principalTable: "manufacturer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Manufacturer",
                table: "vehicle");

            migrationBuilder.DropTable(
                name: "manufacturer");

            migrationBuilder.DropIndex(
                name: "FK_Vehicle_Manufacturer",
                table: "vehicle");

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "ManufacturerID",
                table: "vehicle");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "vehicle",
                type: "varchar(30)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci");
        }
    }
}
