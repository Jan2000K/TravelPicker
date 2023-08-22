using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelPickerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedRegionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "Locations");
        }
    }
}
