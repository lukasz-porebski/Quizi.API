using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Domain.Modules.SharedQuizzes.Data;
using Domain.Modules.SharedQuizzes.Interfaces;

namespace Domain.Modules.SharedQuizzes.Models;

public class SharedQuiz : BaseAggregateRoot
{
    private readonly List<SharedQuizUser> _users = [];

    private ISharedQuizSpecificationFactory _specificationFactory = null!;

    internal SharedQuiz(
        AggregateId id, AggregateId ownerId, AggregateId userId, ISharedQuizSpecificationFactory specificationFactory)
        : base(id)
    {
        SetDependencies(specificationFactory);

        OwnerId = ownerId;
        AddUser(ownerId, userId);
    }

    private SharedQuiz()
    {
    }

    public AggregateId OwnerId { get; private set; } = null!;
    public IReadOnlyList<SharedQuizUser> Users => _users;

    public void AddUser(AggregateId ownerId, AggregateId userId)
    {
        var specificationData = new SharedQuizAddUserSpecificationData(
            _users.Select(u => u.UserId).ToArray(), userId, OwnerId, ownerId);
        _specificationFactory.AddUser(specificationData).ValidateAndThrow();

        _users.Add(new SharedQuizUser(Id, userId));
    }

    public void RemoveUser(AggregateId ownerId, AggregateId userIdToRemove)
    {
        var specificationData = new SharedQuizRemoveUserSpecificationData(
            _users.Select(u => u.UserId).ToArray(), OwnerId, ownerId, userIdToRemove);
        _specificationFactory.RemoveUser(specificationData).ValidateAndThrow();

        _users.RemoveAll(u => u.UserId == userIdToRemove);
    }

    internal void SetDependencies(ISharedQuizSpecificationFactory specificationFactory)
    {
        _specificationFactory = specificationFactory;
    }
}