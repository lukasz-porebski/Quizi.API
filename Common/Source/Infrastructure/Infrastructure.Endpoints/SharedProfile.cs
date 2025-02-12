using AutoMapper;
using Common.Domain.Data;
using Common.Domain.ValueObjects;
using Common.PublishedLanguage.Requests;
using Common.Shared.DataStructures;

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

        CreateMap<PeriodRequest, Period<DateTime>>();
    }
}