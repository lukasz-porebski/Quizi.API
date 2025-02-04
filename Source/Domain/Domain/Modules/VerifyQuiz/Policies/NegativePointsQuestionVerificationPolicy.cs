using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.History.MethodData.Questions;
using Domain.Modules.VerifyQuiz.MethodData.Questions;
using Domain.Modules.VerifyQuiz.Policies.Core;

namespace Domain.Modules.VerifyQuiz.Policies;

internal class NegativePointsQuestionVerificationPolicy : QuestionVerificationBase, IQuestionVerificationPolicy
{
    public QuizResultHistoryOpenEndedQuestionData VerifyOpenEndedQuestion(
        VerifyQuizOpenEndedQuestionData userAnswer, QuizOpenQuestion question)
    {
        var points = 0;

        if (userAnswer.IsCorrect.HasValue)
            points = userAnswer.IsCorrect.Value ? 1 : -1;

        return new QuizResultHistoryOpenEndedQuestionData(
            Text: question.Text,
            OrderNumber: userAnswer.OrderNumber,
            ScoredPoints: points,
            PointsPossibleToGet: 1,
            IsCorrect: userAnswer.IsCorrect,
            CorrectAnswer: question.Answer,
            UserAnswer: userAnswer.Answer);
    }

    public QuizResultHistorySingleChoiceQuestionData VerifySingleChoiceQuestion(
        VerifyQuizSingleChoiceQuestionData userAnswer, QuizSingleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedSingleChoiceQuestion(userAnswer, question);

        var points = 0;

        if (verifiedQuestion.CorrectAnswerThatIsMarked != null)
            points = 1;
        else if (verifiedQuestion.WrongAnswerThatIsMarked != null)
            points = -1;

        return new QuizResultHistorySingleChoiceQuestionData(
            Text: question.Text,
            OrderNumber: userAnswer.OrderNumber,
            ScoredPoints: points,
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
            ScoredPoints: points,
            PointsPossibleToGet: question.GetCorrectAnswers().Count,
            CorrectAnswersThatAreMarked: verifiedQuestion.CorrectAnswersThatAreMarked,
            CorrectAnswersThatAreNotMarked: verifiedQuestion.CorrectAnswersThatAreNotMarked,
            WrongAnswersThatAreMarked: verifiedQuestion.WrongAnswersThatAreMarked,
            WrongAnswersThatAreNotMarked: verifiedQuestion.WrongAnswersThatAreNotMarked);
    }
}