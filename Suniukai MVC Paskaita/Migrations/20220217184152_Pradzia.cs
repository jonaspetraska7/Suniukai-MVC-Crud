using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Suniukai_MVC_Paskaita.Migrations
{
    public partial class Pradzia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kaciukai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vardas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nuotrauka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aprasymas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaciukai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suniukai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vardas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nuotrauka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aprasymas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suniukai", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kaciukai");

            migrationBuilder.DropTable(
                name: "Suniukai");
        }
    }
}
