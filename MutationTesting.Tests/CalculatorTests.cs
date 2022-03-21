using FluentAssertions;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace MutationTesting.Tests
{
    [ExcludeFromCodeCoverage]
    public class CalculatorTests
    {
        private readonly Calculator _calculator = new();

        [Theory]
        [InlineData(5,5,10)]
        public void Add_SouldReturnExpected(int first, int second, int expected)
        {
            // Arrange, Act
            var result = _calculator.Add(first, second);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(5, 5, 0)]
        public void Subtract_SouldReturnExpected(int first, int second, int expected)
        {
            // Arrange, Assert
            var result = _calculator.Subtract(first, second);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        public void Multiply_SouldReturnExpected(int first, int second, int expected)
        {
            // Arrange, Act
            var result = _calculator.Multiply(first, second);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 1, 1, 0)]
        public void Divide_SouldReturnExpectedResultAndExpectedRemainder(int first, int second, int expectedResult, int expectedRemainder)
        {
            // Arrange, Act
            var result = _calculator.Divide(first, second);

            // Assert
            result.Result.Should().Be(expectedResult);
            result.Remainder.Should().Be(expectedRemainder);
        }


        [Fact]
        public void Divide_ByZeroShouldThrowDivideByZeroException()
        {
            // Arrange, Act
            Action action = () => _calculator.Divide(1, 0);

            action.Should().Throw<DivideByZeroException>();
        }
    }
}