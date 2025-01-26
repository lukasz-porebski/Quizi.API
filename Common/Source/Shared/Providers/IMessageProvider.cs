namespace Common.Shared.Providers;

public interface IMessageProvider
{
    string GetMessage(string key);
}