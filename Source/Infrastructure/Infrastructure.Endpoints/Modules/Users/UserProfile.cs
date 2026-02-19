using Application.Contracts.Modules.Users.Commands;
using Application.Contracts.Modules.Users.Dtos;
using Application.Contracts.Modules.Users.Queries;
using AutoMapper;
using Common.Domain.ValueObjects;
using Common.PublishedLanguage.Requests;
using Domain.Modules.Users.Data;
using PublishedLanguage.Modules.Users.Requests;
using PublishedLanguage.Modules.Users.Responses;

namespace Infrastructure.Endpoints.Modules.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, UserCreationData>()
            .ForCtorParam(nameof(UserCreationData.Id), e => e.MapFrom(request => AggregateId.Generate()))
            .ForCtorParam(nameof(UserCreationData.RoleIds), e => e.MapFrom(request => new HashSet<AggregateId>()));

        CreateMap<CreateUserRequest, CreateUserCommand>()
            .ForCtorParam(nameof(CreateUserCommand.Data), e => e.MapFrom(request => request));

        CreateMap<PaginationRequest, GetUsersQuery>()
            .ForCtorParam(nameof(GetUsersQuery.Pagination), e => e.MapFrom(request => request));

        CreateMap<UsersListItemDto, UsersListItemResponse>();
    }
}