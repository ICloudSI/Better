using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Coins = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantsMatch",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HomeId = table.Column<Guid>(nullable: true),
                    AwayId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantsMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantsMatch_Participants_AwayId",
                        column: x => x.AwayId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantsMatch_Participants_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParticipantsId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    BeginsAt = table.Column<DateTime>(nullable: false),
                    WinnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_ParticipantsMatch_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "ParticipantsMatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Participants_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ParticipantsId",
                table: "Matches",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerId",
                table: "Matches",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantsMatch_AwayId",
                table: "ParticipantsMatch",
                column: "AwayId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantsMatch_HomeId",
                table: "ParticipantsMatch",
                column: "HomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ParticipantsMatch");

            migrationBuilder.DropTable(
                name: "Participants");
        }
    }
}
