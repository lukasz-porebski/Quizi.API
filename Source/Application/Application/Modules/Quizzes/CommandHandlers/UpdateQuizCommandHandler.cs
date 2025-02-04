using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Common.Application.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Modules.Quizzes.CommandHandlers;

public class UpdateQuizCommandHandler(IQuizRepository repository) : ICommandHandler<UpdateQuizCommand>
{
    public async Task Handle(UpdateQuizCommand command, CancellationToken cancellationToken)
    {
        var ownerId = AggregateId.Generate(); //TODO: Zamienić na użytkownika z contextu
        var quiz = await repository.GetOrThrowAsync(command.Id, ownerId, cancellationToken);
        quiz.Update(command.Data);

        await repository.PersistAsync(quiz, cancellationToken);
    }
}