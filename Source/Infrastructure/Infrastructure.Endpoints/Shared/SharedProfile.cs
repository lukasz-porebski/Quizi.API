using AutoMapper;
using Common.Application.Contracts.ReadModel;
using PublishedLanguage.Shared.Requests;
using PublishedLanguage.Shared.Responses;

namespace Infrastructure.Endpoints.Shared;

public class SharedProfile : Profile
{
    public SharedProfile()
    {
        CreateMap<PaginationRequest, PaginationData>();

        CreateMap(typeof(PaginatedListDto<>), typeof(PaginatedListResponse<>));

        CreateMap<PaginationData, PaginationResponse>();
    }
}