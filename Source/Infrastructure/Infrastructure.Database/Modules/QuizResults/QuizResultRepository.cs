using Application.Contracts.Modules.QuizResults.Interfaces;
using Domain.Modules.QuizResults.Models;
using LP.Common.Application.Contracts.User;
using LP.Common.Infrastructure.Database.EF;
using LP.Common.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Modules.QuizResults;

public class QuizResultRepository(
    AppDbContext context,
    IDateTimeProvider dateTimeProvider,
    IUserContextProvider userContextProvider
) : BaseRepository<QuizResult>(
    context,
    dateTimeProvider,
    userContextProvider,
    q => q.Include(e => e.OpenQuestions)
        .Include(e => e.SingleChoiceQuestions)
        .ThenInclude(e => e.Answers)
        .Include(e => e.MultipleChoiceQuestions)
        .ThenInclude(e => e.Answers)
), IQuizResultRepository;