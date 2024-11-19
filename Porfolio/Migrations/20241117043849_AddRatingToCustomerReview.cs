using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Porfolio.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingToCustomerReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "CustomerReviews");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "CustomerReviews");

            migrationBuilder.RenameColumn(
                name: "ReviewDate",
                table: "CustomerReviews",
                newName: "ReviewTime");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomerReviews",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quotation",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewDescription",
                table: "CustomerReviews",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CustomerReviews");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "CustomerReviews");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomerReviews");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "CustomerReviews");

            migrationBuilder.DropColumn(
                name: "Quotation",
                table: "CustomerReviews");

            migrationBuilder.DropColumn(
                name: "ReviewDescription",
                table: "CustomerReviews");

            migrationBuilder.RenameColumn(
                name: "ReviewTime",
                table: "CustomerReviews",
                newName: "ReviewDate");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "CustomerReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
