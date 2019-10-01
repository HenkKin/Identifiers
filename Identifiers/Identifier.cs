using System;
using System.Collections;

namespace Identifiers
{
    public struct Identifier : IComparable<Identifier>, IEquatable<Identifier>
    {
        private static readonly object NullObject = new object();

        private readonly object _value;

        public static Identifier Empty => new Identifier(null);

        public Identifier(object value = null)
        {
            if (value != null && !SupportedTypes.IsSupportedValueType(value))
            {
                throw new NotSupportedException($"Type {value.GetType().FullName} is not supported by Identifiers");
            }
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

        public override int GetHashCode()
        {
            return _value != null ? _value.GetHashCode() : NullObject.GetHashCode();
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : string.Empty;
        }
    }
}