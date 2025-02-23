using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace project
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo? field = type.GetField(enumValue.ToString());
            object[]? attributes = field?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes?.Length ?? 0) == 0
                ? enumValue.ToString()
                : ((DescriptionAttribute?)attributes?[0])?.Description ?? enumValue.ToString();
        }

        public static IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
