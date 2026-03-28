using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Domain.Modules.Quizzes.Interfaces;
using LP.Common.Application.Contracts.User;
using LP.Common.Application.CQRS;

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