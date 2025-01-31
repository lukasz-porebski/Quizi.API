using System.Text.RegularExpressions;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;

namespace Domain.Modules.Quizzes.Extensions;

public static class StringExtensions
{
    public static string RemoveIllegalWhiteSpaces(this string value)
    {
        if (value.IsEmpty())
            return value;

        var trimmedResult = value.Trim();

        return Regex.Replace(trimmedResult, @"\s+", " ");
    }
}