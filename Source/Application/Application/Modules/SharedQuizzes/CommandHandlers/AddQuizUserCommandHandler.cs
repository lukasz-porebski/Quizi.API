using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.SharedQuizzes.Commands;
using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Contracts.Modules.Users.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Application.Modules.Users.Extensions;
using Common.Application.CQRS;
using Common.Domain.ValueObjects;
using Domain.Modules.SharedQuizzes.Interfaces;

namespace Application.Modules.SharedQuizzes.CommandHandlers;

public class AddQuizUserCommandHandler(
    ISharedQuizRepository sharedQuizRepository,
    IUserRepository userRepository,
    IQuizRepository quizRepository,
    ISharedQuizFactory factory
) : ICommandHandler<AddQuizUserCommand>
{
    public async Task Handle(AddQuizUserCommand command, CancellationToken cancellationToken)
    {
        var ownerId = AggregateId.Generate(); //TODO: Zamienić na użytkownika z contextu
        await userRepository.ExistsOrThrowAsync(command.UserId, cancellationToken);
        await quizRepository.ExistsOrThrowAsync(command.QuizId, ownerId, cancellationToken);

        var sharedQuiz = await sharedQuizRepository.GetAsync(q => q.QuizId == command.QuizId, cancellationToken);
        if (sharedQuiz is null)
            sharedQuiz = factory.Create(AggregateId.Generate(), ownerId, command.UserId);
        else
            sharedQuiz.AddUser(command.UserId);

        await sharedQuizRepository.PersistAsync(sharedQuiz, cancellationToken);
    }
}