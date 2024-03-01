using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoJogadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lobbys_Jogadores_JogadoresId",
                table: "Lobbys");

            migrationBuilder.DropIndex(
                name: "IX_Lobbys_JogadoresId",
                table: "Lobbys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lobbys_JogadoresId",
                table: "Lobbys",
                column: "JogadoresId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lobbys_Jogadores_JogadoresId",
                table: "Lobbys",
                column: "JogadoresId",
                principalTable: "Jogadores",
                principalColumn: "JogadoresId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
