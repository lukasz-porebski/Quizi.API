using AutoFixture;
using Common.TestsCore;
using Domain.Modules.Users.Data;
using Domain.Modules.Users.Specifications;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Modules.Users.Specifications;

public class PasswordFormatSpecificationTests : BaseTest
{
    private readonly PasswordFormatSpecification _specification = new();

    [Fact]
    public void PasswordThatNotContainsLowercaseLetter_Should_BeInvalid()
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = "P@SSWORD123"
        };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }

    [Fact]
    public void PasswordThatContainsLowercaseLetter_Should_BeValid()
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = "p@SSWORD123"
        };

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }

    [Fact]
    public void PasswordThatNotContainsUppercaseLetter_Should_BeInvalid()
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = "p@ssword123"
        };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }

    [Fact]
    public void PasswordThatContainsUppercaseLetter_Should_BeValid()
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = "P@ssword123"
        };

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }

    [Fact]
    public void PasswordThatNotContainsNumber_Should_BeInvalid()
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = "P@sswordddd"
        };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }

    [Fact]
    public void PasswordThatContainsNumber_Should_BeValid()
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = "P@ssword123"
        };

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }

    [Fact]
    public void Password_Should_BeCorrect_When_ContainsSpecialCharacter()
    {
        var specialCharacters = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~".ToCharArray();
        var validationData = specialCharacters.Select(sc => $"Password1{sc}");

        foreach (var vd in validationData)
        {
            var data = Fixture.Create<UserCreationData>() with
            {
                Password = vd
            };

            var result = _specification.IsValid(data);

            result.Should().BeTrue();
        }
    }

    [Fact]
    public void Password_Should_BeIncorrect_When_NotContainsSpecialCharacter()
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = "PPassword1"
        };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }

    [InlineData("P@ssw ord123")]
    [InlineData(" P@ssword123")]
    [InlineData("P@ssword123 ")]
    [Theory]
    public void PasswordThatNotContainsWhiteSpace_Should_BeInvalid(string password)
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = password
        };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }

    [Fact]
    public void PasswordThatContainsWhiteSpace_Should_BeValid()
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = "P@ssword123"
        };

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }

    [InlineData("", false)]
    [InlineData("  ", false)]
    [InlineData("P@ssword123", true)]
    [Theory]
    public void Password_Should_NotBeEmpty(string password, bool expectedResult)
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Password = password
        };

        var result = _specification.IsValid(data);

        result.Should().Be(expectedResult);
    }
}