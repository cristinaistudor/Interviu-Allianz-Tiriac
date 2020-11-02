using Microsoft.EntityFrameworkCore.Migrations;

namespace Interviu.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    Cod = table.Column<string>(maxLength: 7, nullable: false),
                    Nume = table.Column<string>(nullable: false),
                    Prenume = table.Column<string>(nullable: false),
                    DenumireCompanie = table.Column<string>(nullable: false),
                    CodJudet = table.Column<string>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    AcordPrelucrareDate = table.Column<bool>(nullable: false),
                    ComunicareMarketing = table.Column<bool>(nullable: false),
                    ComunicareEmail = table.Column<bool>(nullable: false),
                    ComunicareSMS = table.Column<bool>(nullable: false),
                    ComunicarePosta = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.Cod);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");
        }
    }
}
