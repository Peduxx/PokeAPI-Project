using Microsoft.EntityFrameworkCore.Migrations;

namespace KotasProject.Migrations
{
    public partial class SecondMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Trainer_TrainerId",
                table: "Pokemon");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Pokemon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpritesId",
                table: "Pokemon",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Front_Default = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AbilityId = table.Column<int>(type: "INTEGER", nullable: true),
                    Slot = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Abilities_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_SpritesId",
                table: "Pokemon",
                column: "SpritesId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_AbilityId",
                table: "Abilities",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_PokemonId",
                table: "Abilities",
                column: "PokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Sprites_SpritesId",
                table: "Pokemon",
                column: "SpritesId",
                principalTable: "Sprites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Trainer_TrainerId",
                table: "Pokemon",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Sprites_SpritesId",
                table: "Pokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Trainer_TrainerId",
                table: "Pokemon");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Sprites");

            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_SpritesId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "SpritesId",
                table: "Pokemon");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Pokemon",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Trainer_TrainerId",
                table: "Pokemon",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
