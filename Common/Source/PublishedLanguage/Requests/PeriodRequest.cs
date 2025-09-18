namespace Common.PublishedLanguage.Requests;

public record PeriodRequest<T>(T Start, T End);