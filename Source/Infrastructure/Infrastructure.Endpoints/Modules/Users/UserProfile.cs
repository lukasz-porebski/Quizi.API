using Application.Contracts.Modules.Users.Commands;
using Application.Contracts.Modules.Users.Dtos;
using Application.Contracts.Modules.Users.Queries;
using AutoMapper;
using Domain.Modules.Users.Data;
using Infrastructure.Endpoints.Modules.Users.Requests;
using Infrastructure.Endpoints.Modules.Users.Responses;
using LP.Common.Domain.ValueObjects;
using LP.Common.Infrastructure.Endpoints.Requests;

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