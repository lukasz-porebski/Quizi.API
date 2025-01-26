using Common.Shared.Exceptions;

namespace Common.Domain.Exceptions;

public class DomainLogicException(string messageCode, IReadOnlyCollection<object>? parameters = null, Exception? innerException = null)
    : BaseException(messageCode, parameters, innerException);