using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloEfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddedNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Employees",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Employees");
        }
    }
}
