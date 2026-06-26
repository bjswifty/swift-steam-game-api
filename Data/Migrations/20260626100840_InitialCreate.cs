using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftSteamGameApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameAchievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    IsUnlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    UnlockedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    ExternalId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameAchievements_GameRecords_GameRecordId",
                        column: x => x.GameRecordId,
                        principalTable: "GameRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameCategories_GameRecords_GameRecordId",
                        column: x => x.GameRecordId,
                        principalTable: "GameRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Developer = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Publisher = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    YearOfRelease = table.Column<int>(type: "INTEGER", nullable: true),
                    Platform = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: true),
                    ExternalId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameDetails_GameRecords_GameRecordId",
                        column: x => x.GameRecordId,
                        principalTable: "GameRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonalRating = table.Column<decimal>(type: "TEXT", precision: 3, scale: 1, nullable: true),
                    ReviewTitle = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ReviewBody = table.Column<string>(type: "TEXT", maxLength: 20000, nullable: true),
                    Pros = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Cons = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    FavoriteMoment = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    DifficultyRating = table.Column<int>(type: "INTEGER", nullable: true),
                    ReplayValue = table.Column<int>(type: "INTEGER", nullable: true),
                    ReviewedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameReviews_GameRecords_GameRecordId",
                        column: x => x.GameRecordId,
                        principalTable: "GameRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameScreenshots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Caption = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CapturedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameScreenshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameScreenshots_GameRecords_GameRecordId",
                        column: x => x.GameRecordId,
                        principalTable: "GameRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameTags_GameRecords_GameRecordId",
                        column: x => x.GameRecordId,
                        principalTable: "GameRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrackings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsOwned = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasPlayed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsInBacklog = table.Column<bool>(type: "INTEGER", nullable: false),
                    WantsReplay = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateStarted = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    DateCompleted = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    HoursPlayed = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalTrackings_GameRecords_GameRecordId",
                        column: x => x.GameRecordId,
                        principalTable: "GameRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameDetailsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameGenres_GameDetails_GameDetailsId",
                        column: x => x.GameDetailsId,
                        principalTable: "GameDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenres_GameRecords_GameRecordId",
                        column: x => x.GameRecordId,
                        principalTable: "GameRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameAchievements_GameRecordId",
                table: "GameAchievements",
                column: "GameRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategories_GameRecordId",
                table: "GameCategories",
                column: "GameRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_GameRecordId",
                table: "GameDetails",
                column: "GameRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GameDetailsId",
                table: "GameGenres",
                column: "GameDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenres_GameRecordId",
                table: "GameGenres",
                column: "GameRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_GameReviews_GameRecordId",
                table: "GameReviews",
                column: "GameRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameScreenshots_GameRecordId",
                table: "GameScreenshots",
                column: "GameRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTags_GameRecordId",
                table: "GameTags",
                column: "GameRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrackings_GameRecordId",
                table: "PersonalTrackings",
                column: "GameRecordId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameAchievements");

            migrationBuilder.DropTable(
                name: "GameCategories");

            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "GameReviews");

            migrationBuilder.DropTable(
                name: "GameScreenshots");

            migrationBuilder.DropTable(
                name: "GameTags");

            migrationBuilder.DropTable(
                name: "PersonalTrackings");

            migrationBuilder.DropTable(
                name: "GameDetails");

            migrationBuilder.DropTable(
                name: "GameRecords");
        }
    }
}
