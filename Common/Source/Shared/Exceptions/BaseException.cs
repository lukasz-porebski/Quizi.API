using Common.Shared.Data;

namespace Common.Shared.Exceptions;

public abstract class BaseException : Exception
{
    private const string MessageCodeSeparator = "||";

    protected BaseException(string messageCode, IReadOnlyCollection<object>? parameters = null, Exception? innerException = null)
        : base(JoinMessages([messageCode]), innerException)
    {
        Messages = [new ExceptionMessageData(messageCode, parameters)];
    }

    protected BaseException(IReadOnlyCollection<ExceptionMessageData> messages, Exception? innerException = null)
        : base(JoinMessages(messages.Select(m => m.Code)), innerException)
    {
        Messages = messages;
    }

    public IReadOnlyCollection<ExceptionMessageData> Messages { get; }

    private static string JoinMessages(IEnumerable<string> messages) =>
        string.Join(MessageCodeSeparator, messages);
}