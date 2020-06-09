using Microsoft.EntityFrameworkCore.Migrations;

namespace moodi.Migrations
{
    public partial class Meditation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeditationID",
                table: "Moods",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meditations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FileLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meditations", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moods_MeditationID",
                table: "Moods",
                column: "MeditationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Moods_Meditations_MeditationID",
                table: "Moods",
                column: "MeditationID",
                principalTable: "Meditations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moods_Meditations_MeditationID",
                table: "Moods");

            migrationBuilder.DropTable(
                name: "Meditations");

            migrationBuilder.DropIndex(
                name: "IX_Moods_MeditationID",
                table: "Moods");

            migrationBuilder.DropColumn(
                name: "MeditationID",
                table: "Moods");
        }
    }
}
