using Application.Contracts.Modules.QuizzesVerification.Commands.Data;
using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.QuizzesVerification.Commands;

public record VerifyQuizCommand(
    AggregateId Id,
    IReadOnlyCollection<VerifyQuizOpenQuestionCommandData> OpenQuestions,
    IReadOnlyCollection<VerifyQuizSingleChoiceQuestionCommandData> SingleChoiceQuestions,
    IReadOnlyCollection<VerifyQuizMultipleChoiceQuestionCommandData> MultipleChoiceQuestions
) : ICommand;