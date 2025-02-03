using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSharedQuizzes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SharedQuizzes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedByUserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    RemovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedQuizzes_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SharedQuizUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedQuizUsers", x => new { x.Id, x.UserId });
                    table.ForeignKey(
                        name: "FK_SharedQuizUsers_SharedQuizzes_Id",
                        column: x => x.Id,
                        principalTable: "SharedQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedQuizUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SharedQuizUsers_UserId",
                table: "SharedQuizUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedQuizzes_OwnerId",
                table: "SharedQuizzes",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SharedQuizUsers");

            migrationBuilder.DropTable(
                name: "SharedQuizzes");
        }
    }
}
