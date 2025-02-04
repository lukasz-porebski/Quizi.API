using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.SharedQuizzes.Commands;
using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Contracts.Modules.Users.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Application.Modules.SharedQuizzes.Extensions;
using Application.Modules.Users.Extensions;
using Common.Application.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Modules.SharedQuizzes.CommandHandlers;

public class RemoveQuizUserCommandHandler(
    ISharedQuizRepository sharedQuizRepository,
    IUserRepository userRepository,
    IQuizRepository quizRepository
) : ICommandHandler<RemoveQuizUserCommand>
{
    public async Task Handle(RemoveQuizUserCommand command, CancellationToken cancellationToken)
    {
        var ownerId = AggregateId.Generate(); //TODO: Zamienić na użytkownika z contextu
        await userRepository.ExistsOrThrowAsync(command.UserId, cancellationToken);
        await quizRepository.ExistsOrThrowAsync(command.QuizId, ownerId, cancellationToken);

        var sharedQuiz = await sharedQuizRepository.GetOrThrowAsync(command.QuizId, cancellationToken);
        sharedQuiz.RemoveUser(command.UserId);

        await sharedQuizRepository.PersistAsync(sharedQuiz, cancellationToken);
    }
}