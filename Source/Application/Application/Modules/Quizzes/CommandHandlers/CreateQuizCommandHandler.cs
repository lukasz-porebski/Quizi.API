using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Common.Application.CQRS;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Interfaces;

namespace Application.Modules.Quizzes.CommandHandlers;

public class CreateQuizCommandHandler(IQuizRepository repository, IQuizFactory quizFactory) : ICommandHandler<CreateQuizCommand>
{
    public async Task Handle(CreateQuizCommand command, CancellationToken cancellationToken)
    {
        var ownerId = AggregateId.Generate(); //TODO: Zamienić na użytkownika z contextu
        var quiz = quizFactory.Create(command.Id, command.ToData(ownerId));

        await repository.PersistAsync(quiz, cancellationToken);
    }
}