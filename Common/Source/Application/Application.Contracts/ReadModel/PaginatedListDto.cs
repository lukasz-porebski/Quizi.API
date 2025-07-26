namespace Common.Application.Contracts.ReadModel;

public record PaginatedListDto<T>(
    IReadOnlyCollection<T> Items,
    int TotalCount,
    PaginationData Pagination
) where T : notnull;