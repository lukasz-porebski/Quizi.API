namespace Common.Infrastructure.Endpoints.Responses;

public record PaginationResponse(
    int PageNumber,
    int PageSize,
    SortResponse? Sort,
    string? Search
);