using AutoFixture;
using Common.TestsCore;
using FluentAssertions;
using Xunit;

namespace Common.Domain.ValueObjects;

public class EntityNoTests : BaseTest
{
    [Fact]
    public void PassingNumberLessThanOneForEntityNoCreation_Should_ThrowException()
    {
        const int incorrectEntityNo = 0;

        Action action = () => new EntityNo(incorrectEntityNo);

        action.Should().Throw<Exception>();
    }

    [InlineData(1)]
    [InlineData(2)]
    [Theory]
    public void PassingValidNumberForEntityNoCreation_Should_CreateEntityNo(int no)
    {
        var entityNo = new EntityNo(no);

        entityNo.Should().NotBeNull();
    }

    [Fact]
    public void ToIntMethod_Should_ReturnCorrectInt()
    {
        var no = Fixture.Create<int>();
        var entityNo = new EntityNo(no);

        var result = entityNo.ToInt();

        result.Should().Be(no);
    }

    [Fact]
    public void EqualsMethod_Should_ReturnTrue_When_EntityNosAreEqual()
    {
        var no = Fixture.Create<int>();
        var entityNo1 = new EntityNo(no);
        var entityNo2 = new EntityNo(no);

        var result = entityNo1.Equals(entityNo2);

        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsMethod_Should_ReturnFalse_When_EntityNosAreNotEqual()
    {
        var entityNo1 = new EntityNo(Fixture.Create<int>());
        var entityNo2 = new EntityNo(Fixture.Create<int>());

        var result = entityNo1.Equals(entityNo2);

        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsMethod_Should_ReturnTrue_When_ObjectIsEntityNo_And_IsEqual()
    {
        var no = Fixture.Create<int>();
        var entityNo1 = new EntityNo(no);
        var entityNo2 = (object)new EntityNo(no);

        var result = entityNo1.Equals(entityNo2);

        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsMethod_Should_ReturnFalse_When_ObjectIsEntityNo_And_IsNotEqual()
    {
        var entityNo1 = new EntityNo(Fixture.Create<int>());
        var entityNo2 = (object)new EntityNo(Fixture.Create<int>());

        var result = entityNo1.Equals(entityNo2);

        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsMethod_Should_ReturnFalse_When_ObjectIsNotEntityNo()
    {
        var no = new EntityNo(Fixture.Create<int>());
        var obj = new object();

        var result = no.Equals(obj);

        result.Should().BeFalse();
    }

    [Fact]
    public void EqualsOperator_Should_ReturnTrue_When_EntityNosAreEqual()
    {
        var no = Fixture.Create<int>();
        var entityNo1 = new EntityNo(no);
        var entityNo2 = new EntityNo(no);

        var result = entityNo1 == entityNo2;

        result.Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_Should_ReturnFalse_When_EntityNosAreNotEqual()
    {
        var entityNo1 = new EntityNo(Fixture.Create<int>());
        var entityNo2 = new EntityNo(Fixture.Create<int>());

        var result = entityNo1 == entityNo2;

        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_Should_ReturnFalse_When_EntityNosAreEqual()
    {
        var no = Fixture.Create<int>();
        var entityNo1 = new EntityNo(no);
        var entityNo2 = new EntityNo(no);

        var result = entityNo1 != entityNo2;

        result.Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_Should_ReturnTrue_When_EntityNosAreNotEqual()
    {
        var entityNo1 = new EntityNo(Fixture.Create<int>());
        var entityNo2 = new EntityNo(Fixture.Create<int>());

        var result = entityNo1 != entityNo2;

        result.Should().BeTrue();
    }

    [Fact]
    public void PlusOperator_Should_ReturnSumOfTwoEntityNos()
    {
        var no1 = Fixture.Create<int>();
        var no2 = Fixture.Create<int>();
        var entityNo1 = new EntityNo(no1);
        var entityNo2 = new EntityNo(no2);

        var result = entityNo1 + entityNo2;

        result.Should().Be(new EntityNo(no1 + no2));
    }

    [Fact]
    public void CompareToMethod_Should_ReturnOne_When_FirstEntityNoIsBiggerThanSecond()
    {
        var entityNo1 = new EntityNo(2);
        var entityNo2 = new EntityNo(1);

        var result = entityNo1.CompareTo(entityNo2);

        result.Should().Be(1);
    }

    [Fact]
    public void CompareToMethod_Should_ReturnMinusOne_When_SecondEntityNoIsBiggerThanFirst()
    {
        var entityNo1 = new EntityNo(1);
        var entityNo2 = new EntityNo(2);

        var result = entityNo1.CompareTo(entityNo2);

        result.Should().Be(-1);
    }

    [Fact]
    public void CompareToMethod_Should_ReturnOne_When_EntityNosAreEqual()
    {
        var no = Fixture.Create<int>();
        var entityNo1 = new EntityNo(no);
        var entityNo2 = new EntityNo(no);

        var result = entityNo1.CompareTo(entityNo2);

        result.Should().Be(0);
    }

    [Fact]
    public void CompareToMethod_Should_ReturnOne_When_FirstEntityNoIsBiggerThanSecondAsObject()
    {
        var entityNo1 = new EntityNo(2);
        var entityNo2 = (object)new EntityNo(1);

        var result = entityNo1.CompareTo(entityNo2);

        result.Should().Be(1);
    }

    [Fact]
    public void CompareToMethod_Should_ReturnMinusOne_When_SecondEntityNoIsBiggerThanFirstAsObject()
    {
        var entityNo1 = new EntityNo(1);
        var entityNo2 = (object)new EntityNo(2);

        var result = entityNo1.CompareTo(entityNo2);

        result.Should().Be(-1);
    }

    [Fact]
    public void CompareToMethod_Should_ReturnOne_When_EntityNosAreEqualAsObject()
    {
        var no = Fixture.Create<int>();
        var entityNo1 = new EntityNo(no);
        var entityNo2 = (object)new EntityNo(no);

        var result = entityNo1.CompareTo(entityNo2);

        result.Should().Be(0);
    }

    [Fact]
    public void CompareToMethod_Should_ThrowException_When_PassingIncorrectEntityNo()
    {
        var entityNo1 = new EntityNo(Fixture.Create<int>());
        var entityNo2 = new object();

        Action action = () => entityNo1.CompareTo(entityNo2);

        action.Should().Throw<Exception>();
    }
}