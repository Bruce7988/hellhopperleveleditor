using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HellHopperLevelEditor.Model.DataAccess
{
    internal static class DataAccessUtils
    {
        public static string GetString(this XElement element, string attributeName)
        {
            return element.Attribute(attributeName).Value;
        }

        public static string GetString(this XElement element, string attributeName, string defaultValue)
        {
            return element.Attribute(attributeName) != null ? element.GetString(attributeName) : defaultValue;
        }

        public static int GetInt(this XElement element, string attributeName)
        {
            return int.Parse(element.GetString(attributeName), NumberFormatInfo.InvariantInfo);
        }

        public static int GetInt(this XElement element, string attributeName, int defaultValue)
        {
            return element.Attribute(attributeName) != null ? element.GetInt(attributeName) : defaultValue;
        }

        public static double GetDouble(this XElement element, string attributeName)
        {
            return double.Parse(element.GetString(attributeName), NumberFormatInfo.InvariantInfo);
        }

        public static double GetDouble(this XElement element, string attributeName, double defaultValue)
        {
            return element.Attribute(attributeName) != null ? element.GetDouble(attributeName) : defaultValue;
        }

        public static T GetEnum<T>(this XElement element, string attributeName) where T : struct, IConvertible
        {
            return (T) Enum.Parse(typeof(T), element.GetString(attributeName), true);
        }

        public static T GetEnum<T>(this XElement element, string attributeName, T defaultValue) where T : struct, IConvertible
        {
            return element.Attribute(attributeName) != null ? element.GetEnum<T>(attributeName) : defaultValue;
        }

        public static XAttribute GetEnumAttribute<T>(string attributeName, T value) where T : struct, IConvertible
        {
            return new XAttribute(attributeName, value.ToString().ToLowerInvariant());
        }
    }
}
