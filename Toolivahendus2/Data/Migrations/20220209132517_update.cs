using Microsoft.EntityFrameworkCore.Migrations;

namespace Toolivahendus2.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Valminudkogus",
                table: "TooliVahendus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valminudkogus",
                table: "TooliVahendus");
        }
    }
}
