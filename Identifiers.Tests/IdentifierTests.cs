using System;
using Xunit;

namespace Identifiers.Tests
{
    public class IdentifierTests
    {
        [Fact]
        public void Empty_WhenEmptyIdentifierIsRequested_ItReturnsIdentifierWithNull()
        {
            // Act
            var result = Identifier.Empty;

            // Assert
            Assert.Null(result.GetValue());
        }

        [Fact]
        public void Ctor_WhenIdentifierIsConstructedWithNotAllowedType_ItThrowsException()
        {
            // Arrange
            string value = "";

            // Act
            void Act() => new Identifier(value);

            // Assert
            Assert.Throws<NotSupportedException>(Act);
        }

        [Fact]
        public void Ctor_WhenIdentifierIsConstructedWithAllowedType_ItCreatesaAnIdentifier()
        {
            // Arrange
            int value = 10;

            // Act
            var result = new Identifier(value);

            // Assert
            Assert.Equal(10, result.GetValue());
        }

        [Fact]
        public void GetValue_WhenCalled_ItReturnsValueAtCreation()
        {
            // Arrange
            int value = 10;
            var identifier = new Identifier(value);

            // Act
            var result = identifier.GetValue();

            // Assert
            Assert.Equal(10, result);
        }

        [Theory]
        [InlineData(10, 30, true)]
        [InlineData(19, 20, true)]
        [InlineData(10, null, false)]
        [InlineData(null, null, false)]
        [InlineData(20, 20, false)]
        [InlineData(null, 30, true)]
        [InlineData(20, 19, false)]
        [InlineData(20, 1, false)]
        public void Operator_LessThen_WhenIdentifiersCompared_ItReturnsExpectedResult(object left, object right, bool expectedResult)
        {
            // Arrange
            var identifierLeft = new Identifier(left);
            var identifierRight = new Identifier(right);

            // Act
            var result = identifierLeft < identifierRight;

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 30, false)]
        [InlineData(19, 20, false)]
        [InlineData(10, null, true)]
        [InlineData(null, null, false)]
        [InlineData(20, 20, false)]
        [InlineData(null, 30, false)]
        [InlineData(20, 19, true)]
        [InlineData(20, 1, true)]
        public void Operator_GreaterThen_WhenIdentifiersCompared_ItReturnsExpectedResult(object left, object right, bool expectedResult)
        {
            // Arrange
            var identifierLeft = new Identifier(left);
            var identifierRight = new Identifier(right);

            // Act
            var result = identifierLeft > identifierRight;

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 30, true)]
        [InlineData(19, 20, true)]
        [InlineData(10, null, false)]
        [InlineData(null, null, true)]
        [InlineData(20, 20, true)]
        [InlineData(null, 30, true)]
        [InlineData(20, 19, false)]
        [InlineData(20, 1, false)]
        public void Operator_LessThenOrEqual_WhenIdentifiersCompared_ItReturnsExpectedResult(object left, object right, bool expectedResult)
        {
            // Arrange
            var identifierLeft = new Identifier(left);
            var identifierRight = new Identifier(right);

            // Act
            var result = identifierLeft <= identifierRight;

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 30, false)]
        [InlineData(19, 20, false)]
        [InlineData(10, null, true)]
        [InlineData(null, null, true)]
        [InlineData(20, 20, true)]
        [InlineData(null, 30, false)]
        [InlineData(20, 19, true)]
        [InlineData(20, 1, true)]
        public void Operator_GreaterThenOrEqual_WhenIdentifiersCompared_ItReturnsExpectedResult(object left, object right, bool expectedResult)
        {
            // Arrange
            var identifierLeft = new Identifier(left);
            var identifierRight = new Identifier(right);

            // Act
            var result = identifierLeft >= identifierRight;

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 30, false)]
        [InlineData(19, 20, false)]
        [InlineData(10, null, false)]
        [InlineData(null, null, true)]
        [InlineData(20, 20, true)]
        [InlineData(null, 30, false)]
        [InlineData(20, 19, false)]
        [InlineData(20, 1, false)]
        public void Operator_Equal_WhenIdentifiersCompared_ItReturnsExpectedResult(object left, object right, bool expectedResult)
        {
            // Arrange
            var identifierLeft = new Identifier(left);
            var identifierRight = new Identifier(right);

            // Act
            var result = identifierLeft == identifierRight;

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 30, true)]
        [InlineData(19, 20, true)]
        [InlineData(10, null, true)]
        [InlineData(null, null, false)]
        [InlineData(20, 20, false)]
        [InlineData(null, 30, true)]
        [InlineData(20, 19, true)]
        [InlineData(20, 1, true)]
        public void Operator_NotEqual_WhenIdentifiersCompared_ItReturnsExpectedResult(object left, object right, bool expectedResult)
        {
            // Arrange
            var identifierLeft = new Identifier(left);
            var identifierRight = new Identifier(right);

            // Act
            var result = identifierLeft != identifierRight;

            // Assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(10, 30, false)]
        [InlineData(19, 20, false)]
        [InlineData(10, null, false)]
        [InlineData(null, null, true)]
        [InlineData(20, 20, true)]
        [InlineData(null, 30, false)]
        [InlineData(20, 19, false)]
        [InlineData(20, 1, false)]
        public void Equals_WhenIdentifiersCompared_ItReturnsExpectedResult(object left, object right, bool expectedResult)
        {
            // Arrange
            var identifierLeft = new Identifier(left);
            var identifierRight = new Identifier(right);

            // Act
            var result = identifierLeft.Equals(identifierRight);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 30, -1)]
        [InlineData(19, 20, -1)]
        [InlineData(10, null, 1)]
        [InlineData(null, null, 0)]
        [InlineData(20, 20, 0)]
        [InlineData(null, 30, -1)]
        [InlineData(20, 19, 1)]
        [InlineData(20, 1, 1)]
        public void CompareTo_WhenIdentifiersCompared_ItReturnsExpectedResult(object left, object right, int expectedResult)
        {
            // Arrange
            var identifierLeft = new Identifier(left);
            var identifierRight = new Identifier(right);

            // Act
            var result = identifierLeft.CompareTo(identifierRight);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 30, false)]
        [InlineData(19, 20, false)]
        [InlineData(10, null, false)]
        [InlineData(null, null, true)]
        [InlineData(20, 20, true)]
        [InlineData(null, 30, false)]
        [InlineData(20, 19, false)]
        [InlineData(20, 1, false)]
        public void EqualsObject_WhenIdentifiersCompared_ItReturnsExpectedResult(object left, object right, bool expectedResult)
        {
            // Arrange
            var identifierLeft = new Identifier(left);
            var identifierRight = new Identifier(right);

            // Act
            var result = identifierLeft.Equals((object)identifierRight);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void EqualsObject_WhenPassedIdentifierIsNull_ItReturnsExpectedResult()
        {
            // Arrange
            var identifierLeft = new Identifier(10);

            // Act
            var result = identifierLeft.Equals(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetHashCode_WhenCalledOnDefaultIdentifier_ItReturnsHashCodeOfIdentifier()
        {
            // Act
            var identifier1 = new Identifier(null);
            var identifier2 = new Identifier(null);

            // Assert
            Assert.Equal(identifier1.GetHashCode(), identifier2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_WhenCalledOnIdentifier_ItReturnsHashCodeOfInternalValue()
        {
            // Arrange
            int value = 10;
            var intHashCode = value.GetHashCode();

            var identifier = new Identifier(value);

            // Act
            var hashCode = identifier.GetHashCode();

            // Assert
            Assert.Equal(intHashCode, hashCode);
        }


        [Fact]
        public void ToString_WhenCalledOnDefaultIdentifier_ItReturnsEmptyString()
        {
            // Arrange
            var identifier = new Identifier(null);

            // Act
            var result = identifier.ToString();

            // Assert
            Assert.Equal(string.Empty, result);
        }


        [Fact]
        public void ToString_WhenCalledOnIdentifier_ItReturnsInternalValueString()
        {
            // Arrange
            var identifierInt = new Identifier(10);
            var identifierShort = new Identifier((short)10);
            var identifierLong = new Identifier(10L);
            var identifierGuid = new Identifier(Guid.Empty);

            // Act
            var resultInt = identifierInt.ToString();
            var resultShort = identifierShort.ToString();
            var resultLong = identifierLong.ToString();
            var resultGuid = identifierGuid.ToString();

            // Assert
            Assert.Equal("10", resultInt);
            Assert.Equal("10", resultShort);
            Assert.Equal("10", resultLong);
            Assert.Equal("00000000-0000-0000-0000-000000000000", resultGuid);
        }
    }
}
