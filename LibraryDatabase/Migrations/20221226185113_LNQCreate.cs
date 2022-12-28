using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    /// <inheritdoc />
    public partial class LNQCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "authorID",
                keyValue: 1,
                columns: new[] { "literature_direction", "surname_name_lastname" },
                values: new object[] { "romantism", "Taras Hrygorovich Shevchenko" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "authorID",
                keyValue: 1,
                columns: new[] { "literature_direction", "surname_name_lastname" },
                values: new object[] { null, null });
        }
    }
}
