using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Porfolio.Migrations
{
    /// <inheritdoc />
    public partial class FileDetailsnamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fileDetails",
                table: "CustomerReviews",
                newName: "FileDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileDetails",
                table: "CustomerReviews",
                newName: "fileDetails");
        }
    }
}
