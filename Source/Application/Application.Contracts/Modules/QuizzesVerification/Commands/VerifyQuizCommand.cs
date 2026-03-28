using Application.Contracts.Modules.QuizzesVerification.Commands.Data;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Commands;

public record VerifyQuizCommand(
    AggregateId QuizId,
    AggregateId QuizResultId,
    DateTimePeriod QuizRunningPeriod,
    IReadOnlyCollection<VerifyQuizOpenQuestionCommandData> OpenQuestions,
    IReadOnlyCollection<VerifyQuizSingleChoiceQuestionCommandData> SingleChoiceQuestions,
    IReadOnlyCollection<VerifyQuizMultipleChoiceQuestionCommandData> MultipleChoiceQuestions
) : ICommand;