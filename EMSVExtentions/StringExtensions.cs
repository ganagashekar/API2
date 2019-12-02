using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EMSVExtentions
{
    public static class StringExtensions
    {
        public static bool IsNotNull(this string str)
        {
            return !str.IsNull();
        }

        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static string ToTrimmedValue(this string str)
        {
            return str.IsNotNull() ? str.Trim() : string.Empty;
        }

        public static bool IsStartWithIgnoreCase(this string primary, string prefix)
        {
            if (primary.IsNull() || prefix.IsNull())
                return false;
            return primary.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsEqualsIgnoreCase(this string str, string other)
        {
            if (str.IsNull() && other.IsNull())
                return true;
            if (str.IsNull() || other.IsNull())
                return false;
            return str.ToTrimmedValue().Equals(other.ToTrimmedValue(), StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsStartsWithIgnoreCase(this string str, string other)
        {
            if (str.IsNull() && other.IsNull())
                return true;
            if (str.IsNull() || other.IsNull())
                return false;
            return str.ToTrimmedValue().StartsWith(other.ToTrimmedValue(), StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsEndsWithIgnoreCase(this string str, string other)
        {
            if (str.IsNull() && other.IsNull())
                return true;
            if (str.IsNull() || other.IsNull())
                return false;
            return str.ToTrimmedValue().EndsWith(other.ToTrimmedValue(), StringComparison.OrdinalIgnoreCase);
        }

        public static int ToInt32(this string str)
        {
            int intEquiv = default(int);
            Int32.TryParse(str, out intEquiv);
            return intEquiv;
        }

        public static int? ToNullableInt(this string str)
        {
            if (str.IsNull())
                return null;
            return str.ToInt32();
        }

        public static string ToJoin(this string first, string last)
        {
            return string.Format("{0} {1}", first, last);
        }

        public static string ToJoinedWithSepartor(this string first, string last)
        {
            return string.Format("{0} - {1}", first, last);
        }

        public static string ToDefaultString(this string primary, string defaulValue = "")
        {
            return primary.IsNotNull() ? primary : defaulValue;
        }

        public static string ToRemovePrefix(this string name)
        {
            return name.IsNull() ? string.Empty : name.Substring(name.IndexOf(" ") + 1);
        }

        public static bool IsDate(this string value, string dateFormat)
        {
            DateTime dateTime;
            return DateTime.TryParseExact(value, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
        }

        public static DateTime? ToDate(this string value, string dateFormat)
        {
            DateTime dateTime;
            if (DateTime.TryParseExact(value, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                return dateTime;
            return null;
        }

        public static DateTime? StringToNullableDateTime(this string stringVal)
        {
            DateTime dat;
            if (DateTime.TryParse(stringVal, out dat))
                return dat;
            return null;
        }

        public static bool IsValidDateTime(this string stringVal)
        {
            DateTime dat;
            return DateTime.TryParseExact(stringVal.Substring(0, 24), "ddd MMM dd yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
        }

        public static DateTime ToGridDateConversion(this string stringval)
        {
            var datestring = stringval;
            DateTime dt = DateTime.ParseExact(datestring.Substring(0, 24), "ddd MMM dd yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            return dt;
        }

        public static string GetCurrenyFormat(this double doublevalue)
        {
            return doublevalue != 0 ? doublevalue.ToString("c2") : string.Empty;
        }

        public static double StringToDouble(this string stringval)
        {
            double doubleval = Convert.ToDouble(stringval);
            return doubleval;
        }

        public static string CurrencyFormat(this double val)
        {
            return val.ToString("c2");
        }

        public static bool EqualsIgnoreCase(this string str, string other)
        {
            return str.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public static string ToTrimmedLower(this string name)
        {
            return name.IsNull() ? string.Empty : name.Trim().ToLower();
        }

        public static string ToAddVersion(this string fileUrl)
        {
            var date = DateTime.Now.Ticks;
            return fileUrl.IsNull() ? string.Empty : String.Format("{0}?version={1}", fileUrl, date);
        }

        public static string ToYesNo(this bool status)
        {
            return status ? "Yes" : "No";
        }

        public static double? ToDouble(this string value)
        {
            double output;
            if (double.TryParse(value, out output))
                return output;
            return default(double?);
        }

        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

       public static string GetColumnName(this int index)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];

            return value;
        }
    }
}
