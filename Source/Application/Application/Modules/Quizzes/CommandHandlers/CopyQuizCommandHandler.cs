using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Interfaces;
using Application.Contracts.Modules.SharedQuizzes.Interfaces;
using Application.Modules.Quizzes.Constants;
using Application.Modules.Quizzes.Extensions;
using Common.Application.CQRS;
using Common.Application.Exceptions;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes;
using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Enums;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.Models;

namespace Application.Modules.Quizzes.CommandHandlers;

public class CopyQuizCommandHandler(
    IQuizRepository quizRepository,
    ISharedQuizRepository sharedQuizRepository,
    IQuizFactory factory
) : ICommandHandler<CopyQuizCommand>
{
    public async Task Handle(CopyQuizCommand command, CancellationToken cancellationToken)
    {
        var ownerId = AggregateId.Generate(); //TODO: Zamienić na użytkownika z contextu
        var quiz = await quizRepository.GetOrThrowAsync(command.Code, cancellationToken);
        await Validate(quiz, ownerId, cancellationToken);

        var newQuiz = factory.Create(command.NewQuizId, GetQuizPersistData(quiz, ownerId));
        await quizRepository.PersistAsync(newQuiz, cancellationToken);
    }

    private async Task Validate(Quiz quiz, AggregateId userId, CancellationToken cancellationToken)
    {
        switch (quiz.Settings.CopyMode)
        {
            case QuizCopyMode.Disable:
                throw new BusinessLogicException(QuizMessageCodes.CopyDenied);
            case QuizCopyMode.OnlyForAddedUsers:
                var existsSharedQuiz = await sharedQuizRepository.ExistsAsync(q =>
                    q.QuizId == userId || q.Users.Any(u => u.UserId == userId), cancellationToken);
                if (existsSharedQuiz)
                    throw new BusinessLogicException(QuizMessageCodes.CopyDenied);
                break;
            case QuizCopyMode.ForAll:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static QuizCreateData GetQuizPersistData(Quiz quiz, AggregateId userId) =>
        new(OwnerId: userId,
            quiz.Title,
            quiz.Description,
            quiz.Settings,
            quiz.OpenQuestions.Select(q => new QuizOpenQuestionPersistData(q.OrdinalNumber, q.Text, q.Answer)).ToArray(),
            quiz.SingleChoiceQuestions
                .Select(q => new QuizClosedQuestionCreateData(
                    q.OrdinalNumber,
                    q.Text,
                    q.Answers.Select(a => a.ToPersistData()).ToArray()))
                .ToArray(),
            quiz.MultipleChoiceQuestions
                .Select(q => new QuizClosedQuestionCreateData(
                    q.OrdinalNumber,
                    q.Text,
                    q.Answers.Select(a => a.ToPersistData()).ToArray()))
                .ToArray());
}