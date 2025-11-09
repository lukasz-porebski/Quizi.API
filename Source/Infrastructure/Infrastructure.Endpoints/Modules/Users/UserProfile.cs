using Application.Contracts.Modules.Users.Commands;
using AutoMapper;
using Common.Domain.ValueObjects;
using Domain.Contracts.Modules.Users.Enums;
using Domain.Modules.Users.Data;
using PublishedLanguage.Modules.Users.Requests;

namespace Infrastructure.Endpoints.Modules.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, UserCreationData>()
            .ForCtorParam(nameof(UserCreationData.Id), e => e.MapFrom(request => AggregateId.Generate()))
            .ForCtorParam(nameof(UserCreationData.Role), e => e.MapFrom(request => UserRole.User));

        CreateMap<CreateUserRequest, CreateUserCommand>()
            .ForCtorParam(nameof(CreateUserCommand.Data), e => e.MapFrom(request => request));
    }
}