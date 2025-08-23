namespace Common.Application.Contracts.ReadModel;

public record PaginationData
{
    public PaginationData(int pageNumber, int pageSize, SortData? sort, string? search)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(pageNumber, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);

        PageNumber = pageNumber;
        PageSize = pageSize;
        Sort = sort;
        Search = search;
    }

    public int PageNumber { get; }
    public int PageSize { get; }
    public SortData? Sort { get; }
    public string? Search { get; }
}