using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    /// <inheritdoc />
    public partial class LNQCreate55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_OriginalBook_original_book_name",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_HasBeenWritten_OriginalBook_original_bookname",
                table: "HasBeenWritten");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineIssue_Reader_readers_ticket_code",
                table: "OnlineIssue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reader",
                table: "Reader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OriginalBook",
                table: "OriginalBook");

            migrationBuilder.RenameTable(
                name: "Reader",
                newName: "reader1");

            migrationBuilder.RenameTable(
                name: "OriginalBook",
                newName: "books");

            migrationBuilder.AlterColumn<string>(
                name: "nationality",
                table: "Author",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "literature_direction",
                table: "Author",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reader1",
                table: "reader1",
                column: "reader_ticket_code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "name");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "authorID",
                keyValue: 1,
                columns: new[] { "literature_direction", "surname_name_lastname" },
                values: new object[] { "romantism", "Taras Hrygorovich Shevchenko" });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_books_original_book_name",
                table: "Book",
                column: "original_book_name",
                principalTable: "books",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_HasBeenWritten_books_original_bookname",
                table: "HasBeenWritten",
                column: "original_bookname",
                principalTable: "books",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineIssue_reader1_readers_ticket_code",
                table: "OnlineIssue",
                column: "readers_ticket_code",
                principalTable: "reader1",
                principalColumn: "reader_ticket_code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_books_original_book_name",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_HasBeenWritten_books_original_bookname",
                table: "HasBeenWritten");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineIssue_reader1_readers_ticket_code",
                table: "OnlineIssue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reader1",
                table: "reader1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.RenameTable(
                name: "reader1",
                newName: "Reader");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "OriginalBook");

            migrationBuilder.AlterColumn<string>(
                name: "nationality",
                table: "Author",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "literature_direction",
                table: "Author",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reader",
                table: "Reader",
                column: "reader_ticket_code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OriginalBook",
                table: "OriginalBook",
                column: "name");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "authorID",
                keyValue: 1,
                columns: new[] { "literature_direction", "surname_name_lastname" },
                values: new object[] { null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_OriginalBook_original_book_name",
                table: "Book",
                column: "original_book_name",
                principalTable: "OriginalBook",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_HasBeenWritten_OriginalBook_original_bookname",
                table: "HasBeenWritten",
                column: "original_bookname",
                principalTable: "OriginalBook",
                principalColumn: "name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineIssue_Reader_readers_ticket_code",
                table: "OnlineIssue",
                column: "readers_ticket_code",
                principalTable: "Reader",
                principalColumn: "reader_ticket_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
