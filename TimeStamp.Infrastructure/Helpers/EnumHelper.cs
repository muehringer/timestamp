using System;
using System.ComponentModel;
using System.Reflection;

namespace TimeStamp.Infrastructure.Helpers
{
    public class EnumHelper
    {
        public static string GetDescription(Enum valueEnum)
        {
            FieldInfo fieldInfo = valueEnum.GetType().GetField(valueEnum.ToString());
            DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length > 0)
                return descriptionAttributes[0].Description;
            else
                return valueEnum.ToString();
        }
    }
}
