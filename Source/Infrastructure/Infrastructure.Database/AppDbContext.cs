using Common.Infrastructure.Database.EF;
using Domain.Modules.QuizResults.Models;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.SharedQuizzes.Models;
using Domain.Modules.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : BaseDbContext(options, typeof(AppDbContext).Assembly)
{
    public DbSet<User> Users { get; set; }

    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<QuizOpenQuestion> QuizOpenQuestions { get; set; }
    public DbSet<QuizSingleChoiceQuestion> QuizSingleChoiceQuestions { get; set; }
    public DbSet<QuizSingleChoiceQuestionAnswer> QuizSingleChoiceQuestionAnswers { get; set; }
    public DbSet<QuizMultipleChoiceQuestion> QuizMultipleChoiceQuestions { get; set; }
    public DbSet<QuizMultipleChoiceQuestionAnswer> QuizMultipleChoiceQuestionAnswers { get; set; }

    public DbSet<SharedQuiz> SharedQuizzes { get; set; }
    public DbSet<SharedQuizUser> SharedQuizUsers { get; set; }

    public DbSet<QuizResult> QuizResults { get; set; }
    public DbSet<QuizResultOpenQuestion> QuizResultOpenQuestions { get; set; }
    public DbSet<QuizResultSingleChoiceQuestion> QuizResultSingleChoiceQuestions { get; set; }
    public DbSet<QuizResultSingleChoiceQuestionAnswer> QuizResultSingleChoiceQuestionAnswers { get; set; }
    public DbSet<QuizResultMultipleChoiceQuestion> QuizResultMultipleChoiceQuestions { get; set; }
    public DbSet<QuizResultMultipleChoiceQuestionAnswer> QuizResultMultipleChoiceQuestionAnswers { get; set; }
}