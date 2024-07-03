using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookBorrowingLibrary.Migrations
{
    public partial class UpdateMyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingTransactions_BookId",
                table: "BorrowingTransactions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingTransactions_UserId",
                table: "BorrowingTransactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingTransactions_Books_BookId",
                table: "BorrowingTransactions",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingTransactions_Users_UserId",
                table: "BorrowingTransactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingTransactions_Books_BookId",
                table: "BorrowingTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingTransactions_Users_UserId",
                table: "BorrowingTransactions");

            migrationBuilder.DropIndex(
                name: "IX_BorrowingTransactions_BookId",
                table: "BorrowingTransactions");

            migrationBuilder.DropIndex(
                name: "IX_BorrowingTransactions_UserId",
                table: "BorrowingTransactions");

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BooksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BookUser_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UsersId",
                table: "BookUser",
                column: "UsersId");
        }
    }
}
