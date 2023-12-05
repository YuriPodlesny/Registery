using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DistrictNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "DistrictNumbers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "DistrictNumbers");
        }
    }
}
