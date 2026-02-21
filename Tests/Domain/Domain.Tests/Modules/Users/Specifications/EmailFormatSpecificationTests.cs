using AutoFixture;
using Common.TestsCore;
using Domain.Modules.Users.Data;
using Domain.Modules.Users.Specifications;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Modules.Users.Specifications;

public class EmailFormatSpecificationTests : BaseTest
{
    private readonly EmailFormatSpecification _specification = new();

    [InlineData("plainaddress")]
    [InlineData("#@%^%#$@#$@#.com")]
    [InlineData("@domain.com")]
    [InlineData("Joe Smith <email@domain.com>")]
    [InlineData("email.domain.com")]
    [InlineData("email@domain@domain.com")]
    [InlineData(".email@domain.com")]
    [InlineData("email.@domain.com")]
    [InlineData("email..email@domain.com")]
    [InlineData("あいうえお@domain.com")]
    [InlineData("email@domain.com (Joe Smith)")]
    [InlineData("email@domain")]
    [InlineData("email@-domain.com")]
    [InlineData("email@domain..com")]
    [InlineData("email@123.123.123.123")] //Valid but not in my app
    [InlineData("email@[123.123.123.123]")] //Valid but not in my app
    [InlineData("\"email\"@domain.com")] //Valid but not in my app
    [Theory]
    public void Should_ReturnFalse_When_EmailAddressesIsInvalid(string email)
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Email = email
        };

        var result = _specification.IsValid(data);

        result.Should().BeFalse();
    }

    [InlineData("email@domain.com")]
    [InlineData("firstname.lastname@domain.com")]
    [InlineData("email@subdomain.domain.com")]
    [InlineData("firstname+lastname@domain.com")]
    [InlineData("1234567890@domain.com")]
    [InlineData("email@domain-one.com")]
    [InlineData("email@domain.name")]
    [InlineData("email@domain.co.jp")]
    [InlineData("firstname-lastname@domain.com")]
    [Theory]
    public void Should_ReturnTrue_When_EmailAddressesIsValid(string email)
    {
        var data = Fixture.Create<UserCreationData>() with
        {
            Email = email
        };

        var result = _specification.IsValid(data);

        result.Should().BeTrue();
    }
}