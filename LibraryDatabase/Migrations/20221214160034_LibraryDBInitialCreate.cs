using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabase.Migrations
{
    /// <inheritdoc />
    public partial class LibraryDBInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    authorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nationality = table.Column<int>(type: "INTEGER", nullable: false),
                    literaturedirection = table.Column<int>(name: "literature_direction", type: "INTEGER", nullable: false),
                    surnamenamelastname = table.Column<int>(name: "surname_name_lastname", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.authorID);
                });

            migrationBuilder.CreateTable(
                name: "OriginalBook",
                columns: table => new
                {
                    name = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<int>(type: "INTEGER", nullable: false),
                    yearofwriting = table.Column<int>(name: "year_of_writing", type: "INTEGER", nullable: false),
                    countofpages = table.Column<int>(name: "count_of_pages", type: "INTEGER", nullable: false),
                    literaturedirection = table.Column<int>(name: "literature_direction", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginalBook", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "PublishingHouse",
                columns: table => new
                {
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    countofprintingperyear = table.Column<int>(name: "count_of_printing_per_year", type: "INTEGER", nullable: false),
                    literaturedirection = table.Column<int>(name: "literature_direction", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingHouse", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    readerticketcode = table.Column<int>(name: "reader_ticket_code", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dataofbirth = table.Column<int>(name: "data_of_birth", type: "INTEGER", nullable: false),
                    placeofliving = table.Column<int>(name: "place_of_living", type: "INTEGER", nullable: false),
                    phone = table.Column<int>(type: "INTEGER", nullable: false),
                    surnamenamelastname = table.Column<int>(name: "surname_name_lastname", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.readerticketcode);
                });

            migrationBuilder.CreateTable(
                name: "WorkInHall",
                columns: table => new
                {
                    passportcodeandseries = table.Column<int>(name: "passport_code_and_series", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    hallcode = table.Column<int>(name: "hall_code", type: "INTEGER", nullable: false),
                    dateofwork = table.Column<int>(name: "date_of_work", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkInHall", x => x.passportcodeandseries);
                });

            migrationBuilder.CreateTable(
                name: "HasBeenWritten",
                columns: table => new
                {
                    authorcode = table.Column<int>(name: "author_code", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bookcode = table.Column<int>(name: "book_code", type: "INTEGER", nullable: false),
                    authorID = table.Column<int>(type: "INTEGER", nullable: false),
                    originalbookname = table.Column<int>(name: "original_bookname", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasBeenWritten", x => x.authorcode);
                    table.ForeignKey(
                        name: "FK_HasBeenWritten_Author_authorID",
                        column: x => x.authorID,
                        principalTable: "Author",
                        principalColumn: "authorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HasBeenWritten_OriginalBook_original_bookname",
                        column: x => x.originalbookname,
                        principalTable: "OriginalBook",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    bookIDindatabase = table.Column<int>(name: "book_ID_in_database", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<int>(type: "INTEGER", nullable: false),
                    yearofwriting = table.Column<int>(name: "year_of_writing", type: "INTEGER", nullable: false),
                    publishinghouse = table.Column<int>(name: "publishing_house", type: "INTEGER", nullable: false),
                    countofcopyes = table.Column<int>(name: "count_of_copyes", type: "INTEGER", nullable: false),
                    countofpages = table.Column<int>(name: "count_of_pages", type: "INTEGER", nullable: false),
                    literarydirection = table.Column<int>(name: "literary_direction", type: "INTEGER", nullable: false),
                    code = table.Column<int>(type: "INTEGER", nullable: false),
                    originalbookname = table.Column<int>(name: "original_book_name", type: "INTEGER", nullable: true),
                    publishinghousename = table.Column<string>(name: "publishing_house_name", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.bookIDindatabase);
                    table.ForeignKey(
                        name: "FK_Book_OriginalBook_original_book_name",
                        column: x => x.originalbookname,
                        principalTable: "OriginalBook",
                        principalColumn: "name");
                    table.ForeignKey(
                        name: "FK_Book_PublishingHouse_publishing_house_name",
                        column: x => x.publishinghousename,
                        principalTable: "PublishingHouse",
                        principalColumn: "name");
                });

            migrationBuilder.CreateTable(
                name: "OnlineIssue",
                columns: table => new
                {
                    issuecode = table.Column<int>(name: "issue_code", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    readersticketcode = table.Column<int>(name: "readers_ticket_code", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineIssue", x => x.issuecode);
                    table.ForeignKey(
                        name: "FK_OnlineIssue_Reader_readers_ticket_code",
                        column: x => x.readersticketcode,
                        principalTable: "Reader",
                        principalColumn: "reader_ticket_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Readerhall",
                columns: table => new
                {
                    hallcode = table.Column<int>(name: "hall_code", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    countoftables = table.Column<int>(name: "count_of_tables", type: "INTEGER", nullable: false),
                    countofshelves = table.Column<int>(name: "count_of_shelves", type: "INTEGER", nullable: false),
                    workinhallpassportcodeandseries = table.Column<int>(name: "work_in_hall_passport_code_and_series", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readerhall", x => x.hallcode);
                    table.ForeignKey(
                        name: "FK_Readerhall_WorkInHall_work_in_hall_passport_code_and_series",
                        column: x => x.workinhallpassportcodeandseries,
                        principalTable: "WorkInHall",
                        principalColumn: "passport_code_and_series",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    passportcodeandseries = table.Column<int>(name: "passport_code_and_series", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dataofbirth = table.Column<int>(name: "data_of_birth", type: "INTEGER", nullable: false),
                    workinhallpassportcodeandseries = table.Column<int>(name: "work_in_hall_passport_code_and_series", type: "INTEGER", nullable: false),
                    surnamenamelastname = table.Column<int>(name: "surname_name_lastname", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.passportcodeandseries);
                    table.ForeignKey(
                        name: "FK_Worker_WorkInHall_work_in_hall_passport_code_and_series",
                        column: x => x.workinhallpassportcodeandseries,
                        principalTable: "WorkInHall",
                        principalColumn: "passport_code_and_series",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCopy",
                columns: table => new
                {
                    inventorycode = table.Column<int>(name: "inventory_code", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    databasebookcode = table.Column<int>(name: "database_book_code", type: "INTEGER", nullable: false),
                    bookIDindatabase = table.Column<int>(name: "book_ID_in_database", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopy", x => x.inventorycode);
                    table.ForeignKey(
                        name: "FK_BookCopy_Book_book_ID_in_database",
                        column: x => x.bookIDindatabase,
                        principalTable: "Book",
                        principalColumn: "book_ID_in_database",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookIssue",
                columns: table => new
                {
                    issuecode = table.Column<int>(name: "issue_code", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    inventorycode = table.Column<int>(name: "inventory_code", type: "INTEGER", nullable: false),
                    daystoissueexpire = table.Column<int>(name: "days_to_issue_expire", type: "INTEGER", nullable: false),
                    worker = table.Column<int>(type: "INTEGER", nullable: false),
                    dateofissue = table.Column<int>(name: "date_of_issue", type: "INTEGER", nullable: false),
                    dateofreturningbook = table.Column<int>(name: "date_of_returning_book", type: "INTEGER", nullable: false),
                    countofpledge = table.Column<int>(name: "count_of_pledge", type: "INTEGER", nullable: false),
                    bookcopyinventorycode = table.Column<int>(name: "book_copy_inventory_code", type: "INTEGER", nullable: false),
                    onlinebookissueissuecode = table.Column<int>(name: "online_book_issueissue_code", type: "INTEGER", nullable: false),
                    workerpassportcodeandseries = table.Column<int>(name: "worker_passport_code_and_series", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookIssue", x => x.issuecode);
                    table.ForeignKey(
                        name: "FK_BookIssue_BookCopy_book_copy_inventory_code",
                        column: x => x.bookcopyinventorycode,
                        principalTable: "BookCopy",
                        principalColumn: "inventory_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookIssue_OnlineIssue_online_book_issueissue_code",
                        column: x => x.onlinebookissueissuecode,
                        principalTable: "OnlineIssue",
                        principalColumn: "issue_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookIssue_Worker_worker_passport_code_and_series",
                        column: x => x.workerpassportcodeandseries,
                        principalTable: "Worker",
                        principalColumn: "passport_code_and_series",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookIssueInHall",
                columns: table => new
                {
                    hallcode = table.Column<int>(name: "hall_code", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    issuecode = table.Column<int>(name: "issue_code", type: "INTEGER", nullable: false),
                    bookissueissuecode = table.Column<int>(name: "book_issue_issue_code", type: "INTEGER", nullable: false),
                    readerhallhallcode = table.Column<int>(name: "reader_hall_hall_code", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookIssueInHall", x => x.hallcode);
                    table.ForeignKey(
                        name: "FK_BookIssueInHall_BookIssue_book_issue_issue_code",
                        column: x => x.bookissueissuecode,
                        principalTable: "BookIssue",
                        principalColumn: "issue_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookIssueInHall_Readerhall_reader_hall_hall_code",
                        column: x => x.readerhallhallcode,
                        principalTable: "Readerhall",
                        principalColumn: "hall_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_original_book_name",
                table: "Book",
                column: "original_book_name");

            migrationBuilder.CreateIndex(
                name: "IX_Book_publishing_house_name",
                table: "Book",
                column: "publishing_house_name");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_book_ID_in_database",
                table: "BookCopy",
                column: "book_ID_in_database");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_book_copy_inventory_code",
                table: "BookIssue",
                column: "book_copy_inventory_code");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_online_book_issueissue_code",
                table: "BookIssue",
                column: "online_book_issueissue_code");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssue_worker_passport_code_and_series",
                table: "BookIssue",
                column: "worker_passport_code_and_series");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssueInHall_book_issue_issue_code",
                table: "BookIssueInHall",
                column: "book_issue_issue_code");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssueInHall_reader_hall_hall_code",
                table: "BookIssueInHall",
                column: "reader_hall_hall_code");

            migrationBuilder.CreateIndex(
                name: "IX_HasBeenWritten_authorID",
                table: "HasBeenWritten",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "IX_HasBeenWritten_original_bookname",
                table: "HasBeenWritten",
                column: "original_bookname");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineIssue_readers_ticket_code",
                table: "OnlineIssue",
                column: "readers_ticket_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Readerhall_work_in_hall_passport_code_and_series",
                table: "Readerhall",
                column: "work_in_hall_passport_code_and_series");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_work_in_hall_passport_code_and_series",
                table: "Worker",
                column: "work_in_hall_passport_code_and_series");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookIssueInHall");

            migrationBuilder.DropTable(
                name: "HasBeenWritten");

            migrationBuilder.DropTable(
                name: "BookIssue");

            migrationBuilder.DropTable(
                name: "Readerhall");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "BookCopy");

            migrationBuilder.DropTable(
                name: "OnlineIssue");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.DropTable(
                name: "WorkInHall");

            migrationBuilder.DropTable(
                name: "OriginalBook");

            migrationBuilder.DropTable(
                name: "PublishingHouse");
        }
    }
}
