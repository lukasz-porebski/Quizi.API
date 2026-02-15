using Application.Contracts.Modules.Users.Commands;
using AutoMapper;
using Common.Domain.ValueObjects;
using Domain.Modules.Users.Data;
using PublishedLanguage.Modules.Users.Requests;

namespace Infrastructure.Endpoints.Modules.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, UserCreationData>()
            .ForCtorParam(nameof(UserCreationData.Id), e => e.MapFrom(request => AggregateId.Generate()));

        CreateMap<CreateUserRequest, CreateUserCommand>()
            .ForCtorParam(nameof(CreateUserCommand.Data), e => e.MapFrom(request => request));
    }
}