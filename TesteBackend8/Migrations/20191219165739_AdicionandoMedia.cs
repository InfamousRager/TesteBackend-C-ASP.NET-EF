using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteBackend8.Migrations
{
    public partial class AdicionandoMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Media",
                table: "Aluno",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Media",
                table: "Aluno");
        }
    }
}
