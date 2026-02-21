using AutoMapper;
using Common.Application.Contracts.ReadModel;
using Common.Domain.Data;
using Common.Domain.ValueObjects;
using Common.Infrastructure.Endpoints.Requests;
using Common.Infrastructure.Endpoints.Responses;
using Common.Infrastructure.Endpoints.ViewModels;

namespace Common.Infrastructure.Endpoints;

public class SharedProfile : Profile
{
    public SharedProfile()
    {
        CreateMap<string, AggregateId>()
            .ConstructUsing(id => new AggregateId(id));

        CreateMap<AggregateId, string>()
            .ConstructUsing(id => id.ToString());

        CreateMap<int, EntityNo>()
            .ConstructUsing(no => new EntityNo(no));

        CreateMap<EntityNo, int>()
            .ConstructUsing(no => no.ToInt());

        CreateMap(typeof(EntityPersistRequest<>), typeof(EntityPersistData<>));

        CreateMap<PeriodViewModel<DateTime>, DateTimePeriod>()
            .ConstructUsing(request => new DateTimePeriod(request.Start, request.End));

        CreateMap<PaginationRequest, PaginationData>();

        CreateMap(typeof(PaginatedListDto<>), typeof(PaginatedListResponse<>));

        CreateMap<PaginationData, PaginationResponse>();

        CreateMap<SortRequest, SortData>();

        CreateMap<SortData, SortResponse>();
    }
}