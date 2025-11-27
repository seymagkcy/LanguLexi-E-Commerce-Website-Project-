using System.ComponentModel;

namespace LanguLexi.WebUI.Extensions
{
    public static class EnumExtensions
    {
        public static string GetAsString(this Enum enVal)
        {
            var envalField = enVal.GetType().GetField(enVal.ToString()); 
            var descAttr = envalField.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                     .FirstOrDefault() as DescriptionAttribute;

            return descAttr?.Description ?? enVal.ToString();

        }
    }
}
