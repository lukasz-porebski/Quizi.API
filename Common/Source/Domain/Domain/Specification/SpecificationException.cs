using Common.Shared.Data;
using Common.Shared.Exceptions;

namespace Common.Domain.Specification;

public class SpecificationException : BaseException
{
    internal SpecificationException(IReadOnlyCollection<ExceptionMessageData> messages, Exception? innerException = null)
        : base(messages, innerException)
    {
    }
}