using Microsoft.EntityFrameworkCore.Migrations;

namespace ChargePointer.Migrations
{
    public partial class LocationUpdateOnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Types_TypeId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_TypeId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Locations",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            // migrationBuilder.AlterColumn<string>(
            //     name: "ChargePointId",
            //     table: "ChargePoints",
            //     type: "nvarchar(39)",
            //     maxLength: 39,
            //     nullable: false,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChargePointId",
                table: "ChargePoints",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(39)",
                oldMaxLength: 39);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TypeId",
                table: "Locations",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Types_TypeId",
                table: "Locations",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
