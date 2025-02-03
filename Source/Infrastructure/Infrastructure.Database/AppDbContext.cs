using Common.Infrastructure.Database.EF;
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
}