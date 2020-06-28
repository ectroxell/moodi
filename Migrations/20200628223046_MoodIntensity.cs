using Microsoft.EntityFrameworkCore.Migrations;

namespace moodi.Migrations
{
    public partial class MoodIntensity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyReports_Meditations_MeditationID",
                table: "DailyReports");

            migrationBuilder.DropIndex(
                name: "IX_DailyReports_MeditationID",
                table: "DailyReports");

            migrationBuilder.DropColumn(
                name: "MeditationID",
                table: "DailyReports");

            migrationBuilder.AddColumn<int>(
                name: "MoodIntensity",
                table: "DailyReports",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoodIntensity",
                table: "DailyReports");

            migrationBuilder.AddColumn<int>(
                name: "MeditationID",
                table: "DailyReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyReports_MeditationID",
                table: "DailyReports",
                column: "MeditationID");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReports_Meditations_MeditationID",
                table: "DailyReports",
                column: "MeditationID",
                principalTable: "Meditations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
