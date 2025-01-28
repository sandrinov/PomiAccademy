using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstSampleTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialSync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "VehicleColor",
                table: "Vehicles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
            */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleColor",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
