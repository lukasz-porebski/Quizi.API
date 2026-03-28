using Domain.Modules.SharedQuizzes.Data;
using Domain.Modules.SharedQuizzes.Interfaces;
using LP.Common.Domain.Entities;
using LP.Common.Domain.ValueObjects;

namespace Domain.Modules.SharedQuizzes.Models;

public class SharedQuiz : BaseAggregateRoot
{
    private readonly List<SharedQuizUser> _users = [];

    private ISharedQuizSpecificationFactory _specificationFactory = null!;

    internal SharedQuiz(
        AggregateId id, AggregateId quizId, AggregateId userId, ISharedQuizSpecificationFactory specificationFactory)
        : base(id)
    {
        SetDependencies(specificationFactory);

        QuizId = quizId;
        AddUser(userId);
    }

    private SharedQuiz()
    {
    }

    public AggregateId QuizId { get; private set; } = null!;
    public IReadOnlyList<SharedQuizUser> Users => _users;

    public void AddUser(AggregateId userId)
    {
        var specificationData = new SharedQuizAddUserSpecificationData(_users.Select(u => u.UserId).ToArray(), userId);
        _specificationFactory.AddUser(specificationData).ValidateAndThrow();

        _users.Add(new SharedQuizUser(Id, userId));
    }

    public void RemoveUser(AggregateId userIdToRemove)
    {
        var specificationData = new SharedQuizRemoveUserSpecificationData(_users.Select(u => u.UserId).ToArray(), userIdToRemove);
        _specificationFactory.RemoveUser(specificationData).ValidateAndThrow();

        _users.RemoveAll(u => u.UserId == userIdToRemove);
    }

    internal void SetDependencies(ISharedQuizSpecificationFactory specificationFactory)
    {
        _specificationFactory = specificationFactory;
    }
}