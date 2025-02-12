namespace Common.PublishedLanguage.Requests;

public record EntityPersistRequest<T>(int? No, T Data)
    where T : class;