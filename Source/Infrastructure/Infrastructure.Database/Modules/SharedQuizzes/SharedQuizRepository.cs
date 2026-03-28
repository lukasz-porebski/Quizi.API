using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Domain.Modules.SharedQuizzes.Models;
using LP.Common.Application.Contracts.User;
using LP.Common.Infrastructure.Database.EF;
using LP.Common.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Modules.SharedQuizzes;

public class SharedQuizRepository(
    AppDbContext context,
    IDateTimeProvider dateTimeProvider,
    IUserContextProvider userContextProvider
) : BaseRepository<SharedQuiz>(
    context,
    dateTimeProvider,
    userContextProvider,
    q => q.Include(e => e.Users)
), ISharedQuizRepository;