using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "RosreestrStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Organizations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "OMSStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "RosreestrStatuses");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "OMSStatuses");
        }
    }
}
