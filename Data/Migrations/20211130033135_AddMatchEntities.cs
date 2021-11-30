using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TftTracker.Migrations
{
    public partial class AddMatchEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "summonerLevel",
                table: "Summoners",
                newName: "SummonerLevel");

            migrationBuilder.RenameColumn(
                name: "revisionDate",
                table: "Summoners",
                newName: "RevisionDate");

            migrationBuilder.RenameColumn(
                name: "puuid",
                table: "Summoners",
                newName: "Puuid");

            migrationBuilder.RenameColumn(
                name: "profileIconId",
                table: "Summoners",
                newName: "ProfileIconId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Summoners",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "accountId",
                table: "Summoners",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Summoners",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "MatchInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MatchId = table.Column<string>(type: "TEXT", nullable: true),
                    GameDateTime = table.Column<long>(type: "INTEGER", nullable: false),
                    GameLength = table.Column<float>(type: "REAL", nullable: false),
                    GameVariation = table.Column<string>(type: "TEXT", nullable: true),
                    GameVersion = table.Column<string>(type: "TEXT", nullable: true),
                    QueueId = table.Column<int>(type: "INTEGER", nullable: false),
                    TftSetNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchInfo_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId");
                });

            migrationBuilder.CreateTable(
                name: "MatchMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MatchId = table.Column<string>(type: "TEXT", nullable: true),
                    DataVersion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchMetadata_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId");
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GoldLeft = table.Column<int>(type: "INTEGER", nullable: false),
                    LastRound = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    MatchMetadataId = table.Column<int>(type: "INTEGER", nullable: true),
                    MatchInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Placement = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayersEliminated = table.Column<int>(type: "INTEGER", nullable: false),
                    Puuid = table.Column<string>(type: "TEXT", nullable: true),
                    SummonerId = table.Column<string>(type: "TEXT", nullable: true),
                    TimeEliminated = table.Column<float>(type: "REAL", nullable: false),
                    TotalDamageToPlayers = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_MatchInfo_MatchInfoId",
                        column: x => x.MatchInfoId,
                        principalTable: "MatchInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participants_MatchMetadata_MatchMetadataId",
                        column: x => x.MatchMetadataId,
                        principalTable: "MatchMetadata",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participants_Summoners_SummonerId",
                        column: x => x.SummonerId,
                        principalTable: "Summoners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchInfo_MatchId",
                table: "MatchInfo",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchMetadata_MatchId",
                table: "MatchMetadata",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_MatchInfoId",
                table: "Participants",
                column: "MatchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_MatchMetadataId",
                table: "Participants",
                column: "MatchMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_SummonerId",
                table: "Participants",
                column: "SummonerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "MatchInfo");

            migrationBuilder.DropTable(
                name: "MatchMetadata");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.RenameColumn(
                name: "SummonerLevel",
                table: "Summoners",
                newName: "summonerLevel");

            migrationBuilder.RenameColumn(
                name: "RevisionDate",
                table: "Summoners",
                newName: "revisionDate");

            migrationBuilder.RenameColumn(
                name: "Puuid",
                table: "Summoners",
                newName: "puuid");

            migrationBuilder.RenameColumn(
                name: "ProfileIconId",
                table: "Summoners",
                newName: "profileIconId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Summoners",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Summoners",
                newName: "accountId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Summoners",
                newName: "id");
        }
    }
}
