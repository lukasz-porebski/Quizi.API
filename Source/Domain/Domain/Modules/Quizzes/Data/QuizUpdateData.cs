using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data;

public class QuizUpdateData
{
    public string Title { get; }
    public QuizDescription Description { get; }
    public QuizSettings Settings { get; }
    public List<QuizOpenEndedQuestionUpdateData> OpenEndedQuestions { get; }
    public List<QuizSingleChoiceQuestionUpdateData> SingleChoiceQuestions { get; }
    public List<QuizMultipleChoiceQuestionUpdateData> MultipleChoiceQuestions { get; }
    public AggregateId OwnerId { get; }

    public QuizUpdateData(string title, QuizDescription description, QuizSettings settings,
        IEnumerable<QuizOpenEndedQuestionUpdateData> openEndedQuestions,
        IEnumerable<QuizSingleChoiceQuestionUpdateData> singleChoiceQuestions,
        IEnumerable<QuizMultipleChoiceQuestionUpdateData> multipleChoiceQuestions,
        AggregateId ownerId)
    {
        Title = title;
        Description = description;
        Settings = settings;
        OpenEndedQuestions = openEndedQuestions.CreateList();
        SingleChoiceQuestions = singleChoiceQuestions.CreateList();
        MultipleChoiceQuestions = multipleChoiceQuestions.CreateList();
        OwnerId = ownerId;
    }
}