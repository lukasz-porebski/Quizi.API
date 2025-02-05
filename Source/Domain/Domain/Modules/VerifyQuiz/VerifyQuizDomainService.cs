// using Common.Shared.Providers;
// using Domain.Modules.Quizzes.Models;
// using Domain.Modules.VerifyQuiz.Factories;
// using Domain.Modules.VerifyQuiz.History;
// using Domain.Modules.VerifyQuiz.History.MethodData.Questions;
// using Domain.Modules.VerifyQuiz.MethodData;
// using Domain.Modules.VerifyQuiz.Policies;
// using Domain.Modules.VerifyQuiz.Policies.Core;
// using Domain.Modules.VerifyQuiz.Specifications.Data;
//
// namespace Domain.Modules.VerifyQuiz;
//
// public class VerifyQuizDomainService : IVerifyQuizDomainService
// {
//     private readonly IDateTimeProvider _dateTimeProvider;
//     private readonly IQuizResultHistoryFactory _quizResultHistoryFactory;
//     private readonly IQuizResultHistoryRepository _quizResultHistoryRepository;
//     private readonly IVerifyQuizSpecificationFactory _verifyQuizSpecificationFactory;
//
//     internal VerifyQuizDomainService(
//         IDateTimeProvider dateTimeProvider,
//         IQuizResultHistoryFactory quizResultHistoryFactory,
//         IQuizResultHistoryRepository quizResultHistoryRepository,
//         IVerifyQuizSpecificationFactory verifyQuizSpecificationFactory)
//     {
//         _dateTimeProvider = dateTimeProvider;
//         _quizResultHistoryFactory = quizResultHistoryFactory;
//         _quizResultHistoryRepository = quizResultHistoryRepository;
//         _verifyQuizSpecificationFactory = verifyQuizSpecificationFactory;
//     }
//
//     public async Task VerifyQuiz(VerifyQuizData data)
//     {
//         Quiz quiz;
//
//         _verifyQuizSpecificationFactory
//             .VerifyQuiz(ToSpecificationData(data, quiz))
//             .Validate();
//
//         var questionVerificationPolicy = quiz.Settings.NegativePoints
//             ? (IQuestionVerificationPolicy)new NegativePointsQuestionVerificationPolicy()
//             : new DefaultQuestionVerificationPolicy();
//
//         var verifiedOpenEndedQuestions = data.OpenEndedQuestions.Select(question =>
//             questionVerificationPolicy.VerifyOpenEndedQuestion(
//                 question, quiz.OpenEndedQuestions.Single(q => q.No.Equals(question.No))));
//
//         var verifiedSingleChoiceQuestions = data.SingleChoiceQuestions.Select(question =>
//             questionVerificationPolicy.VerifySingleChoiceQuestion(
//                 question, quiz.SingleChoiceQuestions.Single(q => q.No.Equals(question.No))));
//
//         var verifiedMultipleChoiceQuestions = data.MultipleChoiceQuestions.Select(question =>
//             questionVerificationPolicy.VerifyMultipleChoiceQuestion(
//                 question, quiz.MultipleChoiceQuestions.Single(q => q.No.Equals(question.No))));
//
//         var quizResultHistoryCreateData = new QuizResultHistoryCreateData(
//             data.QuizResultHistoryId,
//             data.UserId,
//             quiz.Id,
//             _dateTimeProvider.Now(),
//             quiz.Title,
//             quiz.Settings.NegativePoints,
//             data.QuizFinishTimeInSeconds,
//             quiz.Settings.DurationInSeconds,
//             GetAllQuestionsCount(quiz),
//             quiz.Settings.RandomAnswers,
//             quiz.Settings.RandomQuestions,
//             new QuizResultHistoryQuestionsData(
//                 openEndedQuestions: verifiedOpenEndedQuestions,
//                 singleChoiceQuestions: verifiedSingleChoiceQuestions,
//                 multipleChoiceQuestions: verifiedMultipleChoiceQuestions));
//
//         var quizResultHistory = _quizResultHistoryFactory.Create(quizResultHistoryCreateData);
//
//         await _quizResultHistoryRepository.AddAsync(quizResultHistory);
//     }
//
//     private static int GetAllQuestionsCount(Quiz quiz) =>
//         quiz.OpenQuestions.Count + quiz.SingleChoiceQuestions.Count + quiz.MultipleChoiceQuestions.Count;
//
//     private static VerifiedQuizSpecificationData ToSpecificationData(VerifyQuizData data, Quiz quiz) => new(
//         openEndedQuestions: quiz.OpenQuestions,
//         singleChoiceQuestions: quiz.SingleChoiceQuestions,
//         multipleChoiceQuestions: quiz.MultipleChoiceQuestions,
//         verifiedOpenEndedQuestions: data.OpenEndedQuestions,
//         verifiedSingleChoiceQuestions: data.SingleChoiceQuestions,
//         verifiedMultipleChoiceQuestions: data.MultipleChoiceQuestions);
// }
//
