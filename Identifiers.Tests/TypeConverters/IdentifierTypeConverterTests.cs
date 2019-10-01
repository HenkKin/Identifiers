using System;
using Identifiers.TypeConverters;
using Xunit;

namespace Identifiers.Tests.TypeConverters
{
    public class IdentifierTypeConverterTests
    {
        [Fact]
        public void WhenValueIsNull_ItShouldReturnANewIdentifierWithNullValue()
        {
            // Arrange

            // Act
            var result = IdentifierTypeConverter.ToIdentifier<int>(null);

            // Assert
            Assert.Null(result.GetValue());
        }

        [Fact]
        public void WhenValueIsAShort_ItShouldReturnANewIdentifierWithThatValue()
        {
            // Arrange
            short value = 10;
            short expectedValue = 10;

            // Act
            var result = IdentifierTypeConverter.ToIdentifier<short>(value);

            // Assert
            Assert.Equal(typeof(short), result.GetValue().GetType());
            Assert.Equal(expectedValue, result.GetValue());
        }

        [Fact]
        public void WhenValueIsALong_ItShouldReturnANewIdentifierWithThatValue()
        {
            // Arrange
            long value = 10L;

            // Act
            var result = IdentifierTypeConverter.ToIdentifier<long>(value);

            // Assert
            Assert.Equal(typeof(long), result.GetValue().GetType());
            Assert.Equal(10L, result.GetValue());
        }


        [Fact]
        public void WhenValueIsAnInteger_ItShouldReturnANewIdentifierWithThatValue()
        {
            // Arrange
            int value = 10;

            // Act
            var result = IdentifierTypeConverter.ToIdentifier<int>(value);

            // Assert
            Assert.Equal(typeof(int), result.GetValue().GetType());
            Assert.Equal(10, result.GetValue());
        }



        [Fact]
        public void WhenValueIsAGuid_ItShouldReturnANewIdentifierWithThatValue()
        {
            // Arrange
            const string guidStringValue = "0c982a05-615e-4f9e-9355-d3c03a234a63";
            Guid value = Guid.Parse(guidStringValue);

            // Act
            var result = IdentifierTypeConverter.ToIdentifier<Guid>(value);

            // Assert
            Assert.Equal(guidStringValue, result.GetValue().ToString());
        }


        [Fact]
        public void WhenValueIsNotOfSupportedTypes_ItShouldThrowNotSupportedException()
        {
            // Arrange
            string value = "value";

            // Act
            void Act() => IdentifierTypeConverter.ToIdentifier<string>(value);

            // Assert
            Assert.Throws<NotSupportedException>(Act);
        }

        [Fact]
        public void FromIdentifier_WhenTypeIsNotOfSupportedTypes_ItShouldThrowNotSupportedException()
        {
            // Arrange
            Identifier value = new Identifier();

            // Act
            void Act() => IdentifierTypeConverter.FromIdentifier<string>(value);

            // Assert
            Assert.Throws<NotSupportedException>(Act);
        }

        [Fact]
        public void FromIdentifier_WhenIdentifierHasDefaultValue_ItShouldReturnDefaultValue()
        {
            // Arrange
            Identifier value = new Identifier();

            // Act
            var resultInt = IdentifierTypeConverter.FromIdentifier<int>(value);
            var resultShort = IdentifierTypeConverter.FromIdentifier<short>(value);
            var resultLong = IdentifierTypeConverter.FromIdentifier<long>(value);
            var resultGuid = IdentifierTypeConverter.FromIdentifier<Guid>(value);

            // Assert
            Assert.Equal(0, resultInt);
            Assert.Equal(0, resultShort);
            Assert.Equal(0, resultLong);
            Assert.Equal(Guid.Empty, resultGuid);
        }

        [Fact]
        public void FromIdentifier_WhenIdentifierHasValue_ItShouldReturnValue()
        {
            // Arrange
            Identifier valueInt = new Identifier(10);
            Identifier valueLong = new Identifier(10L);
            Identifier valueShort = new Identifier((short)10);
            Identifier valueGuid = new Identifier(Guid.Empty);

            // Act
            var resultInt = IdentifierTypeConverter.FromIdentifier<int>(valueInt);
            var resultShort = IdentifierTypeConverter.FromIdentifier<short>(valueShort);
            var resultLong = IdentifierTypeConverter.FromIdentifier<long>(valueLong);
            var resultGuid = IdentifierTypeConverter.FromIdentifier<Guid>(valueGuid);

            // Assert
            Assert.Equal(10, resultInt);
            Assert.Equal(10, resultShort);
            Assert.Equal(10, resultLong);
            Assert.Equal(Guid.Empty, resultGuid);
        }

        [Fact]
        public void ToIdentifier_WhenValueIsNotOfSupportedTypes_ItShouldThrowNotSupportedException()
        {
            // Arrange
            string value = "value";

            // Act
            void Act() => IdentifierTypeConverter.ToIdentifier<int>(value);

            // Assert
            Assert.Throws<NotSupportedException>(Act);
        }


        [Fact]
        public void ToIdentifier_WhenValueIsIsGuidAndRequestedTypeIdInt_ItShouldThrowNotSupportedException()
        {
            // Arrange
            var value = Guid.Empty;

            // Act
            void Act() => IdentifierTypeConverter.ToIdentifier<int>(value);

            // Assert
            Assert.Throws<NotSupportedException>(Act);
        }
    }
}