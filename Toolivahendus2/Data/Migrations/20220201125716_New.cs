using Microsoft.EntityFrameworkCore.Migrations;

namespace Toolivahendus2.Data.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TooliVahendus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eesnimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perekonnanimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Toon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tellimuskogus = table.Column<int>(type: "int", nullable: false),
                    Firmanimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firmaemail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TooliVahendus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TooliVahendus");
        }
    }
}
