using Common.Application.Contracts.Interfaces;
using Domain.Modules.Users.Models;

namespace Application.Contracts.Modules.Users.Interfaces;

public interface IUserRepository : IRepository<User>;