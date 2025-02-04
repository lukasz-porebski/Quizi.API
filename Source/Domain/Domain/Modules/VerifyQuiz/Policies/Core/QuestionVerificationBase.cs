using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.MethodData.Questions;
using Domain.Modules.VerifyQuiz.Policies.Data;
using Domain.Modules.VerifyQuiz.ValueObjects;
using MoreLinq.Extensions;

namespace Domain.Modules.VerifyQuiz.Policies.Core;

internal abstract class QuestionVerificationBase
{
    protected SingleChoiceQuestionVerificationResultData GetVerifiedSingleChoiceQuestion(
        VerifyQuizSingleChoiceQuestionData userAnswer, QuizSingleChoiceQuestion question)
    {
        if (IsCorrect(question.GetCorrectAnswer(), userAnswer.SelectedAnswer))
            return new SingleChoiceQuestionVerificationResultData(
                CorrectAnswerThatIsMarked: userAnswer.SelectedAnswer,
                CorrectAnswerThatIsNotMarked: null,
                WrongAnswerThatIsMarked: null,
                WrongAnswersThatAreNotMarked: userAnswer.UnselectedAnswers.Select(a => a as IQuizQuestionAnswer).ToList());

        QuizQuestionOrderedAnswer? wrongAnswerThatIsMarked = null;

        if (IsSelectedWrongAnswer(question, userAnswer))
            wrongAnswerThatIsMarked = userAnswer.SelectedAnswer;

        var allUserAnswers = userAnswer.UnselectedAnswers.ToDictionary(k => k.Text);

        if (wrongAnswerThatIsMarked != null)
            allUserAnswers.Add(wrongAnswerThatIsMarked.Value.Text, wrongAnswerThatIsMarked.Value);

        return new SingleChoiceQuestionVerificationResultData(
            CorrectAnswerThatIsMarked: null,
            CorrectAnswerThatIsNotMarked: allUserAnswers[question.GetCorrectAnswer().Text],
            WrongAnswerThatIsMarked: wrongAnswerThatIsMarked,
            WrongAnswersThatAreNotMarked: userAnswer.SelectedAnswer.HasValue
                ? question.GetWrongAnswers()
                    .Except([userAnswer.SelectedAnswer.Value], new QuizQuestionOrderedAnswerTexComparer())
                    .Select(a => allUserAnswers[a.Text] as IQuizQuestionAnswer)
                    .ToList()
                : question.GetWrongAnswers()
                    .Select(a => allUserAnswers[a.Text] as IQuizQuestionAnswer)
                    .ToList());
    }

    protected MultipleChoiceQuestionVerificationResultData GetVerifiedMultipleChoiceQuestion(
        VerifyQuizMultipleChoiceQuestionData userAnswers, QuizMultipleChoiceQuestion question)
    {
        var allUserAnswersDic = userAnswers.SelectedAnswers.ToDictionary(k => k.Text);
        userAnswers.UnselectedAnswers.ForEach(a => allUserAnswersDic.Add(a.Text, a));

        return new MultipleChoiceQuestionVerificationResultData(
            CorrectAnswersThatAreMarked: question.GetCorrectAnswers()
                .Intersect(userAnswers.SelectedAnswers.Select(a => a as IQuizQuestionAnswer), new QuizQuestionOrderedAnswerTexComparer())
                .Select(a => allUserAnswersDic[a.Text] as IQuizQuestionAnswer)
                .ToArray(),
            CorrectAnswersThatAreNotMarked: question.GetCorrectAnswers()
                .Except(userAnswers.SelectedAnswers.Select(a => a as IQuizQuestionAnswer), new QuizQuestionOrderedAnswerTexComparer())
                .Select(a => allUserAnswersDic[a.Text] as IQuizQuestionAnswer)
                .ToList(),
            WrongAnswersThatAreMarked: question.GetWrongAnswers()
                .Intersect(userAnswers.SelectedAnswers.Select(a => a as IQuizQuestionAnswer), new QuizQuestionOrderedAnswerTexComparer())
                .Select(a => allUserAnswersDic[a.Text] as IQuizQuestionAnswer)
                .ToList(),
            WrongAnswersThatAreNotMarked: question.GetWrongAnswers()
                .Except(userAnswers.SelectedAnswers.Select(a => a as IQuizQuestionAnswer), new QuizQuestionOrderedAnswerTexComparer())
                .Select(a => allUserAnswersDic[a.Text] as IQuizQuestionAnswer)
                .ToList());
    }

    private static bool IsCorrect(QuizSingleChoiceQuestionAnswer correctAnswer, IQuizQuestionAnswer? userAnswer) =>
        userAnswer != null && correctAnswer.Text.Equals(userAnswer.Text);

    private static bool IsSelectedWrongAnswer(
        QuizSingleChoiceQuestion question, VerifyQuizSingleChoiceQuestionData userAnswer) =>
        userAnswer.SelectedAnswer.HasValue && question.GetWrongAnswers()
            .Contains(userAnswer.SelectedAnswer.Value, new QuizQuestionOrderedAnswerTexComparer());
}