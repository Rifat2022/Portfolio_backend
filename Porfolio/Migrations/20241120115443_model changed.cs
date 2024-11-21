using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Porfolio.Migrations
{
    /// <inheritdoc />
    public partial class modelchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "CustomerReviews");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "CustomerReviews");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
