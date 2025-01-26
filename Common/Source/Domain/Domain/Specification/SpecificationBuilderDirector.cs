using Common.Shared.Data;

namespace Common.Domain.Specification;

public class SpecificationBuilderDirector
{
    private readonly IReadOnlySet<string> _failureMessageCodes;

    private SpecificationBuilderDirector(IReadOnlySet<string> failureMessageCodes) =>
        _failureMessageCodes = failureMessageCodes;

    public void Validate()
    {
        if (_failureMessageCodes.Any())
            throw new SpecificationException(_failureMessageCodes.Select(f => new ExceptionMessageData(f, [])).ToArray());
    }

    public class SpecificationBuilder<TValidationProperty>(TValidationProperty validationData)
    {
        private readonly HashSet<string> _failureMessageCodes = [];
        private bool _previousPass = true;

        public SpecificationBuilder<TValidationProperty> And<T>(
            ISpecification<T> specification, Func<TValidationProperty, T> validateProperty)
        {
            if (_previousPass && !specification.IsValid(validateProperty.Invoke(validationData)))
                _failureMessageCodes.Add(specification.FailureMessageCode);

            return this;
        }

        public SpecificationBuilder<TValidationProperty> AndCollection<T>(
            ISpecification<T> specification, Func<TValidationProperty, IEnumerable<T>> validateProperty)
        {
            if (_previousPass &&
                validateProperty.Invoke(validationData).Any(data => !specification.IsValid(data)))
                _failureMessageCodes.Add(specification.FailureMessageCode);

            return this;
        }

        public SpecificationBuilder<TValidationProperty> AndNextIfThisPass<T>(
            ISpecification<T> specification, Func<TValidationProperty, T> validateProperty)
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