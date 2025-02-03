using Domain.Modules.Users.Data;
using Domain.Modules.Users.Models;

namespace Domain.Modules.Users.Interfaces;

public interface IUserFactory
{
    User Create(UserCreationData data);
}