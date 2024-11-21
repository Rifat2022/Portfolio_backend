using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Porfolio.Migrations
{
    /// <inheritdoc />
    public partial class fileDetailspropertyofCustomerReviewischangedtostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "CustomerReviews",
                newName: "fileDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewTime",
                table: "CustomerReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fileDetails",
                table: "CustomerReviews",
                newName: "FilePath");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewTime",
                table: "CustomerReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
