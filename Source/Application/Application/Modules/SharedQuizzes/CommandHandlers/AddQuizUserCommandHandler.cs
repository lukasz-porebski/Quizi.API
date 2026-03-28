using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.SharedQuizzes.Commands;
using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Contracts.Modules.Users.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Application.Modules.Users.Extensions;
using Domain.Modules.SharedQuizzes.Interfaces;
using LP.Common.Application.Contracts.User;
using LP.Common.Application.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Modules.SharedQuizzes.CommandHandlers;

public class AddQuizUserCommandHandler(
    ISharedQuizRepository sharedQuizRepository,
    IUserRepository userRepository,
    IQuizRepository quizRepository,
    ISharedQuizFactory factory,
    IUserContextProvider userContextProvider
) : ICommandHandler<AddQuizUserCommand>
{
    public async Task Handle(AddQuizUserCommand command, CancellationToken cancellationToken)
    {
        var ownerId = userContextProvider.GetOrThrow().UserId;
        await userRepository.ExistsOrThrowAsync(command.UserId, cancellationToken);
        await quizRepository.ExistsOrThrowAsync(command.QuizId, ownerId, cancellationToken);

        var sharedQuiz = await sharedQuizRepository.GetAsync(q => q.QuizId == command.QuizId, cancellationToken);
        if (sharedQuiz is null)
            sharedQuiz = factory.Create(AggregateId.Generate(), ownerId, command.UserId);
        else
            sharedQuiz.AddUser(command.UserId);

        await sharedQuizRepository.PersistAsync(sharedQuiz, cancellationToken);
    }
}