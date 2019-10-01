using System;

namespace Identifiers.TypeConverters
{
    public static class IdentifierTypeConverter
    {
        public static Identifier ToIdentifier<TDatabaseClrType>(object value)
        {
            if (!SupportedTypes.IsSupportedType<TDatabaseClrType>())
            {
                throw CreateNotSupportedException(typeof(TDatabaseClrType).FullName);
            }

            if (!SupportedTypes.IsSupportedValueType(value))
            {
                throw CreateNotSupportedException(value.GetType().FullName);
            }

            if (value == null)
            {
                return new Identifier();
            }

            try
            {
               return new Identifier(Convert.ChangeType(value, typeof(TDatabaseClrType)));
            }
            catch (Exception)
            {
                throw CreateNotSupportedException(value.GetType().FullName);
            }
        }

        public static TDatabaseClrType FromIdentifier<TDatabaseClrType>(Identifier identifier)
        {
            if (!SupportedTypes.IsSupportedType<TDatabaseClrType>())
            {
                throw CreateNotSupportedException(typeof(TDatabaseClrType).FullName);
            }

            var value = identifier.GetValue();

            if (value == null)
            {
                return default;
            }

            return (TDatabaseClrType) Convert.ChangeType(value, typeof(TDatabaseClrType));
        }

        private static Exception CreateNotSupportedException(string typename)
        {
            return new NotSupportedException($"Type {typename} is not supported by Identifiers");
        }
    }
}