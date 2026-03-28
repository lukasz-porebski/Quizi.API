using Application.Contracts.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Models;
using LP.Common.Application.Contracts.User;
using LP.Common.Infrastructure.Database.EF;
using LP.Common.Shared.Providers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Modules.Quizzes;

public class QuizRepository(
    AppDbContext context,
    IDateTimeProvider dateTimeProvider,
    IUserContextProvider userContextProvider,
    IQuizSpecificationFactory specificationFactory
) : BaseRepository<Quiz>(
    context,
    dateTimeProvider,
    userContextProvider,
    q => q.Include(e => e.OpenQuestions)
        .Include(e => e.SingleChoiceQuestions)
        .ThenInclude(e => e.Answers)
        .Include(e => e.MultipleChoiceQuestions)
        .ThenInclude(e => e.Answers)
), IQuizRepository
{
    protected override void SetDependencies(Quiz aggregateRoot)
    {
        base.SetDependencies(aggregateRoot);
        aggregateRoot.SetDependencies(specificationFactory);
    }
}