using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Common.Application.Contracts.User;
using Common.Infrastructure.Database.EF;
using Common.Shared.Providers;
using Domain.Modules.SharedQuizzes.Models;
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