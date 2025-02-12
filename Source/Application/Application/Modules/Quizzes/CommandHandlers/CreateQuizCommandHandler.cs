using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Common.Application.Contracts.User;
using Common.Application.CQRS;
using Domain.Modules.Quizzes.Interfaces;

namespace Application.Modules.Quizzes.CommandHandlers;

public class CreateQuizCommandHandler(
    IQuizRepository repository,
    IQuizFactory quizFactory,
    IUserContextProvider userContextProvider
) : ICommandHandler<CreateQuizCommand>
{
    public async Task Handle(CreateQuizCommand command, CancellationToken cancellationToken)
    {
        var quiz = quizFactory.Create(command.Id, command.ToData(userContextProvider.GetOrThrow().UserId));

        await repository.PersistAsync(quiz, cancellationToken);
    }
}