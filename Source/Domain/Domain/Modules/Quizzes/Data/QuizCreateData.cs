using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data;

public class QuizCreateData
{
    public AggregateId Id { get; }
    public AggregateId Owner { get; }
    public string Title { get; }
    public QuizDescription Description { get; }
    public QuizSettings Settings { get; }
    public List<QuizOpenEndedQuestionCreateData> OpenEndedQuestions { get; }
    public List<QuizSingleChoiceQuestionCreateData> SingleChoiceQuestions { get; }
    public List<QuizMultipleChoiceQuestionCreateData> MultipleChoiceQuestions { get; }

    public QuizCreateData(AggregateId id, AggregateId owner, string title,
        QuizDescription description, QuizSettings settings,
        IEnumerable<QuizOpenEndedQuestionCreateData> openEndedQuestions,
        IEnumerable<QuizSingleChoiceQuestionCreateData> singleChoiceQuestions,
        IEnumerable<QuizMultipleChoiceQuestionCreateData> multipleChoiceQuestions)
    {
        Id = id;
        Owner = owner;
        Title = title;
        Description = description;
        Settings = settings;
        OpenEndedQuestions = openEndedQuestions.CreateList();
        SingleChoiceQuestions = singleChoiceQuestions.CreateList();
        MultipleChoiceQuestions = multipleChoiceQuestions.CreateList();
    }
}