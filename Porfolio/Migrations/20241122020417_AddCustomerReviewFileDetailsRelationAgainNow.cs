using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Porfolio.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerReviewFileDetailsRelationAgainNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FileDetails",
                newName: "FileDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileDetailsId",
                table: "FileDetails",
                newName: "Id");
        }
    }
}
