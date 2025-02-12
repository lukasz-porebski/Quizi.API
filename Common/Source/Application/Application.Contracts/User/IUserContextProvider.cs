namespace Common.Application.Contracts.User;

public interface IUserContextProvider
{
    UserContextData? Get();
    UserContextData GetOrThrow();
}