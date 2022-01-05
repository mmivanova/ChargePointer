using Microsoft.EntityFrameworkCore.Migrations;

namespace ChargePointer.Infrastructure.Migrations
{
    public partial class ChargePointUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChargePoints_Statuses_StatusId",
                table: "ChargePoints");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_ChargePoints_StatusId",
                table: "ChargePoints");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ChargePoints");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ChargePoints",
                type: "nvarchar(39)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ChargePoints");

            migrationBuilder.AlterColumn<string>(
                name: "LocationId",
                table: "ChargePoints",
                type: "nvarchar(39)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ChargePoints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "Available" },
                    { 2, "Blocked" },
                    { 3, "Charging" },
                    { 4, "Removed" },
                    { 5, "Reserved" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "Parking" },
                    { 2, "Airport" },
                    { 3, "OnStreet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargePoints_StatusId",
                table: "ChargePoints",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChargePoints_Statuses_StatusId",
                table: "ChargePoints",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
