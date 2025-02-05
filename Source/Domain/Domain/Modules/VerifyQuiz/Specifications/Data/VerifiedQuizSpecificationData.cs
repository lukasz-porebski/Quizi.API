using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.MethodData.Sub;

namespace Domain.Modules.VerifyQuiz.Specifications.Data;

public record VerifiedQuizSpecificationData(
    IReadOnlyCollection<QuizOpenQuestion> OpenQuestions,
    IReadOnlyCollection<QuizSingleChoiceQuestion> SingleChoiceQuestions,
    IReadOnlyCollection<QuizMultipleChoiceQuestion> MultipleChoiceQuestions,
    IReadOnlyCollection<QuizOpenQuestionVerificationData> VerifiedOpenQuestions,
    IReadOnlyCollection<QuizSingleChoiceQuestionVerificationData> VerifiedSingleChoiceQuestions,
    IReadOnlyCollection<QuizMultipleChoiceQuestionVerificationData> VerifiedMultipleChoiceQuestions
);