using Domain.Modules.Users.Models;
using LP.Common.Application.Contracts.Interfaces;

namespace Application.Contracts.Modules.Users.Interfaces;

public interface IUserRepository : IRepository<User>;