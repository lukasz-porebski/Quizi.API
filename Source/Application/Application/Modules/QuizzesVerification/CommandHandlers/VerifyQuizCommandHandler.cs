using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Application.Modules.QuizzesVerification.Extensions;
using Application.Modules.SharedQuizzes.Extensions;
using Common.Application.CQRS;
using Common.Domain.ValueObjects;
using Domain.Modules.QuizzesVerification.Interfaces;

namespace Application.Modules.QuizzesVerification.CommandHandlers;

public class VerifyQuizCommandHandler(
    IQuizRepository quizRepository,
    ISharedQuizRepository sharedQuizRepository,
    IVerifyQuizDomainService verifyQuizDomainService
) : ICommandHandler<VerifyQuizCommand>
{
    public async Task Handle(VerifyQuizCommand command, CancellationToken cancellationToken)
    {
        var ownerId = AggregateId.Generate(); //TODO: Zamienić na użytkownika z contextu
        await sharedQuizRepository.ExistsOrThrowAsync(command.Id, ownerId, cancellationToken);

        var quiz = await quizRepository.GetOrThrowAsync(command.Id, cancellationToken);
        var verificationResult = verifyQuizDomainService.Verify(command.ToVerificationData(quiz));
    }
}