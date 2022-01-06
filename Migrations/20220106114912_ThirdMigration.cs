using Microsoft.EntityFrameworkCore.Migrations;

namespace KotasProject.Migrations
{
    public partial class ThirdMigration : Migration
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Trainer_TrainerId",
                table: "Pokemon",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
