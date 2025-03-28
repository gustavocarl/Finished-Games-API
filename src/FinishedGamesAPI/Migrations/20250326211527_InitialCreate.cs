using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinishedGamesAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinishedGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    Platform = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Grade = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishedGames", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinishedGames");
        }
    }
}
