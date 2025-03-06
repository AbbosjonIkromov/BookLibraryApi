using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class isbnUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "ak_books_isbn",
                table: "books",
                column: "isbn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "ak_books_isbn",
                table: "books");
        }
    }
}
