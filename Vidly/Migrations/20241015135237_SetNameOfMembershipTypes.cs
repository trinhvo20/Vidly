using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class SetNameOfMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(table: "MembershipType", keyColumn: "Id", keyValue: 1, column: "Name", value: "Pay as You Go");
            migrationBuilder.UpdateData(table: "MembershipType", keyColumn: "Id", keyValue: 2, column: "Name", value: "Monthly");
            migrationBuilder.UpdateData(table: "MembershipType", keyColumn: "Id", keyValue: 3, column: "Name", value: "Quarterly");
            migrationBuilder.UpdateData(table: "MembershipType", keyColumn: "Id", keyValue: 4, column: "Name", value: "Yearly");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
