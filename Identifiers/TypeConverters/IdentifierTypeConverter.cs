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

            if (value == null)
            {
                return new Identifier();
            }

            if (!SupportedTypes.IsSupportedValueType(value))
            {
                throw CreateNotSupportedException(value.GetType().FullName);
            }

            try
            {
                if (typeof(TDatabaseClrType) == typeof(int))
                {
                    return new Identifier(Convert.ToInt32(value));
                }

                if (typeof(TDatabaseClrType) == typeof(long))
                {
                    return new Identifier(Convert.ToInt64(value));
                }

                if (typeof(TDatabaseClrType) == typeof(Guid))
                {
                    return new Identifier(Convert.ChangeType(value, typeof(Guid)));
                }

                if (typeof(TDatabaseClrType) == typeof(short))
                {
                    return new Identifier(Convert.ToInt16(value));
                }
            }
            catch (Exception)
            {
                // throw CreateNotSupportedException(value.GetType().FullName);
                // when error occurred, it should go to next line
            }

            throw CreateNotSupportedException(value.GetType().FullName);
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