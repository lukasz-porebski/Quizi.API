using Domain.Modules.Users.Models;

namespace Domain.Modules.Users.Interfaces;

public interface IPasswordHasher
{
    public string HashPassword(User user, string password);
    public bool ArePasswordsSame(User user, string hashedPassword, string providedPassword);
}