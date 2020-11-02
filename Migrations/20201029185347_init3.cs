using Microsoft.EntityFrameworkCore.Migrations;

namespace Interviu.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Cod", "AcordPrelucrareDate", "CodJudet", "ComunicareEmail", "ComunicareMarketing", "ComunicarePosta", "ComunicareSMS", "DenumireCompanie", "Email", "Nume", "Phone", "Prenume" },
                values: new object[] { "CNP1234", true, "B", true, true, true, true, "", "ariel@ariel.com", "William", 555123456, "Shakespeare" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Cod",
                keyValue: "CNP1234");
        }
    }
}
