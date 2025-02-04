using Application.Contracts.Modules.Quizzes.Interfaces;
using Common.Infrastructure.Database.EF;
using Common.Shared.Providers;
using Domain.Modules.Quizzes.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Modules.Quizzes;

public class QuizRepository(
    BaseDbContext context,
    IDateTimeProvider dateTimeProvider
) : BaseRepository<Quiz>(
    context,
    dateTimeProvider,
    q => q.Include(e => e.OpenQuestions)
        .Include(e => e.SingleChoiceQuestions)
        .ThenInclude(e => e.Answers)
        .Include(e => e.MultipleChoiceQuestions)
        .ThenInclude(e => e.Answers)
), IQuizRepository;