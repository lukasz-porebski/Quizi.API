using Common.Shared.Data;

namespace Common.Domain.Specification;

public class SpecificationBuilderDirector
{
    private readonly IReadOnlySet<string> _failureMessageCodes;

    private SpecificationBuilderDirector(IReadOnlySet<string> failureMessageCodes) =>
        _failureMessageCodes = failureMessageCodes;

    public void ValidateAndThrow()
    {
        if (_failureMessageCodes.Any())
            throw new SpecificationException(_failureMessageCodes.Select(f => new ExceptionMessageData(f, [])).ToArray());
    }

    public class SpecificationBuilder<TData>(TData validationData)
    {
        private readonly HashSet<string> _failureMessageCodes = [];
        private bool _previousPass = true;

        public SpecificationBuilder<TData> And(ISpecification<TData> specification) =>
            And(specification, x => x);

        public SpecificationBuilder<TData> And<TSubData>(
            ISpecification<TSubData> specification, Func<TData, TSubData> validateProperty)
        {
            if (_previousPass && !specification.IsValid(validateProperty.Invoke(validationData)))
                _failureMessageCodes.Add(specification.FailureMessageCode);

            return this;
        }

        public SpecificationBuilder<TData> AndCollection<TSubData>(
            ISpecification<TSubData> specification, Func<TData, IEnumerable<TSubData>> validateProperty)
        {
            if (_previousPass &&
                validateProperty.Invoke(validationData).Any(data => !specification.IsValid(data)))
                _failureMessageCodes.Add(specification.FailureMessageCode);

            return this;
        }

        public SpecificationBuilder<TData> AndNextIfThisPass(ISpecification<TData> specification) =>
            AndNextIfThisPass(specification, x => x);
        
        public SpecificationBuilder<TData> AndNextIfThisPass<TSubData>(
            ISpecification<TSubData> specification, Func<TData, TSubData> validateProperty)
        {
            if (!_previousPass || specification.IsValid(validateProperty.Invoke(validationData)))
                return this;

            _previousPass = false;
            _failureMessageCodes.Add(specification.FailureMessageCode);

            return this;
        }

        public SpecificationBuilderDirector Build() =>
            new(_failureMessageCodes);
    }
}