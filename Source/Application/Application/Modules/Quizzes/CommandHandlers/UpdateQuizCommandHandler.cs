using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Common.Application.Contracts.User;
using Common.Application.CQRS;

namespace Application.Modules.Quizzes.CommandHandlers;

public class UpdateQuizCommandHandler(
    IQuizRepository repository,
    IUserContextProvider userContextProvider
) : ICommandHandler<UpdateQuizCommand>
{
    public async Task Handle(UpdateQuizCommand command, CancellationToken cancellationToken)
    {
        var ownerId = userContextProvider.GetOrThrow().UserId;
        var quiz = await repository.GetOrThrowAsync(command.Id, ownerId, cancellationToken);
        quiz.Update(command.ToData(ownerId));

        await repository.PersistAsync(quiz, cancellationToken);
    }
}