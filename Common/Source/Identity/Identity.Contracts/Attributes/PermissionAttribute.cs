using Microsoft.AspNetCore.Authorization;

namespace Common.Identity.Contracts.Attributes;

public sealed class PermissionAttribute(params string[] permissions)
    : AuthorizeAttribute(string.Join(Separator, permissions))
{
    private const string Separator = "|";

    public string[] Permissions { get; } = permissions;

    public static string[] DecodePermissions(string policyName) =>
        policyName.Split(Separator);
}