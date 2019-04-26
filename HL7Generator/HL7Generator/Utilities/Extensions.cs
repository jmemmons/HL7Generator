using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace HL7Generator.Base
{
    public static class Extensions
    {
        /// <summary>
        /// This method is used to get the string friendly name of an enum by looking at the Description attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerationValue"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }

        public static string[] ReadAllResourceLines(string resourceText)
        {
            using (StringReader reader = new StringReader(resourceText))
            {
                return EnumerateLines(reader).ToArray();
            }
        }

        public static string GetFullMessageType(this string messageType)
        {
            return "INBOUND " + messageType;
        }

        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }

        public static string PrettyXml(string xml)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }

        internal static string UnescapeSpecialCharactersFromXml(string message)
        {
            var stringBuilder = new StringBuilder(message);
            var replaceCharacters = new Dictionary<string, string>()
            {
                {"&amp;", "&" }, {"&lt;", "<"}, {"&gt;", ">"}, {"&apos;", "'"}, {"&quot;", "\""}
            };

            foreach (var specialCharacter in replaceCharacters)
            {
                stringBuilder.Replace(specialCharacter.Key, specialCharacter.Value);
            }

            return stringBuilder.ToString();
        }


        private static IEnumerable<string> EnumerateLines(TextReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        public static bool ContainsOrEquals(this string source, string toCheck)
        {
            if (source.Equals(toCheck))
                return true;

            if (source.Contains(toCheck, StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        /// <summary>
        /// A quick way of checking if the string contains only numbers
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string value)
        {
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Takes in date/time as string and returns a safe to use formatted version, ex: 20171201120000
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string SafeDate(this string date)
        {
            if (!date.IsNumeric())
                throw new ArgumentException("The date given, '{0}', was invalid. Please use a 14 digit date like, '20170112152359");

            // Date should only be 14 digits, so return the first 14 characters
            if (date.Length > 14)
                return date.Substring(0, 14);

            // 20170123 is invalid, make it 14 digits
            if (date.Length == 8)
                return date + "120000";

            // Return a 14 digit date
            return date;
        }

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        /// <summary>
        /// Returns a string representation of the DateTime object passed in (date only, e.g. "20071211").
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToDateStringShort(this DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Returns a string representation of the full date, e.g. "20071212042345"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToHL7DateFull(this string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                return "";

            var dateTime = DateTime.Parse(date);
            return dateTime.ToString("yyyyMMddhhmmss");
        }

        /// <summary>
        /// Returns a string representation of the full date, e.g. "20071212042345"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToHL7DateFull(this DateTime date)
        {
            return date.ToString("yyyyMMddhhmmss");
        }

        /// <summary>
        /// Returns a string representation of the full date with only the month and year, e.g. "200712"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToHL7DateShort(this DateTime date)
        {
            return date.ToString("yyyyMM");
        }

        /// <summary>
        /// Returns the month, date, year of a DateTime? object. If null, returns empty string, otherwise, "yyyyMMdd".
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToHL7DateShort(this DateTime? date)
        {
            if (date == null)
                return "";

            var result = (DateTime)date;
            return result.ToString("yyyyMMdd");
        }

        public static string ToHL7DateShort(this string date)
        {
            if (string.IsNullOrWhiteSpace(date) || date.Length < 8)
                return "";

            return date.Substring(0, 8);
        }


        /// <summary>
        /// Takes a full un-formatted phone number and returns it into a format which is valid for CCDA's
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string ToCCDPhone(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";

            var formattedStr = "tel: +1(AREA_CODE)PREFIX-EXTENSION";
            StringBuilder sb = new StringBuilder(formattedStr);
            sb.Replace("AREA_CODE", value.Substring(0, 3));
            sb.Replace("PREFIX", value.Substring(3, 3));
            sb.Replace("EXTENSION", value.Substring(6, 4));
            return sb.ToString();
        }

        /// <summary>
        /// Takes an email address and returns the mailto: hyperlink for it.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string ToCCDEmail(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";

            var formattedStr = "mailto:EMAIL_FIELD";
            StringBuilder sb = new StringBuilder(formattedStr);
            sb.Replace("EMAIL_FIELD", value);
            return sb.ToString();
        }

        public static IEnumerable<string> GetDescriptions(Type type)
        {
            var descs = new List<string>();
            var names = Enum.GetNames(type);
            foreach (var name in names)
            {
                var field = type.GetField(name);
                var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                foreach (DescriptionAttribute fd in fds)
                {
                    descs.Add(fd.Description);
                }
            }
            return descs;
        }
    }
}
