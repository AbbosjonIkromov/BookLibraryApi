using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHub.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class changeIsbnKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "ak_books_isbn",
                table: "books");

            migrationBuilder.CreateIndex(
                name: "ix_books_isbn",
                table: "books",
                column: "isbn",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_books_isbn",
                table: "books");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_books_isbn",
                table: "books",
                column: "isbn");
        }
    }
}
