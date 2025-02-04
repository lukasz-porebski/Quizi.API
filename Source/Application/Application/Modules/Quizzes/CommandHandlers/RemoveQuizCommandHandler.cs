using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Common.Application.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Modules.Quizzes.CommandHandlers;

public class RemoveQuizCommandHandler(
    IQuizRepository quizRepository,
    ISharedQuizRepository sharedQuizRepository
) : ICommandHandler<RemoveQuizCommand>
{
    public async Task Handle(RemoveQuizCommand command, CancellationToken cancellationToken)
    {
        var ownerId = AggregateId.Generate(); //TODO: Zamienić na użytkownika z contextu
        var quiz = await quizRepository.GetOrThrowAsync(command.Id, ownerId, cancellationToken);
        var sharedQuiz = await sharedQuizRepository.GetAsync(command.Id, cancellationToken);

        await quizRepository.RemoveAsync(quiz, cancellationToken, save: false);
        if (sharedQuiz != null)
            await sharedQuizRepository.RemoveAsync(sharedQuiz, cancellationToken, save: false);

        await quizRepository.SaveAsync(cancellationToken);
    }
}