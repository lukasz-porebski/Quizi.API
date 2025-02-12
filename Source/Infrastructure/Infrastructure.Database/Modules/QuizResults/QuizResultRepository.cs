using Application.Contracts.Modules.QuizResults.Interfaces;
using Common.Infrastructure.Database.EF;
using Common.Shared.Providers;
using Domain.Modules.QuizResults.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Modules.QuizResults;

public class QuizResultRepository(
    BaseDbContext context,
    IDateTimeProvider dateTimeProvider
) : BaseRepository<QuizResult>(
    context,
    dateTimeProvider,
    q => q.Include(e => e.OpenQuestions)
        .Include(e => e.SingleChoiceQuestions)
        .ThenInclude(e => e.Answers)
        .Include(e => e.MultipleChoiceQuestions)
        .ThenInclude(e => e.Answers)
), IQuizResultRepository;