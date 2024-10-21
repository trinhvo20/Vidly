using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberAvailablePropInMoviesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Movie",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "NumberAvailable",
                table: "Movies",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_MovieId",
                table: "Rentals",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Movies_MovieId",
                table: "Rentals",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // My custom query to set NumberInStock = NumberAvailable when a movie is first created in Movies table.
            migrationBuilder.Sql(@"UPDATE Movies SET NumberAvailable = NumberInStock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Movies_MovieId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_MovieId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "NumberAvailable",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Movie",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
