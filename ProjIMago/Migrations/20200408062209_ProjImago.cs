using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjIMago.Migrations
{
    public partial class ProjImago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagesGos",
                columns: table => new
                {
                    IdImagesGo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagego = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesGos", x => x.IdImagesGo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesGos");
        }
    }
}
