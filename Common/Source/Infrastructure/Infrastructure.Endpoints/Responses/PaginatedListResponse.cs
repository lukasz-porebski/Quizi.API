namespace Common.Infrastructure.Endpoints.Responses;

public record PaginatedListResponse<T>(
    IReadOnlyCollection<T> Items,
    int TotalCount,
    PaginationResponse Pagination
) where T : notnull;