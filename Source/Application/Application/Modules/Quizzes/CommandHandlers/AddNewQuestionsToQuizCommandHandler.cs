using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Common.Application.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Modules.Quizzes.CommandHandlers;

public class AddNewQuestionsToQuizCommandHandler(IQuizRepository repository) : ICommandHandler<AddNewQuestionsToQuizCommand>
{
    public async Task Handle(AddNewQuestionsToQuizCommand command, CancellationToken cancellationToken)
    {
        var ownerId = AggregateId.Generate(); //TODO: Zamienić na użytkownika z contextu
        var quiz = await repository.GetOrThrowAsync(command.Id, ownerId, cancellationToken);
        quiz.AddNewQuestions(command.Data);

        await repository.PersistAsync(quiz, cancellationToken);
    }
}