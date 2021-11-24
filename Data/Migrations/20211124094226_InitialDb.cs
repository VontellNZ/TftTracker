using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TftTracker.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summoners",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    accountId = table.Column<string>(type: "TEXT", nullable: true),
                    profileIconId = table.Column<int>(type: "INTEGER", nullable: false),
                    revisionDate = table.Column<long>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    puuid = table.Column<string>(type: "TEXT", nullable: true),
                    summonerLevel = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summoners", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Summoners");
        }
    }
}
