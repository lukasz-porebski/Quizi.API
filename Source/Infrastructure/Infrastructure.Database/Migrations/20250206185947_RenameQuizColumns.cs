using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameQuizColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SharedQuizzes_Users_OwnerId",
                table: "SharedQuizzes");

            migrationBuilder.DropIndex(
                name: "IX_SharedQuizzes_OwnerId",
                table: "SharedQuizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizSingleChoiceQuestionAnswers",
                table: "QuizSingleChoiceQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizMultipleChoiceQuestionAnswers",
                table: "QuizMultipleChoiceQuestionAnswers");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "SharedQuizzes",
                newName: "QuizId");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "QuizSingleChoiceQuestions",
                newName: "OrdinalNumber");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "QuizSingleChoiceQuestionAnswers",
                newName: "OrdinalNumber");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "QuizOpenQuestions",
                newName: "OrdinalNumber");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "QuizMultipleChoiceQuestions",
                newName: "OrdinalNumber");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "QuizMultipleChoiceQuestionAnswers",
                newName: "OrdinalNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizSingleChoiceQuestionAnswers",
                table: "QuizSingleChoiceQuestionAnswers",
                columns: new[] { "Id", "No", "SubNo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizMultipleChoiceQuestionAnswers",
                table: "QuizMultipleChoiceQuestionAnswers",
                columns: new[] { "Id", "No", "SubNo" });

            migrationBuilder.CreateIndex(
                name: "IX_SharedQuizzes_QuizId",
                table: "SharedQuizzes",
                column: "QuizId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SharedQuizzes_Quizzes_QuizId",
                table: "SharedQuizzes",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SharedQuizzes_Quizzes_QuizId",
                table: "SharedQuizzes");

            migrationBuilder.DropIndex(
                name: "IX_SharedQuizzes_QuizId",
                table: "SharedQuizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizSingleChoiceQuestionAnswers",
                table: "QuizSingleChoiceQuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizMultipleChoiceQuestionAnswers",
                table: "QuizMultipleChoiceQuestionAnswers");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "SharedQuizzes",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "OrdinalNumber",
                table: "QuizSingleChoiceQuestions",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "OrdinalNumber",
                table: "QuizSingleChoiceQuestionAnswers",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "OrdinalNumber",
                table: "QuizOpenQuestions",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "OrdinalNumber",
                table: "QuizMultipleChoiceQuestions",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "OrdinalNumber",
                table: "QuizMultipleChoiceQuestionAnswers",
                newName: "OrderNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizSingleChoiceQuestionAnswers",
                table: "QuizSingleChoiceQuestionAnswers",
                columns: new[] { "Id", "No" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizMultipleChoiceQuestionAnswers",
                table: "QuizMultipleChoiceQuestionAnswers",
                columns: new[] { "Id", "No" });

            migrationBuilder.CreateIndex(
                name: "IX_SharedQuizzes_OwnerId",
                table: "SharedQuizzes",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SharedQuizzes_Users_OwnerId",
                table: "SharedQuizzes",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
