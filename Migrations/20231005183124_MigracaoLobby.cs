using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoLobby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    JogadoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jogador1 = table.Column<int>(type: "int", nullable: false),
                    Jogador2 = table.Column<int>(type: "int", nullable: false),
                    Jogador3 = table.Column<int>(type: "int", nullable: false),
                    Jogador4 = table.Column<int>(type: "int", nullable: false),
                    Jogador5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.JogadoresId);
                });

            migrationBuilder.CreateTable(
                name: "Lobbys",
                columns: table => new
                {
                    LobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IdQuadra = table.Column<int>(type: "int", nullable: false),
                    JogadoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobbys", x => x.LobbyId);
                    table.ForeignKey(
                        name: "FK_Lobbys_Jogadores_JogadoresId",
                        column: x => x.JogadoresId,
                        principalTable: "Jogadores",
                        principalColumn: "JogadoresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lobbys_JogadoresId",
                table: "Lobbys",
                column: "JogadoresId"
                //,unique: true
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lobbys");

            migrationBuilder.DropTable(
                name: "Jogadores");
        }
    }
}
