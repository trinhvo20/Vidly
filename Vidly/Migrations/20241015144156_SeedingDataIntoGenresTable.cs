using Microsoft.EntityFrameworkCore.Migrations;
using Vidly.Models;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataIntoGenresTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { nameof(Genre.Id), nameof(Genre.Name) },
                values: new object[,]
                {
                    {1, "Action" },
                    {2, "Thriller" },
                    {3, "Family" },
                    {4, "Romance" },
                    {5, "Comedy" },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
