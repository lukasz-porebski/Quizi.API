namespace Common.PublishedLanguage.Responses;

public record PaginationResponse(
    int PageNumber,
    int PageSize,
    SortResponse? Sort,
    string? Search
);