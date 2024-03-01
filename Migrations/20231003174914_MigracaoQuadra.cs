using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Quadra : Migration
    {
        /// <inheritdoc />
        /// 
        protected override void Up(MigrationBuilder migrationBuilder)
{
    // Remova todo o código SQL relacionado à tabela Quadras aqui.
    // Deixe este método vazio ou com qualquer outra alteração necessária.
}
        protected override void Down (MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quadras",
                columns: table => new
                {
                    QuadraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    horarioFuncionamento = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    modalidades = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    avaliacaoQuadra = table.Column<int>(type: "int", nullable: false),
                    horarioLobby = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(350)", nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(350)", nullable: false),
                    imagem = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadras", x => x.QuadraId);
                });
        }

        /// <inheritdoc />
      /*  protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quadras");
        }
        */
    }
}
