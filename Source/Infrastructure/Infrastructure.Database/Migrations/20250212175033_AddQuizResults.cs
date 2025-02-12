using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizResults",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    QuizId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuizRunningPeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuizRunningPeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    NegativePoints = table.Column<bool>(type: "bit", nullable: false),
                    RandomQuestions = table.Column<bool>(type: "bit", nullable: false),
                    RandomAnswers = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_QuizResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizResults_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizResultMultipleChoiceQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ScoredPoints = table.Column<float>(type: "real", nullable: false),
                    PointsPossibleToGet = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResultMultipleChoiceQuestions", x => new { x.Id, x.No });
                    table.ForeignKey(
                        name: "FK_QuizResultMultipleChoiceQuestions_QuizResults_Id",
                        column: x => x.Id,
                        principalTable: "QuizResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizResultOpenQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GivenAnswer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ScoredPoints = table.Column<float>(type: "real", nullable: false),
                    PointsPossibleToGet = table.Column<float>(type: "real", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResultOpenQuestions", x => new { x.Id, x.No });
                    table.ForeignKey(
                        name: "FK_QuizResultOpenQuestions_QuizResults_Id",
                        column: x => x.Id,
                        principalTable: "QuizResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizResultSingleChoiceQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ScoredPoints = table.Column<float>(type: "real", nullable: false),
                    PointsPossibleToGet = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResultSingleChoiceQuestions", x => new { x.Id, x.No });
                    table.ForeignKey(
                        name: "FK_QuizResultSingleChoiceQuestions_QuizResults_Id",
                        column: x => x.Id,
                        principalTable: "QuizResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizResultMultipleChoiceQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    SubNo = table.Column<int>(type: "int", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResultMultipleChoiceQuestionAnswers", x => new { x.Id, x.No, x.SubNo });
                    table.ForeignKey(
                        name: "FK_QuizResultMultipleChoiceQuestionAnswers_QuizResultMultipleChoiceQuestions_Id_No",
                        columns: x => new { x.Id, x.No },
                        principalTable: "QuizResultMultipleChoiceQuestions",
                        principalColumns: new[] { "Id", "No" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizResultSingleChoiceQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    SubNo = table.Column<int>(type: "int", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResultSingleChoiceQuestionAnswers", x => new { x.Id, x.No, x.SubNo });
                    table.ForeignKey(
                        name: "FK_QuizResultSingleChoiceQuestionAnswers_QuizResultSingleChoiceQuestions_Id_No",
                        columns: x => new { x.Id, x.No },
                        principalTable: "QuizResultSingleChoiceQuestions",
                        principalColumns: new[] { "Id", "No" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_QuizId",
                table: "QuizResults",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_UserId",
                table: "QuizResults",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizResultMultipleChoiceQuestionAnswers");

            migrationBuilder.DropTable(
                name: "QuizResultOpenQuestions");

            migrationBuilder.DropTable(
                name: "QuizResultSingleChoiceQuestionAnswers");

            migrationBuilder.DropTable(
                name: "QuizResultMultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "QuizResultSingleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "QuizResults");
        }
    }
}
