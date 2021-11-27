using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaContatos.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgendaContato",
                columns: table => new
                {
                    AgendaContatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeContato = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroContato = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FotoContato = table.Column<int>(type: "int", nullable: false),
                    EnderecoContato = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaContato", x => x.AgendaContatoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaContato");
        }
    }
}
