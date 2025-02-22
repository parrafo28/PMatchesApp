using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMatches.Frontend.Migrations
{
    /// <inheritdoc />
    public partial class AddingStatusToMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: true),
                    FavorPoints = table.Column<int>(type: "int", nullable: true),
                    AgainstPoints = table.Column<int>(type: "int", nullable: true),
                    MatchesWon = table.Column<int>(type: "int", nullable: true),
                    MatchesLost = table.Column<int>(type: "int", nullable: true),
                    CumulativePoints = table.Column<int>(type: "int", nullable: true),
                    MatchesTied = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StatusId",
                table: "Matches",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Status_StatusId",
                table: "Matches",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Status_StatusId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Matches_StatusId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Matches");
        }
    }
}
