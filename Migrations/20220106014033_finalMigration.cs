using Microsoft.EntityFrameworkCore.Migrations;

namespace KotasProject.Migrations
{
    public partial class finalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Pokemon_PokemonId",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Sprites_SpritesId",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_SpritesId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "SpritesId",
                table: "Pokemon");

            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "Sprites",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PokemonId",
                table: "Abilities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sprites_PokemonId",
                table: "Sprites",
                column: "PokemonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Pokemon_PokemonId",
                table: "Abilities",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprites_Pokemon_PokemonId",
                table: "Sprites",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Pokemon_PokemonId",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprites_Pokemon_PokemonId",
                table: "Sprites");

            migrationBuilder.DropIndex(
                name: "IX_Sprites_PokemonId",
                table: "Sprites");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "Sprites");

            migrationBuilder.AddColumn<int>(
                name: "SpritesId",
                table: "Pokemon",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PokemonId",
                table: "Abilities",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_SpritesId",
                table: "Pokemon",
                column: "SpritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Pokemon_PokemonId",
                table: "Abilities",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Sprites_SpritesId",
                table: "Pokemon",
                column: "SpritesId",
                principalTable: "Sprites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
