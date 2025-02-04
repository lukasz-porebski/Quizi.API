using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.History.MethodData.Questions;
using Domain.Modules.VerifyQuiz.MethodData.Questions;
using Domain.Modules.VerifyQuiz.Policies.Core;

namespace Domain.Modules.VerifyQuiz.Policies;

internal class DefaultQuestionVerificationPolicy : QuestionVerificationBase, IQuestionVerificationPolicy
{
    public QuizResultHistoryOpenEndedQuestionData VerifyOpenEndedQuestion(
        VerifyQuizOpenEndedQuestionData userAnswer, QuizOpenQuestion question) =>
        new(Text: question.Text,
            OrderNumber: userAnswer.OrderNumber,
            ScoredPoints: userAnswer.IsCorrect.HasValue && userAnswer.IsCorrect.Value ? 1 : 0,
            PointsPossibleToGet: 1,
            IsCorrect: userAnswer.IsCorrect,
            CorrectAnswer: question.Answer,
            UserAnswer: userAnswer.Answer);

    public QuizResultHistorySingleChoiceQuestionData VerifySingleChoiceQuestion(
        VerifyQuizSingleChoiceQuestionData userAnswer, QuizSingleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedSingleChoiceQuestion(userAnswer, question);

        return new QuizResultHistorySingleChoiceQuestionData(
            Text: question.Text,
            OrderNumber: userAnswer.OrderNumber,
            ScoredPoints: verifiedQuestion.CorrectAnswerThatIsMarked is null ? 0 : 1,
            PointsPossibleToGet: 1,
            CorrectAnswerThatIsMarked: verifiedQuestion.CorrectAnswerThatIsMarked,
            CorrectAnswerThatIsNotMarked: verifiedQuestion.CorrectAnswerThatIsNotMarked,
            WrongAnswerThatIsMarked: verifiedQuestion.WrongAnswerThatIsMarked,
            WrongAnswersThatAreNotMarked: verifiedQuestion.WrongAnswersThatAreNotMarked);
    }

    public QuizResultHistoryMultipleChoiceQuestionData VerifyMultipleChoiceQuestion(
        VerifyQuizMultipleChoiceQuestionData userAnswers, QuizMultipleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedMultipleChoiceQuestion(userAnswers, question);

        var points = verifiedQuestion.CorrectAnswersThatAreMarked.Count
                     - verifiedQuestion.WrongAnswersThatAreMarked.Count;

        return new QuizResultHistoryMultipleChoiceQuestionData(
            Text: question.Text,
            OrderNumber: userAnswers.OrderNumber,
            ScoredPoints: points > 0 ? (float)points / question.GetCorrectAnswers().Count : 0,
            PointsPossibleToGet: 1,
            CorrectAnswersThatAreMarked: verifiedQuestion.CorrectAnswersThatAreMarked,
            CorrectAnswersThatAreNotMarked: verifiedQuestion.CorrectAnswersThatAreNotMarked,
            WrongAnswersThatAreMarked: verifiedQuestion.WrongAnswersThatAreMarked,
            WrongAnswersThatAreNotMarked: verifiedQuestion.WrongAnswersThatAreNotMarked);
    }
}