using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Porfolio.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerReviewFileDetailsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDetails",
                table: "CustomerReviews");

            migrationBuilder.AddColumn<int>(
                name: "FileDetailsId",
                table: "CustomerReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerReviews_FileDetailsId",
                table: "CustomerReviews",
                column: "FileDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerReviews_FileDetails_FileDetailsId",
                table: "CustomerReviews",
                column: "FileDetailsId",
                principalTable: "FileDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerReviews_FileDetails_FileDetailsId",
                table: "CustomerReviews");

            migrationBuilder.DropTable(
                name: "FileDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerReviews_FileDetailsId",
                table: "CustomerReviews");

            migrationBuilder.DropColumn(
                name: "FileDetailsId",
                table: "CustomerReviews");

            migrationBuilder.AddColumn<string>(
                name: "FileDetails",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
