using Microsoft.EntityFrameworkCore.Migrations;

namespace moodi.Migrations
{
    public partial class AddMeditationObj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Moods");

            migrationBuilder.CreateTable(
                name: "Meditations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceFile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meditations", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meditations");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Moods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
