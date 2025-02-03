using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizzes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    QuestionsCountInRunningQuiz = table.Column<int>(type: "int", nullable: false),
                    RandomQuestions = table.Column<bool>(type: "bit", nullable: false),
                    RandomAnswers = table.Column<bool>(type: "bit", nullable: false),
                    NegativePoints = table.Column<bool>(type: "bit", nullable: false),
                    CopyMode = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizMultipleChoiceQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizMultipleChoiceQuestions", x => new { x.Id, x.No });
                    table.ForeignKey(
                        name: "FK_QuizMultipleChoiceQuestions_Quizzes_Id",
                        column: x => x.Id,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizOpenQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizOpenQuestions", x => new { x.Id, x.No });
                    table.ForeignKey(
                        name: "FK_QuizOpenQuestions_Quizzes_Id",
                        column: x => x.Id,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizSingleChoiceQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSingleChoiceQuestions", x => new { x.Id, x.No });
                    table.ForeignKey(
                        name: "FK_QuizSingleChoiceQuestions_Quizzes_Id",
                        column: x => x.Id,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizMultipleChoiceQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    SubNo = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizMultipleChoiceQuestionAnswers", x => new { x.Id, x.No });
                    table.ForeignKey(
                        name: "FK_QuizMultipleChoiceQuestionAnswers_QuizMultipleChoiceQuestions_Id_No",
                        columns: x => new { x.Id, x.No },
                        principalTable: "QuizMultipleChoiceQuestions",
                        principalColumns: new[] { "Id", "No" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizSingleChoiceQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    SubNo = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSingleChoiceQuestionAnswers", x => new { x.Id, x.No });
                    table.ForeignKey(
                        name: "FK_QuizSingleChoiceQuestionAnswers_QuizSingleChoiceQuestions_Id_No",
                        columns: x => new { x.Id, x.No },
                        principalTable: "QuizSingleChoiceQuestions",
                        principalColumns: new[] { "Id", "No" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_OwnerId",
                table: "Quizzes",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizMultipleChoiceQuestionAnswers");

            migrationBuilder.DropTable(
                name: "QuizOpenQuestions");

            migrationBuilder.DropTable(
                name: "QuizSingleChoiceQuestionAnswers");

            migrationBuilder.DropTable(
                name: "QuizMultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "QuizSingleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
