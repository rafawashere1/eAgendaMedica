using System.ComponentModel;
using System.Reflection;

namespace eAgendaMedica.Domain.Shared
{
    public static class Utils
    {
        public static TEnum GetEnumFromDescription<TEnum>(string description) where TEnum : Enum
        {
            Type enumType = typeof(TEnum);

            foreach (FieldInfo field in enumType.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentException($"No enum value found with the description: {description}", nameof(description));
        }
    }
}
