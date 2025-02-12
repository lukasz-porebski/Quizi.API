using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Common.Application.Contracts.User;
using Common.Application.CQRS;

namespace Application.Modules.Quizzes.CommandHandlers;

public class RemoveQuizCommandHandler(
    IQuizRepository quizRepository,
    ISharedQuizRepository sharedQuizRepository,
    IUserContextProvider userContextProvider
) : ICommandHandler<RemoveQuizCommand>
{
    public async Task Handle(RemoveQuizCommand command, CancellationToken cancellationToken)
    {
        var quiz = await quizRepository.GetOrThrowAsync(command.Id, userContextProvider.GetOrThrow().UserId, cancellationToken);
        var sharedQuiz = await sharedQuizRepository.GetAsync(command.Id, cancellationToken);

        await quizRepository.RemoveAsync(quiz, cancellationToken, save: false);
        if (sharedQuiz != null)
            await sharedQuizRepository.RemoveAsync(sharedQuiz, cancellationToken, save: false);

        await quizRepository.SaveAsync(cancellationToken);
    }
}