namespace Common.PublishedLanguage.Responses;

public record PaginatedListResponse<T>(
    IReadOnlyCollection<T> Items,
    int TotalCount,
    PaginationResponse Pagination
) where T : notnull;