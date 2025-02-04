using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Common.Infrastructure.Database.EF;
using Common.Shared.Providers;
using Domain.Modules.SharedQuizzes.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Modules.SharedQuizzes;

public class SharedQuizRepository(
    BaseDbContext context,
    IDateTimeProvider dateTimeProvider
) : BaseRepository<SharedQuiz>(
    context,
    dateTimeProvider,
    q => q.Include(e => e.Users)
), ISharedQuizRepository;