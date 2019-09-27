using System;

namespace Identifiers.TypeConverters
{
    public static class IdentifierTypeConverter
    {
        public static Identifier ToIdentifier<TDatabaseClrType>(object value) where TDatabaseClrType : IConvertible
        {
            if (value == null)
            {
                return new Identifier();
            }

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
                return new Identifier(Convert.ToInt16(value));
            }

            if (typeof(TDatabaseClrType) == typeof(short))
            {
                return new Identifier(Convert.ToInt16(value));
            }

            return new Identifier(Convert.ChangeType(value, typeof(TDatabaseClrType)));
        }

        public static TDatabaseClrType FromIdentifier<TDatabaseClrType>(Identifier identifier)
        {
            var value = identifier.GetValue();

            if (value == null)
            {
                return default;
            }

            return (TDatabaseClrType) Convert.ChangeType(value, typeof(TDatabaseClrType));
        }
    }
}