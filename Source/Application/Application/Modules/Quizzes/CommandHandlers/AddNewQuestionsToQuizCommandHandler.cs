using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Common.Application.Contracts.User;
using Common.Application.CQRS;

namespace Application.Modules.Quizzes.CommandHandlers;

public class AddNewQuestionsToQuizCommandHandler(
    IQuizRepository repository,
    IUserContextProvider userContextProvider
) : ICommandHandler<AddNewQuestionsToQuizCommand>
{
    public async Task Handle(AddNewQuestionsToQuizCommand command, CancellationToken cancellationToken)
    {
        var quiz = await repository.GetOrThrowAsync(command.Id, userContextProvider.GetOrThrow().UserId, cancellationToken);
        quiz.AddNewQuestions(command.Data);

        await repository.PersistAsync(quiz, cancellationToken);
    }
}