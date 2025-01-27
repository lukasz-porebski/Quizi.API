using Domain.Modules.Users.Interfaces;
using Domain.Modules.Users.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Modules.Users;

public class PasswordHasher(IPasswordHasher<User> hasher) : IPasswordHasher
{
    public string HashPassword(User user, string password) =>
        hasher.HashPassword(user, password);

    public bool ArePasswordsSame(User user, string hashedPassword, string providedPassword) =>
        hasher.VerifyHashedPassword(user, hashedPassword, providedPassword) != PasswordVerificationResult.Failed;
}