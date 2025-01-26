namespace Common.Shared.Data;

public record ExceptionMessageData(string Code, IReadOnlyCollection<object>? Parameters);