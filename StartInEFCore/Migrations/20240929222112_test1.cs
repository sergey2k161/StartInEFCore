using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartInEFCore.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    MoveStudioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    MoveStudioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieStudios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Discription = table.Column<string>(type: "text", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStudios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieStudios_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovieStudio",
                columns: table => new
                {
                    ActorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MovieStudiosId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovieStudio", x => new { x.ActorsId, x.MovieStudiosId });
                    table.ForeignKey(
                        name: "FK_ActorMovieStudio_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovieStudio_MovieStudios_MovieStudiosId",
                        column: x => x.MovieStudiosId,
                        principalTable: "MovieStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    MoveStudioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_MovieStudios_MoveStudioId",
                        column: x => x.MoveStudioId,
                        principalTable: "MovieStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovieStudio_MovieStudiosId",
                table: "ActorMovieStudio",
                column: "MovieStudiosId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_MoveStudioId",
                table: "Films",
                column: "MoveStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStudios_DirectorId",
                table: "MovieStudios",
                column: "DirectorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovieStudio");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "MovieStudios");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
