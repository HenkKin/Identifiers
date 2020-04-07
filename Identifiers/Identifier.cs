using System;
using System.Collections;

namespace Identifiers
{
    public struct Identifier : IComparable<Identifier>, IEquatable<Identifier>, IConvertible
    {
        private readonly object _value;

        public static Identifier Empty => new Identifier(null);

        public Identifier(object value = null)
        {
            _value = value;
        }

        public object GetValue()
        {
            return _value;
        }

        public static bool operator <(Identifier a, Identifier b)
        {
            return Comparer.Default.Compare(a._value, b._value) < 0;
        }

        public static bool operator >(Identifier a, Identifier b)
        {
            return Comparer.Default.Compare(a._value, b._value) > 0;
        }

        public static bool operator <=(Identifier a, Identifier b)
        {
            return (a < b) || (a == b);
        }

        public static bool operator >=(Identifier a, Identifier b)
        {
            return (a > b) || (a == b);
        }

        public static bool operator ==(Identifier a, Identifier b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Identifier a, Identifier b)
        {
            return !(a == b);
        }

        public bool Equals(Identifier other)
        {
            if (_value == null && other._value == null)
            {
                return true;
            }

            if (_value == null)
            {
                return false;
            }

            return _value.Equals(other._value);
        }

        public int CompareTo(Identifier other)
        {
            return Comparer.Default.Compare(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            return obj is Identifier other && Equals(other);
        }

        public override int GetHashCode() => _value != null ? _value.GetHashCode() : HashCode.Combine(_value);

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(_value, provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value, provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(_value, provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(_value, provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(_value, provider);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(_value, provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_value, provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(_value, provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(_value, provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(_value, provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_value, provider);
        }

        public string ToString(IFormatProvider provider)
        {
            return _value == null ? null : Convert.ToString(_value, provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(_value, conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(_value, provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_value, provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_value, provider);
        }
    }
}