namespace Common.PublishedLanguage.Requests;

public record PaginationRequest(int PageNumber, int PageSize, SortRequest? Sort);