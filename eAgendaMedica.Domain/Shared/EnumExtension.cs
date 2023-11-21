using System.ComponentModel;
using System.Reflection;

namespace eAgendaMedica.Domain.Shared
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();

            string name = Enum.GetName(type, value);

            if (name == null)
                return null;

            FieldInfo field = type.GetField(name);

            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? name;
        }
    }
}
