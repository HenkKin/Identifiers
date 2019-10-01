using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Identifiers
{
    public static class SupportedTypes
    {
        public static Type Short = typeof(short);
        public static Type Int = typeof(int);
        public static Type Long = typeof(long);
        public static Type Guid = typeof(Guid);

        private static readonly ConcurrentBag<Type> List = new ConcurrentBag<Type>();

        static SupportedTypes()
        {
            List.Add(Int);
            List.Add(Long);
            List.Add(Guid);
            List.Add(Short);
        }

        public static bool IsSupportedType<T>()
        {
            var type = typeof(T);
            return List.Contains(type);
        }

        public static bool IsSupportedType(Type type)
        {
            return List.Contains(type);
        }

        public static bool IsSupportedValueType(object value)
        {
            var type = value?.GetType();
            return List.Contains(type);
        }
    }
}
