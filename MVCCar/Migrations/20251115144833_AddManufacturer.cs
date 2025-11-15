using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCar.Migrations
{
    /// <inheritdoc />
    public partial class AddManufacturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Car");
        }
    }
}
