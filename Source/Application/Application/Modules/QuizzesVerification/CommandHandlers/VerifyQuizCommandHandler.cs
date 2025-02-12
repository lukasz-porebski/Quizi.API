using Application.Contracts.Modules.QuizResults.Interfaces;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Modules.Quizzes.Extensions;
using Application.Modules.QuizzesVerification.Extensions;
using Application.Modules.SharedQuizzes.Extensions;
using Common.Application.CQRS;
using Common.Domain.ValueObjects;
using Domain.Modules.QuizResults.Interfaces;
using Domain.Modules.QuizzesVerification.Interfaces;

namespace Application.Modules.QuizzesVerification.CommandHandlers;

public class VerifyQuizCommandHandler(
    IQuizRepository quizRepository,
    ISharedQuizRepository sharedQuizRepository,
    IVerifyQuizDomainService verifyQuizDomainService,
    IQuizResultRepository quizResultRepository,
    IQuizResultFactory quizResultFactory
) : ICommandHandler<VerifyQuizCommand>
{
    public async Task Handle(VerifyQuizCommand command, CancellationToken cancellationToken)
    {
        var userId = AggregateId.Generate(); //TODO: Zamienić na użytkownika z contextu
        await sharedQuizRepository.ExistsOrThrowAsync(command.QuizId, userId, cancellationToken);

        var quiz = await quizRepository.GetOrThrowAsync(command.QuizId, cancellationToken);
        var verificationResult = verifyQuizDomainService.Verify(command.ToVerificationData(quiz));

        var quizResult = quizResultFactory.Create(command.QuizResulId, verificationResult.ToResultData(command, quiz, userId));
        await quizResultRepository.PersistAsync(quizResult, cancellationToken);
    }
}