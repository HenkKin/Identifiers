using System;
using Xunit;

namespace Identifiers.Tests
{
    public class SupportedTypesTests
    {
        [Theory]
        [InlineData(typeof(int))]
        [InlineData(typeof(short))]
        [InlineData(typeof(long))]
        [InlineData(typeof(Guid))]
        public void IsSupportedType_WhenTypeIsSupported_ItShouldReturnTrue(Type type)
        {
            // Act
            var isSupported = SupportedTypes.IsSupportedType(type);

            // Assert
            Assert.True(isSupported);
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(decimal))]
        [InlineData(typeof(DateTime))]
        [InlineData(typeof(double))]
        public void IsSupportedType_WhenTypeIsNotSupported_ItShouldReturnTrue(Type type)
        {
            // Act
            var isSupported = SupportedTypes.IsSupportedType(type);

            // Assert
            Assert.False(isSupported);
        }

        [Fact]
        public void _IsSupportedValueTypeWhenTypeOfValueIsSupported_ItShouldReturnTrue()
        {
            // Act
            var isSupportedInt = SupportedTypes.IsSupportedValueType(10);
            var isSupportedShort = SupportedTypes.IsSupportedValueType((short)10);
            var isSupportedLong = SupportedTypes.IsSupportedValueType(10L);
            var isSupportedGuid = SupportedTypes.IsSupportedValueType(Guid.Empty);

            // Assert
            Assert.True(isSupportedInt);
            Assert.True(isSupportedShort);
            Assert.True(isSupportedLong);
            Assert.True(isSupportedGuid);
        }

        [Fact]
        public void IsSupportedValueType_WhenTypeOfValueIsNotSupportedDecimal_ItShouldReturnFalse()
        {
            // Act
            var isSupportedNull = SupportedTypes.IsSupportedValueType(null);
            var isSupportedString = SupportedTypes.IsSupportedValueType("string");
            var isSupportedDouble = SupportedTypes.IsSupportedValueType(10d);
            var isSupportedDecimal = SupportedTypes.IsSupportedValueType(10m);
            var isSupportedDateTime = SupportedTypes.IsSupportedValueType(new DateTime(2019, 10, 1));

            // Assert
            Assert.False(isSupportedNull);
            Assert.False(isSupportedString);
            Assert.False(isSupportedDouble);
            Assert.False(isSupportedDecimal);
            Assert.False(isSupportedDateTime);
        }

        [Fact]
        public void IsSupportedType_WhenGenericTypeIsSupported_ItShouldReturnTrue()
        {
            // Act
            var isSupportedInt = SupportedTypes.IsSupportedType<int>();
            var isSupportedShort = SupportedTypes.IsSupportedType<short>();
            var isSupportedLong = SupportedTypes.IsSupportedType<long>();
            var isSupportedGuid = SupportedTypes.IsSupportedType<Guid>();

            // Assert
            Assert.True(isSupportedInt);
            Assert.True(isSupportedShort);
            Assert.True(isSupportedLong);
            Assert.True(isSupportedGuid);
        }

        [Fact]
        public void IsSupportedType_WhenGenericTypeIsNotSupported_ItShouldReturnFalse()
        {
            // Act
            var isSupportedString = SupportedTypes.IsSupportedType<string>();
            var isSupportedDecimal = SupportedTypes.IsSupportedType<decimal>();
            var isSupportedDateTime = SupportedTypes.IsSupportedType<DateTime>();
            var isSupportedDouble = SupportedTypes.IsSupportedType<double>();

            // Assert
            Assert.False(isSupportedString);
            Assert.False(isSupportedDecimal);
            Assert.False(isSupportedDateTime);
            Assert.False(isSupportedDouble);
        }
    }
}
