using Microsoft.EntityFrameworkCore.Migrations;

namespace moodi.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyReports_Journals_JournalID",
                table: "DailyReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyReports_Moods_MoodID",
                table: "DailyReports");

            migrationBuilder.AlterColumn<int>(
                name: "MoodID",
                table: "DailyReports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JournalID",
                table: "DailyReports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReports_Journals_JournalID",
                table: "DailyReports",
                column: "JournalID",
                principalTable: "Journals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReports_Moods_MoodID",
                table: "DailyReports",
                column: "MoodID",
                principalTable: "Moods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyReports_Journals_JournalID",
                table: "DailyReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyReports_Moods_MoodID",
                table: "DailyReports");

            migrationBuilder.AlterColumn<int>(
                name: "MoodID",
                table: "DailyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JournalID",
                table: "DailyReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReports_Journals_JournalID",
                table: "DailyReports",
                column: "JournalID",
                principalTable: "Journals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReports_Moods_MoodID",
                table: "DailyReports",
                column: "MoodID",
                principalTable: "Moods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
