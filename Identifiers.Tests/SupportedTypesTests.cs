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
        public void WhenTypeIsSupported_ItShouldReturnTrue(Type type)
        {
            // Act
            var isSupported = SupportedTypes.IsSupported(type);

            // Assert
            Assert.True(isSupported);
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(decimal))]
        [InlineData(typeof(DateTime))]
        [InlineData(typeof(double))]
        public void WhenTypeIsNotSupported_ItShouldReturnTrue(Type type)
        {
            // Act
            var isSupported = SupportedTypes.IsSupported(type);

            // Assert
            Assert.False(isSupported);
        }

        [Fact]
        public void WhenTypeOfValueIsSupported_ItShouldReturnTrue()
        {
            // Act
            var isSupportedInt = SupportedTypes.IsSupported(10);
            var isSupportedShort = SupportedTypes.IsSupported((short)10);
            var isSupportedLong = SupportedTypes.IsSupported(10L);
            var isSupportedGuid = SupportedTypes.IsSupported(Guid.Empty);

            // Assert
            Assert.True(isSupportedInt);
            Assert.True(isSupportedShort);
            Assert.True(isSupportedLong);
            Assert.True(isSupportedGuid);
        }

        [Fact]
        public void WhenTypeOfValueIsNotSupportedDecimal_ItShouldReturnFalse()
        {
            // Act
            var isSupportedString = SupportedTypes.IsSupported("string");
            var isSupportedDouble = SupportedTypes.IsSupported(10d);
            var isSupportedDecimal = SupportedTypes.IsSupported(10m);
            var isSupportedDateTime = SupportedTypes.IsSupported(new DateTime(2019, 10, 1));

            // Assert
            Assert.False(isSupportedString);
            Assert.False(isSupportedDouble);
            Assert.False(isSupportedDecimal);
            Assert.False(isSupportedDateTime);
        }

        [Fact]
        public void WhenGenericTypeIsSupported_ItShouldReturnTrue()
        {
            // Act
            var isSupportedInt = SupportedTypes.IsSupported<int>();
            var isSupportedShort = SupportedTypes.IsSupported<short>();
            var isSupportedLong = SupportedTypes.IsSupported<long>();
            var isSupportedGuid = SupportedTypes.IsSupported<Guid>();

            // Assert
            Assert.True(isSupportedInt);
            Assert.True(isSupportedShort);
            Assert.True(isSupportedLong);
            Assert.True(isSupportedGuid);
        }

        [Fact]
        public void WhenGenericTypeIsNotSupported_ItShouldReturnFalse()
        {
            // Act
            var isSupportedString = SupportedTypes.IsSupported<string>();
            var isSupportedDecimal = SupportedTypes.IsSupported<decimal>();
            var isSupportedDateTime = SupportedTypes.IsSupported<DateTime>();
            var isSupportedDouble = SupportedTypes.IsSupported<double>();

            // Assert
            Assert.False(isSupportedString);
            Assert.False(isSupportedDecimal);
            Assert.False(isSupportedDateTime);
            Assert.False(isSupportedDouble);
        }
    }
}
