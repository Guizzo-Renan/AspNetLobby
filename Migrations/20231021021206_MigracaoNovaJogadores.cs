using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoNovaJogadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Jogador10",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador11",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador12",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador13",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador14",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador15",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador16",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador17",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador18",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador19",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador20",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador21",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador22",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador23",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador24",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador6",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador7",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador8",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogador9",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jogador10",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador11",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador12",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador13",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador14",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador15",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador16",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador17",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador18",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador19",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador20",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador21",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador22",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador23",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador24",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador6",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador7",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador8",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Jogador9",
                table: "Jogadores");
        }
    }
}
